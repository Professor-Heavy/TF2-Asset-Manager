using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AssetManager
{
    public partial class MainWindow : Form
    {
        public class MaterialParameterDisplayListEntry
        {
            public int Position { get; set; }
            public MaterialParameter Param { get; set; }
            public string ParamName { get; set; }
        }
        public class LocalisationParameterDisplayListEntry
        {
            public int Position { get; set; }
            public LocalisationParameter Param { get; set; }
            public string ParamName { get; set; }
        }

        public enum ExportState
        {
            Begin,
            Success,
            Error,
            ErrorFatal
        }

        // Initialize the directories, and create them if they don't exist.

        string pathToExecutableDirectory = "";
        static public string userDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        static public string completeUserDataPath = Path.Combine(userDataPath, "Team-Fortress-2-Asset-Manager");
        static public bool exportingState = false;

        // static public CancellationToken cancellationToken = cancellationTokenSource.Token;
        
        List<MaterialParameterDisplayListEntry> materialParameterDisplayList = new List<MaterialParameterDisplayListEntry>();
        List<LocalisationParameterDisplayListEntry> localisationParameterDisplayList = new List<LocalisationParameterDisplayListEntry>();

        public MainWindow()
        {
            InitializeComponent();
            Directory.CreateDirectory(completeUserDataPath);
            List<string> errorList = XMLInteraction.VerifyXMLIntegrity(completeUserDataPath);
            if (errorList.Count > 0)
            {
                toolStripStatusLabel.Text = "Errors were encountered while loading the parameter configuration file. See the Export tab for more info.";
                foreach(string error in errorList)
                {
                    progressBox.AppendText(error + "\r\n");
                }
            }

            try
            {
                pathToExecutableDirectory = Properties.Settings.Default.GameLocation;
                saveFileLocationText.Text = Properties.Settings.Default.VpkLocation;
                saveFileDialog1.FileName = Properties.Settings.Default.VpkLocation;
                //TODO: These.
                //materialCorruptionEnableCheckBox.Checked = Properties.Settings.Default.MaterialCorruptionsEnabled;
                //localisationCorruptionEnableCheckBox.Checked = Properties.Settings.Default.LocalisationCorruptionsEnabled;
                muteCheckBox.Checked = Properties.Settings.Default.MuteSounds;
                disableNotificationsCheckBox.Checked = Properties.Settings.Default.MuteNotifs;
                launchGameCheckBox.Checked = Properties.Settings.Default.LaunchGameOnExport;
                launchGameArgumentsTextBox.Text = Properties.Settings.Default.LaunchGameArguments;
            }
            catch(System.Configuration.ConfigurationErrorsException ex)
            {
                //This happened to me once.
                MessageBox.Show("There was an issue when trying to load the saved settings.\nAll settings will now be reset.", "Saved Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.IO.Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\AssetManager", true);
                MessageBox.Show("The application will now restart.", "Saved Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                Environment.Exit(0);
            }
            
            gameLocationText.Text = pathToExecutableDirectory;
            if (!ConfirmValidGame())
            {
                toolStripStatusLabel.Text = "Warning: gameinfo.txt not present in specified directory. Please confirm the location to the \"tf\" folder in the Export tab.";
            }
            else
            {
                VPKInteraction.ReadVpk(Path.Combine(pathToExecutableDirectory, "tf\\tf2_misc_dir.vpk"));
                PopulateCustomFileList();
            }
        }

        public bool ConfirmValidGame()
        {
            if (!string.IsNullOrEmpty(pathToExecutableDirectory) && File.Exists(Path.Combine(pathToExecutableDirectory, "tf\\gameinfo.txt")))
            { return true; }
            else
            { return false; }
        }

        public TreeView PopulateVpkDirectoryListing(TreeView treeView, int layer, string expandedDirectory)
        {
            TreeNode lastNode = null;
            TreeView result = new TreeView();
            string subPathAgg;
            foreach (string directory in VPKInteraction.vpkContents)
            {
                string[] subPaths = directory.Split('/');
                TreeNode[] nodes = treeView.Nodes.Find(subPaths[layer], false);
                if (nodes.Length == 0)
                {
                    TreeNode insertedNode = treeView.Nodes.Add(subPaths[layer], subPaths[layer]);
                }
            }
            treeView.Sort();
            return result;
        }

        public void RefreshMaterialParameterList()
        {
            materialParameterDisplayList.Clear();
            foreach (MaterialParameter param in XMLInteraction.materialParametersList)
            {
                materialParameterDisplayList.Add(new MaterialParameterDisplayListEntry() { Position = materialParameterDisplayList.Count, Param = param, ParamName = param.ParamName });
            }
            materialParameterList.DataSource = null;
            materialParameterList.DataSource = materialParameterDisplayList;
            materialParameterList.DisplayMember = "ParamName";
            materialParameterList.ValueMember = "Position";

            //To be honest, it's quite frustrating how for some reason, the selected index is always reassigned the very moment the parameters are refreshed. Let's fix that.
            materialParameterList.SelectedIndex = -1;
        }

        public void RefreshLocalisationParameterList()
        {
            localisationParameterDisplayList.Clear();
            foreach (LocalisationParameter param in XMLInteraction.localisationParametersList)
            {
                localisationParameterDisplayList.Add(new LocalisationParameterDisplayListEntry() { Position = localisationParameterDisplayList.Count, Param = param, ParamName = param.ParamName });
            }
            localisationParameterList.DataSource = null;
            localisationParameterList.DataSource = localisationParameterDisplayList;
            localisationParameterList.DisplayMember = "ParamName";
            localisationParameterList.ValueMember = "Position";

            localisationParameterList.SelectedIndex = -1;
        }

        private async void StartPackagingButton_Click(object sender, EventArgs e)
        {
            progressBox.Clear();
            if (!ConfirmValidGame())
            {
                toolStripStatusLabel.Text = "ERROR: Cannot export. gameinfo.txt not present in specified directory. Please confirm the location to the \"tf\" folder in the Export tab.";
                return;
            }
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(saveFileDialog1.FileName)))
                {
                    WriteMessage("ERROR: Tne export directory is not accessible.", ExportState.ErrorFatal);
                    return;
                }
            }
            catch (ArgumentException)
            {
                WriteMessage("ERROR: Tne export directory is not accessible.", ExportState.ErrorFatal);
                return;
            }
            for (var i = 0; i < materialParameterList.Items.Count; i++)
            // Considering using this as a way to preset the parameters so that I don't need to
            // run constant cases later on when the process begins.
            {
                if (materialParameterList.GetItemChecked(i))
                {
                    MaterialParameter param = (materialParameterList.Items[i] as MaterialParameterDisplayListEntry).Param;
                    int result = VMTInteraction.VerifyParameter(param);
                    if (result != -1)
                    {
                        if (result == 0)
                        {
                            progressBox.AppendText("WARNING: Parameter '" + param.ParamName + "' is missing required settings. Please check the parameter settings for more info and try again.\r\n");
                        }
                        if (result == 1)
                        {
                            progressBox.AppendText("WARNING: Parameter '" + param.ParamName + "' is of type " + param.ParamType + "but the value is " + param.ParamValue + ". Please check the parameter settings and try again.\r\n");
                        }
                        WriteMessage("Parameter " + param.ParamName + " has been disabled.");
                        materialParameterList.SetItemChecked(i, false);
                    }
                }
            }
            for (var i = 0; i < localisationParameterList.Items.Count; i++)
            {
                if (localisationParameterList.GetItemChecked(i))
                {
                    LocalisationParameter param = (localisationParameterList.Items[i] as LocalisationParameterDisplayListEntry).Param;
                    int result = TXTInteraction.VerifyParameter(param);
                    if (result != -1)
                    {
                        if (result == 0)
                        {
                            progressBox.AppendText("WARNING: Parameter '" + param.ParamName + "' has the type Replace Characters, but Regex Mode is somehow disabled for this parameter, or the Regex field is empty. This is not supported at this time.\r\n");
                        }
                        if (result == 1)
                        {
                            progressBox.AppendText("WARNING: Parameter '" + param.ParamName + "' failed a regex verification. Please test the regex in the Manage Parameters window on the Localisation tab.\r\n");
                        }
                        if (result == 2)
                        {
                            progressBox.AppendText("WARNING: Parameter '" + param.ParamName + "' is set to limit affected entries on character counts, but the minimum limit (" + param.LetterCountFilterMin + ") is greater than the maximum limit. (" + param.LetterCountFilterMax + ")\r\n");
                        }
                        WriteMessage("Parameter " + param.ParamName + " has been disabled.");
                        localisationParameterList.SetItemChecked(i, false);
                    }
                }
            }

            if (exportingState)
            {
                progressBox.AppendText("Cancelling not available at this point in the process.\r\n");
                //cancellationTokenSource.Cancel(); //Cancel immediately.
            }
            else
            {
                startPackagingButton.Text = "Abort Packaging";
            }


            ////
            ////
            //// BEGIN
            ////
            ////

            DirectoryInfo exportPath = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileNameWithoutExtension(Properties.Settings.Default.VpkLocation)));
            string tempFileLocation = Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileName(saveFileDialog1.FileName));
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token; //TODO: This exists for a reason... Maybe I can make full use of it.
            exportingState = true;

            
            List<string> includedCustomFiles = new List<string>();
            foreach (string itemChecked in customFileCheckList.CheckedItems)
            {
                includedCustomFiles.Add(itemChecked);
            }

            WriteMessage("Export has begun.", ExportState.Begin);
            ExportProcess.ExportSettings exportSettings = new ExportProcess.ExportSettings()
            {
                MaterialParameters = GetEnabledMaterialParameters().ToArray(),
                LocalisationParameters = GetEnabledLocalisationParameters().ToArray()
            };
            if(materialCorruptionEnableCheckBox.Checked)
            {
                // 0 = Swap
                // 1 = Offset
                exportSettings.MaterialCorruptionSettings = new MaterialCorruptionSettings[]
                { XMLInteraction.materialCorruptionSettings[0], 
                  XMLInteraction.materialCorruptionSettings[1] };
            }
            if (localisationCorruptionEnableCheckBox.Checked)
            {
                exportSettings.LocalisationCorruptionSettings = new LocalisationCorruptionSettings[]
                { XMLInteraction.localisationCorruptionSettings[0],
                  XMLInteraction.localisationCorruptionSettings[1] };
            }
            bool success = await ExportProcess.Export(pathToExecutableDirectory, customFilesCheckBox.Checked, includedCustomFiles, this, exportSettings);
            if(!success)
            {
                startPackagingButton.Text = "Begin Packaging";
                exportingState = false;
                return;
            }
            try
            {
                File.Delete(saveFileDialog1.FileName);
                File.Move(tempFileLocation, saveFileDialog1.FileName);
                WriteMessage("Operation complete.",ExportState.Success, "Export complete.");
                if(Properties.Settings.Default.LaunchGameOnExport)
                {
                    LaunchGame();
                }
            }
            catch (IOException)
            {
                WriteMessage("ERROR: The output file is already in use by another process. Please close the process that is using this file.", ExportState.ErrorFatal, "An error has occurred during exporting. The target export file already exists, and cannot be written over.");
            }
            ClearAllTempFiles(exportPath, tempFileLocation);
            exportingState = false;
            startPackagingButton.Text = "Begin Packaging";
        }

        private void OperationCancelled()
        {
            if(!exportingState)
            {
                return; //How did we get here?
            }
            progressBox.AppendText("The operation was cancelled.");
            exportingState = false;
            startPackagingButton.Text = "Begin Packaging";
        }

        private void ClearAllTempFiles(DirectoryInfo directory, string tempFile)
        {
            if(Directory.Exists(directory.FullName))
            {
                directory.Delete(true);
            }
            if (tempFile != null && File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }

        private void LaunchGame()
        {
            using (Process pProcess = new Process())
            {
                pProcess.StartInfo.FileName = "steam://run/440/" + Properties.Settings.Default.LaunchGameArguments;
                pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                pProcess.Start();
            }
        }
        private void ManageParameterButton_Click(object sender, EventArgs e)
        {
            ManageMaterialParametersWindow f2 = new ManageMaterialParametersWindow
            {
                Parent = this
            };
            f2.ShowDialog(); 
        }

        private void SaveFileLocationButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.VpkLocation = saveFileDialog1.FileName;
            saveFileLocationText.Text = saveFileDialog1.FileName;
            Properties.Settings.Default.Save();
            if (string.IsNullOrEmpty(saveFileDialog1.FileName) || !Directory.Exists(Path.GetDirectoryName(saveFileDialog1.FileName)))
            {
                exportLocationValidLabel.Text = "Location invalid.";
            }
            else
            {
                exportLocationValidLabel.Text = "Location valid.";
            }
        }

        private void SaveFileLocationText_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.VpkLocation = saveFileLocationText.Text;
            saveFileDialog1.FileName = saveFileLocationText.Text;
            Properties.Settings.Default.Save();
            if (string.IsNullOrEmpty(saveFileDialog1.FileName) || !Directory.Exists(Path.GetDirectoryName(saveFileDialog1.FileName)))
            {
                exportLocationValidLabel.Text = "Location invalid.";
            }
            else
            {
                exportLocationValidLabel.Text = "Location valid.";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            executableOpenFileDialogue.ShowDialog();
        }

        private void executableOpenFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            if (Directory.Exists(executableOpenFileDialogue.FileName))
            {
                gameLocationText.Text = executableOpenFileDialogue.FileName;
                pathToExecutableDirectory = executableOpenFileDialogue.FileName;
            }
            else
            {
                gameLocationText.Text = Path.GetDirectoryName(executableOpenFileDialogue.FileName);
                pathToExecutableDirectory = Path.GetDirectoryName(executableOpenFileDialogue.FileName);
            }
            Properties.Settings.Default.GameLocation = pathToExecutableDirectory;
            gameLocationValidLabel.Text = ConfirmValidGame() ? "gameinfo.txt found." : "gameinfo.txt missing.";

        }
        private void GameLocationText_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(gameLocationText.Text))
                {
                    executableOpenFileDialogue.FileName = gameLocationText.Text;
                    pathToExecutableDirectory = executableOpenFileDialogue.FileName;
                }
                else
                {
                    executableOpenFileDialogue.FileName = Path.GetDirectoryName(gameLocationText.Text);
                    pathToExecutableDirectory = Path.GetDirectoryName(executableOpenFileDialogue.FileName);
                }
            }
            catch(ArgumentException)
            {
                gameLocationValidLabel.Text = "Location invalid.";
                return;
            }
            Properties.Settings.Default.GameLocation = pathToExecutableDirectory;
            gameLocationValidLabel.Text = ConfirmValidGame() ? "gameinfo.txt found." : "gameinfo.txt missing.";
        }

        private void WindowTabControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameLocationText_LostFocus(null, null);
            SaveFileLocationText_Leave(null, null);
            executableOpenFileDialogue_FileOk(null, null);
            parametersForExportList.Items.Clear();
            parametersForExportList.Items.AddRange(GetEnabledMaterialParameters().Select(x => "Materials: " + x.ParamName).ToArray());
            if(materialCorruptionEnableCheckBox.Checked)
            {
                parametersForExportList.Items.AddRange(XMLInteraction.materialCorruptionSettings.Where(x => x.Enabled == true).Select(x => "Material Corruption: " + x.CorruptionType).ToArray());
            }
            parametersForExportList.Items.AddRange(GetEnabledLocalisationParameters().Select(x => "Localisation: " + x.ParamName).ToArray());
            if(localisationCorruptionEnableCheckBox.Checked)
            {
                parametersForExportList.Items.AddRange(XMLInteraction.localisationCorruptionSettings.Where(x => x.Enabled == true).Select(x => "Localisation Corruption: " + x.CorruptionType).ToArray());
            }
        }

        private async void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            await XMLInteraction.WriteXmlParameters(completeUserDataPath);
            await XMLInteraction.WriteXmlCorruptionParameters(completeUserDataPath);
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            XMLInteraction.InitialiseParameterListings(completeUserDataPath, false);
            XMLInteraction.ReadXmlCorruptionParameters(completeUserDataPath);
            RefreshMaterialParameterList();
            RefreshLocalisationParameterList();

            //TreeView directories = await Task.Run(() => PopulateVpkDirectoryListing(vpkDirectoryListing, 0, null));
            // vpkDirectoryListing.Nodes.Clear();
            // vpkDirectoryListing.Nodes.AddRange(directories)
        }

        private void OverwriteModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].ParamForce = overwriteModeComboBox.SelectedIndex;
        }

        private void RandomizerOffsetNumeric_ValueChanged(object sender, EventArgs e)
        {
            XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].RandomizerOffset[0] = (float)randomizerOffsetNumeric.Value;
        }

        private void RandomizerOffsetNumeric2_ValueChanged(object sender, EventArgs e)
        {
            if(XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].ParamType.ToString() == "vector3")
            {
                XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].RandomizerOffset[1] = (float)randomizerOffsetNumeric2.Value;
            }
        }

        private void RandomizerOffsetNumeric3_ValueChanged(object sender, EventArgs e)
        {
            if (XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].ParamType.ToString() == "vector3")
            {
                XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].RandomizerOffset[2] = (float)randomizerOffsetNumeric3.Value;
            }
        }

        private void ExcludedShadersButton_Click(object sender, EventArgs e)
        {
            ShaderFiltersWindow form = new ShaderFiltersWindow
            {
                parameterInfo = XMLInteraction.materialParametersList[materialParameterList.SelectedIndex]
            };
            form.ShowDialog();
        }

        private void MaterialParameterList_MouseClick(object sender, MouseEventArgs e)
        {
            if (materialParameterList.SelectedIndex != -1)
            {
                //HACK: https://stackoverflow.com/a/4579701
                if ((e.Button == MouseButtons.Left) && (e.X > 13))
                {
                    DisplayMaterialParameterSettings();
                }
                if ((e.Button == MouseButtons.Left) && (e.X <= 13))
                {
                    //TODO: While trying to unhack the hack, I accidentally created a new hack that doesn't work. Whoops.
                }
            }
        }
        void DisplayMaterialParameterSettings()
        {
            if(materialParameterList.SelectedIndex == -1)
            {
                materialParameterSettingsGroupBox.Hide();
                return;
            }
            MaterialParameter selectedParameter = materialParameterDisplayList[materialParameterList.SelectedIndex].Param;
            overwriteModeComboBox.SelectedIndex = selectedParameter.ParamForce;
            randomizerOffsetNumeric.DecimalPlaces = 7;
            deviationSettingsParam1Label.Text = "Parameter Random Deviation";
            deviationSettingsParam2Label.Hide();
            deviationSettingsParam3Label.Hide();
            randomizerOffsetNumeric2.Hide();
            randomizerOffsetNumeric3.Hide();
            if (selectedParameter.ParamType.ToString() == "integer") //Consider case/switch.
            {
                randomizerOffsetNumeric.DecimalPlaces = 0;
                deviationSettingsGroupBox.Show();
            }
            else if (selectedParameter.ParamType.ToString() == "bool"
                     || selectedParameter.ParamType.ToString() == "proxy")
            {
                deviationSettingsGroupBox.Hide();
            }
            else if (selectedParameter.ParamType.ToString().Contains("vector3"))
            {
                deviationSettingsGroupBox.Show();
                deviationSettingsParam1Label.Text = "Parameter 1 Random Deviation";
                deviationSettingsParam1Label.Show();
                deviationSettingsParam2Label.Show();
                deviationSettingsParam3Label.Show();
                randomizerOffsetNumeric.Show();
                randomizerOffsetNumeric2.Show();
                randomizerOffsetNumeric3.Show();
            }
            materialRandomizerChanceLabel.Text = selectedParameter.RandomizerChance.ToString();
            materialRandomizerChanceTrackBar.Value = selectedParameter.RandomizerChance;
            randomizerOffsetNumeric.Value = (decimal)selectedParameter.RandomizerOffset[0];
            randomizerOffsetNumeric2.Value = (decimal)selectedParameter.RandomizerOffset[1];
            randomizerOffsetNumeric3.Value = (decimal)selectedParameter.RandomizerOffset[2];
            materialParameterSettingsGroupBox.Show();
        }

        private void MaterialRandomizerScrollBarChanged(object sender, EventArgs e)
        {
            XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].RandomizerChance = materialRandomizerChanceTrackBar.Value;
        }

        private void MaterialRandomizerChanceTrackBar_Scroll(object sender, EventArgs e)
        {
            materialRandomizerChanceLabel.Text = materialRandomizerChanceTrackBar.Value.ToString();
        }

        private void MaterialRandomizerChanceLabel_TextChanged(object sender, EventArgs e)
        {
            //Is there a better way to handle this instead of reattaching the event?
            materialRandomizerChanceLabel.TextChanged -= MaterialRandomizerChanceLabel_TextChanged;
            materialRandomizerChanceLabel.Text += '%';
            materialRandomizerChanceLabel.TextChanged += MaterialRandomizerChanceLabel_TextChanged;
        }

        private void CustomFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customFileCheckList.Enabled = customFilesCheckBox.Checked;
            if(ConfirmValidGame())
            {
                PopulateCustomFileList();
            }
        }

        private void PopulateCustomFileList()
        {
            customFileCheckList.Items.Clear();
            string customDirectory = Path.Combine(pathToExecutableDirectory, "tf\\custom");
            foreach (string directory in Directory.GetDirectories(customDirectory).Select(Path.GetFileName).ToArray())
            {
                customFileCheckList.Items.Add(directory);
            }
            foreach (string file in Directory.GetFiles(customDirectory, "*.vpk").Select(Path.GetFileName).ToArray())
            {
                customFileCheckList.Items.Add(file);
            }
        }

        private delegate void WriteMessageDelegate(string message);
        private delegate void WriteMessageSoundDelegate(string message, ExportState severity);
        private delegate void WriteMessageBalloonDelegate(string message, ExportState severity, string balloonMessage);
        /// <summary>
        /// Writes a string message in the progress text box.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public void WriteMessage(string message)
        {
            if(progressBox.InvokeRequired)
            {
                var dele = new WriteMessageDelegate(WriteMessage);
                progressBox.Invoke(dele, new object[] { message });
            }
            else
            {
                progressBox.AppendText(message);
                progressBox.AppendText("\r\n");
            }
        }

        /// <summary>
        /// Writes a string message in the progress text box, playing a sound as well.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        public void WriteMessage(string message, ExportState severity)
        {
            if (progressBox.InvokeRequired)
            {
                var dele = new WriteMessageSoundDelegate(WriteMessage);
                progressBox.Invoke(dele, new object[] { message, severity});
            }
            else
            {
                progressBox.AppendText(message);
                progressBox.AppendText("\r\n");
                PlayNotificationSound(severity);
            }
            
        }

        /// <summary>
        /// Writes a string message in the progress text box, playing a sound and displaying a notifiation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        public void WriteMessage(string message, ExportState severity, string balloonMessage)
        {
            if (progressBox.InvokeRequired)
            {
                var dele = new WriteMessageBalloonDelegate(WriteMessage);
                progressBox.Invoke(dele, new object[] { message, severity, balloonMessage});
            }
            else
            {
                progressBox.AppendText(message);
                progressBox.AppendText("\r\n");
                PlayNotificationSound(severity);
                DisplayNotificationBalloon(balloonMessage);
            }
        }

        public List<MaterialParameter> GetEnabledMaterialParameters()
        {
            List<MaterialParameter> materialParameters = new List<MaterialParameter>();
            for (var i = 0; i < materialParameterList.Items.Count; i++)
            {
                if (materialParameterList.GetItemChecked(i))
                {
                    MaterialParameter param = (materialParameterList.Items[i] as MaterialParameterDisplayListEntry).Param;
                    int result = VMTInteraction.VerifyParameter(param);
                    if (result != -1)
                    {
                        if (result == 0)
                        {
                            progressBox.AppendText("WARNING: Parameter " + param.ParamName + " is missing required settings. Please check the parameter settings for more info and try again.\r\n");
                        }
                        if (result == 1)
                        {
                            progressBox.AppendText("WARNING: Parameter " + param.ParamName + " is of type " + param.ParamType + "but the value is " + param.ParamValue + ". Please check the parameter settings and try again.\r\n");
                        }
                        WriteMessage("Parameter " + param.ParamName + " has been deselected.\r\n");
                        materialParameterList.SetItemChecked(i, false);
                    }
                    else
                    {
                        materialParameters.Add(param);
                    }
                }
            }
            return materialParameters;
        }

        public List<LocalisationParameter> GetEnabledLocalisationParameters()
        {
            List<LocalisationParameter> localisationParameters = new List<LocalisationParameter>();
            for (var i = 0; i < localisationParameterList.Items.Count; i++)
            {
                if (localisationParameterList.GetItemChecked(i))
                {
                    LocalisationParameter param = (localisationParameterList.Items[i] as LocalisationParameterDisplayListEntry).Param;
                    localisationParameters.Add(param);
                }
            }
            return localisationParameters;
        }

        private void PlayNotificationSound(ExportState severity)
        {
            string soundLocation = Path.Combine(Environment.CurrentDirectory, "sounds");
            SoundPlayer player = null;

            switch (severity)
            {
                case ExportState.Begin:
                    player = new SoundPlayer(Path.Combine(soundLocation, "begin.wav"));
                    break;
                case ExportState.Error:
                case ExportState.ErrorFatal:
                    player = new SoundPlayer(Path.Combine(soundLocation, "error.wav"));
                    break;
                case ExportState.Success:
                    player = new SoundPlayer(Path.Combine(soundLocation, "success.wav"));
                    break;
                default:
                    break;
            }
            try
            {
                if(!muteCheckBox.Checked)
                {
                    player.Play();
                }
            }
            catch(FileNotFoundException)
            {
            }
        }

        private void DisplayNotificationBalloon(string message)
        {
            if (disableNotificationsCheckBox.Checked)
            {
                return;
            }
            if (this.ContainsFocus)
            {
                return;
            }
            NotifyIcon notif = new NotifyIcon
            {
                Icon = Icon,
                BalloonTipTitle = "Team Fortress 2 Asset Manager",
                Visible = true
            };
            notif.BalloonTipText = message;
            //HACK: https://stackoverflow.com/questions/13373060/show-a-balloon-notification#comment89015772_34956412
            notif.ShowBalloonTip(5000);
            notif.BalloonTipClosed += (sender, args) => notif.Dispose();
            notif.BalloonTipClicked += (sender, args) => notif.Dispose();
        }

        private void ProxyFilterButton_Click(object sender, EventArgs e)
        {
            ProxyFiltersWindow form = new ProxyFiltersWindow
            {
                parameterInfo = XMLInteraction.materialParametersList[materialParameterList.SelectedIndex]
            };
            form.ShowDialog();
        }

        private void MaterialCorruptionEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MaterialCorruptionEnableCheckBox_MouseUp(object sender, MouseEventArgs e)
        {
            if(!materialCorruptionEnableCheckBox.Checked)
            {
                corruptionSettingsGroupBox.Enabled = false;
                Properties.Settings.Default.MaterialCorruptionsEnabled = false;
                return;
            }
            DialogResult warningWindowResult = MessageBox.Show("Corruption Mode is a fun way to completely screw up your game.\nWhile this mod may not have any lasting effects, there may be side effects if this mode is used too heavily.\nAre you sure you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (warningWindowResult == DialogResult.No)
            {
                materialCorruptionEnableCheckBox.Checked = false;
            }
            else
            {
                corruptionSettingsGroupBox.Enabled = true;
                Properties.Settings.Default.MaterialCorruptionsEnabled = true;
            }
        }

        private void RandomizerScrollBarChanged(object sender, KeyEventArgs e)
        {
            //XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerChance = randomizerChanceTrackBar.Value;
        }

        private void CorruptionSwapFilterButton_Click(object sender, EventArgs e)
        {
            FilterOptionsWindow form = new FilterOptionsWindow()
            {
                settings = XMLInteraction.materialCorruptionSettings[0]
            };
            form.ShowDialog();
        }

        private void CorruptionSwapTrackBar_Scroll(object sender, EventArgs e)
        {
            corruptionSwapChanceLabel.Text = corruptionSwapTrackBar.Value.ToString();
            XMLInteraction.materialCorruptionSettings[0].Probability = corruptionSwapTrackBar.Value;
        }

        private void CorruptionSwapChanceLabel_TextChanged(object sender, EventArgs e)
        {
            //HACK: Reassigning an event like this doesn't feel worth doing.
            corruptionSwapChanceLabel.TextChanged -= CorruptionSwapChanceLabel_TextChanged;
            corruptionSwapChanceLabel.Text += '%';
            corruptionSwapChanceLabel.TextChanged += CorruptionSwapChanceLabel_TextChanged;
        }

        private void CorruptionSwapEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            XMLInteraction.materialCorruptionSettings[0].Enabled = corruptionSwapEnableCheckBox.Checked;
        }

        private void CorruptionOffsetSettingsButton_Click(object sender, EventArgs e)
        {
            CorruptionOffsetSettings form = new CorruptionOffsetSettings
            {
                settings = XMLInteraction.materialCorruptionSettings[1]
            };
            form.ShowDialog();
        }

        private void CorruptionOffsetFilterButton_Click(object sender, EventArgs e)
        {
            FilterOptionsWindow form = new FilterOptionsWindow()
            {
                settings = XMLInteraction.materialCorruptionSettings[1]
            };
            form.ShowDialog();
        }

        private void CorruptionOffsetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            XMLInteraction.materialCorruptionSettings[1].Enabled = corruptionOffsetCheckBox.Checked;
        }

        private void CorruptionOffsetTrackBar_Scroll(object sender, EventArgs e)
        {
            corruptionOffsetChanceLabel.Text = corruptionOffsetTrackBar.Value.ToString();
            XMLInteraction.materialCorruptionSettings[1].Probability = corruptionOffsetTrackBar.Value;
        }

        private void ManageLocalisationParametersButton_Click(object sender, EventArgs e)
        {
            ManageLocalisationParametersWindow f2 = new ManageLocalisationParametersWindow
            {
                Parent = this
            };
            f2.ShowDialog();
        }

        private async void LocalisationParameterList_MouseClick(object sender, MouseEventArgs e)
        {
            //HACK: See MaterialParameterList_MouseClick(...)
            if ((e.Button == MouseButtons.Left) & (e.X > 13))
            {
                LocalisationParameter selectedParameter = localisationParameterDisplayList[localisationParameterList.SelectedIndex].Param;
                localisationParameterList.SetItemChecked(this.localisationParameterList.SelectedIndex, !this.localisationParameterList.GetItemChecked(this.localisationParameterList.SelectedIndex));
                await XMLInteraction.WriteXmlParameters(completeUserDataPath);
                localisationLetterCountCheckBox.Checked = selectedParameter.LetterCountFilterMode;
                localisationLetterCountMinNumeric.Enabled = localisationLetterCountCheckBox.Checked;
                localisationLetterCountMaxNumeric.Enabled = localisationLetterCountCheckBox.Checked;
                localisationLetterCountMinNumeric.Value = selectedParameter.LetterCountFilterMin;
                localisationLetterCountMaxNumeric.Value = selectedParameter.LetterCountFilterMax;
                localisationRandomizerChanceLabel.Text = selectedParameter.RandomizerChance.ToString();
                localisationRandomizerChanceTrackBar.Value = selectedParameter.RandomizerChance;
                localisationRandomizerIndividualChanceLabel.Text = selectedParameter.RandomizerIndividualChance.ToString();
                localisationRandomizerIndividualChanceTrackBar.Value = selectedParameter.RandomizerIndividualChance;
                localisationParameterSettingsGroupBox.Show();
            }
        }

        private void LocalisationRandomizerChanceTrackBar_Scroll(object sender, EventArgs e)
        {
            localisationRandomizerChanceLabel.Text = localisationRandomizerChanceTrackBar.Value.ToString();
        }

        private void LocalisationRandomizerChanceLabel_TextChanged(object sender, EventArgs e)
        {
            localisationRandomizerChanceLabel.TextChanged -= LocalisationRandomizerChanceLabel_TextChanged;
            localisationRandomizerChanceLabel.Text += '%';
            localisationRandomizerChanceLabel.TextChanged += LocalisationRandomizerChanceLabel_TextChanged;
        }

        private void LocalisationRandomizerChanceTrackBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex].RandomizerChance = localisationRandomizerChanceTrackBar.Value;
        }

        private void LocalisationRandomizerIndividualChanceTrackBar_Scroll(object sender, EventArgs e)
        {
            localisationRandomizerIndividualChanceLabel.Text = localisationRandomizerIndividualChanceTrackBar.Value.ToString();
        }

        private void LocalisationRandomizerIndividualChanceLabel_TextChanged(object sender, EventArgs e)
        {
            localisationRandomizerIndividualChanceLabel.TextChanged -= LocalisationRandomizerIndividualChanceLabel_TextChanged;
            localisationRandomizerIndividualChanceLabel.Text += '%';
            localisationRandomizerIndividualChanceLabel.TextChanged += LocalisationRandomizerIndividualChanceLabel_TextChanged;
        }

        private void LocalisationRandomizerIndividualChanceTrackBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex].RandomizerIndividualChance = localisationRandomizerIndividualChanceTrackBar.Value;
        }

        private void LocalisationLetterCountCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex].LetterCountFilterMode = localisationLetterCountCheckBox.Checked;
            localisationLetterCountMinNumeric.Enabled = localisationLetterCountCheckBox.Checked;
            localisationLetterCountMaxNumeric.Enabled = localisationLetterCountCheckBox.Checked;
        }

        private void LocalisationLetterCountMinNumeric_ValueChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex].LetterCountFilterMin = (int)localisationLetterCountMinNumeric.Value;
        }

        private void LocalisationLetterCountMaxNumeric_ValueChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex].LetterCountFilterMax = (int)localisationLetterCountMaxNumeric.Value;
        }

        private void LocalisationCorruptionEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LocalisationCorruptionEnableCheckBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!localisationCorruptionEnableCheckBox.Checked)
            {
                localisationCorruptionSettingsGroupBox.Enabled = false;
                return;
            }
            DialogResult warningWindowResult = MessageBox.Show("Corruption Mode is a fun way to completely screw up your game.\nWhile this mod may not have any lasting effects, there may be side effects if this mode is used too heavily.\nAre you sure you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (warningWindowResult == DialogResult.No)
            {
                localisationCorruptionEnableCheckBox.Checked = false;
            }
            else
            {
                localisationCorruptionSettingsGroupBox.Enabled = true;
            }
        }

        private void localisationCorruptionSwapEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationCorruptionSettings[0].Enabled = corruptionSwapEnableCheckBox.Checked;
        }

        private void localisationCorruptionSwapTrackBar_Scroll(object sender, EventArgs e)
        {
            localisationCorruptionSwapChanceLabel.Text = localisationCorruptionSwapTrackBar.Value.ToString();
            XMLInteraction.localisationCorruptionSettings[0].Probability = localisationCorruptionSwapTrackBar.Value;
        }

        private void localisationCorruptionSwapFilterButton_Click(object sender, EventArgs e)
        {
            LocalisationFilterOptionsWindow form = new LocalisationFilterOptionsWindow()
            {
                settings = XMLInteraction.localisationCorruptionSettings[0]
            };
            form.ShowDialog();
        }

        private void localisationCorruptionLanguageSettingsButton_Click(object sender, EventArgs e)
        {
            LocalisationCorruptionLanguageSettings form = new LocalisationCorruptionLanguageSettings()
            {
                settings = XMLInteraction.localisationCorruptionSettings[1]
            };
            form.ShowDialog();
        }

        private void parametersForExportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Maybe if this was a data based thing, it could be easier...
            //TODO: Review methods, and see if it's possible to select upon returning to the tab.
            if(parametersForExportList.SelectedIndex == -1)
            {
                return;
            }
            if(parametersForExportList.SelectedItem.ToString().StartsWith("Materials: "))
            {
                windowTabControls.SelectedIndex = 0;
            }
            else if (parametersForExportList.SelectedItem.ToString().StartsWith("Material Corruption: "))
            {
                windowTabControls.SelectedIndex = 0;
                materialTabControls.SelectedIndex = 1;
            }
            else if (parametersForExportList.SelectedItem.ToString().StartsWith("Localisation: "))
            {
                windowTabControls.SelectedIndex = 6;
            }
            else if (parametersForExportList.SelectedItem.ToString().StartsWith("Localisation Corruption: "))
            {
                windowTabControls.SelectedIndex = 6;
                localisationTabControls.SelectedIndex = 1;
            }
        }

        private void localisationCorruptionLanguageFilterButton_Click(object sender, EventArgs e)
        {
            LocalisationFilterOptionsWindow form = new LocalisationFilterOptionsWindow()
            {
                settings = XMLInteraction.localisationCorruptionSettings[1]
            };
            form.ShowDialog();
        }

        private void localisationCorruptionLanguageTrackBar_Scroll(object sender, EventArgs e)
        {
            localisationCorruptionLanguageChanceLabel.Text = localisationCorruptionLanguageTrackBar.Value.ToString();
            XMLInteraction.localisationCorruptionSettings[1].Probability = localisationCorruptionLanguageTrackBar.Value;
        }

        private void disableNotificationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MuteNotifs = disableNotificationsCheckBox.Checked;
        }

        private void muteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MuteSounds = muteCheckBox.Checked;
        }

        private async void materialParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            await XMLInteraction.WriteXmlParameters(completeUserDataPath); //TODO: This would be better if writing was ONLY done when a change was made to a param setting.
            DisplayMaterialParameterSettings();
        }

        private void materialParameterList_Enter(object sender, EventArgs e)
        {
            DisplayMaterialParameterSettings();
        }

        private void materialCorruptionEnableCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            //TODO: Today I learned that MouseUp isn't a good way to handle check events.
            //In the same update this was released in, I experimented with TAB selection. And I don't think I need to say more.
            //Re-evaluate the current way of selecting this.
        }

        private void launchGameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchGameOnExport = launchGameCheckBox.Checked;
        }

        private void launchGameArgumentsTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchGameArguments = launchGameArgumentsTextBox.Text;
        }

        private void importOpenFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string targetVersion = XMLInteraction.ConfirmXmlVersion(importOpenFileDialogue.FileName);
                if (targetVersion == null) 
                {
                    toolStripStatusLabel.Text = "This file is not a valid Mass Asset Editor parameter file.";
                }
                else if (targetVersion != XMLInteraction.version)
                {
                    toolStripStatusLabel.Text = string.Format("Unable to open file. File is created in {0} while the application is {1}.", targetVersion, XMLInteraction.version);
                }
                else
                {
                    ImportParametersForm form = new ImportParametersForm()
                    {
                        materialParameters = XMLInteraction.ReadXmlMaterialParameters(importOpenFileDialogue.FileName),
                        localisationParameters = XMLInteraction.ReadXmlLocalisationParameters(importOpenFileDialogue.FileName)
                    };
                    form.ShowDialog();
                    RefreshMaterialParameterList();
                    RefreshLocalisationParameterList();
                }
            }
            catch(Exception ex)
            {
                if(ex is System.Xml.XmlException)
                {
                    toolStripStatusLabel.Text = "Unable to read file: XML in file is invalid. See the Export tab for the full error message.";
                    progressBox.AppendText(ex.Message + "\r\n");
                    return;
                }
                toolStripStatusLabel.Text = "An unknown error occurred. The following exception was thrown: " + ex.GetType();
            }
        }

        private void importParametersButton_Click(object sender, EventArgs e)
        {
            importOpenFileDialogue.ShowDialog();
            
        }

        private void exportParametersButton_Click(object sender, EventArgs e)
        {
            ExportParametersForm form = new ExportParametersForm()
            {
                materialParameters = XMLInteraction.materialParametersList.ToArray(),
                localisationParameters = XMLInteraction.localisationParametersList.ToArray()
            };
            form.ShowDialog();
        }
    }
}
