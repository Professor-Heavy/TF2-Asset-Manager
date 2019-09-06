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

        public enum ExportState
        {
            Begin,
            Success,
            Error,
            ErrorFatal
        }

        // Initialize the directories, and create them if they don't exist.
        string pathToExecutableDirectory = Properties.Settings.Default.GameLocation;
        static public string userDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        static public string completeUserDataPath = Path.Combine(userDataPath, "Team-Fortress-2-Asset-Manager");
        static public bool exportingState = false;

        public MaterialCorruptionSettings materialCorruptionSettings = new MaterialCorruptionSettings();

        // static 
        // static public CancellationToken cancellationToken = cancellationTokenSource.Token;
        
        List<MaterialParameterDisplayListEntry> materialParameterDisplayList = new List<MaterialParameterDisplayListEntry>();
        
        public MainWindow()
        {
            InitializeComponent();
            Directory.CreateDirectory(completeUserDataPath);
            //List<string> errorList;
            //if (errorList.Count > 0)
            //{
            //    toolStripStatusLabel1.Text = "Errors were encountered while loading the parameter configuration file. See the Export tab for more info.";
            //    foreach(string error in errorList)
            //    {
            //        progressBox.AppendText(error + "\r\n");
            //    }
            //}
            saveFileLocationText.Text = Properties.Settings.Default.VpkLocation;
            saveFileDialog1.FileName = Properties.Settings.Default.VpkLocation;
            VPKInteraction.ReadVpk(Path.Combine(pathToExecutableDirectory, "tf\\tf2_misc_dir.vpk"));
            gameLocationText.Text = pathToExecutableDirectory;
            if (!ConfirmValidGame())
            {
                toolStripStatusLabel1.Text = "Warning: gameinfo.txt not present in specified directory. Please confirm the location to the \"tf\" folder in the Export tab.";
            }
            else
            {
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
            foreach (MaterialParameter param in XMLInteraction.MaterialParametersArrayList)
            {
                materialParameterDisplayList.Add(new MaterialParameterDisplayListEntry() { Position = materialParameterDisplayList.Count, Param = param, ParamName = param.ParamName });
            }
            materialParameterList.DataSource = null;
            materialParameterList.DataSource = materialParameterDisplayList;
            materialParameterList.DisplayMember = "ParamName";
            materialParameterList.ValueMember = "Position";
        }


        private async void StartPackagingButton_Click(object sender, EventArgs e)
        {
            progressBox.Clear();
            if(!ConfirmValidGame())
            {
                toolStripStatusLabel1.Text = "ERROR: Cannot export. gameinfo.txt not present in specified directory. Please confirm the location to the \"tf\" folder in the Export tab.";
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
                            progressBox.AppendText("WARNING: Parameter " + param.ParamName + " is missing required settings. Please check the parameter settings for more info and try again.\r\n");
                        }
                        if (result == 1)
                        {
                            progressBox.AppendText("WARNING: Parameter " + param.ParamName + " is of type " + param.ParamType + "but the value is " + param.ParamValue + ". Please check the parameter settings and try again.\r\n");
                        }
                        WriteMessage("Parameter " + param.ParamName + " has been deselected.\r\n");
                        materialParameterList.SetItemChecked(i, false);
                    }
                }
            }
            if (materialParameterList.CheckedItems.Count == 0)
            {
                WriteMessage("ERROR: No parameters have been selected.", ExportState.ErrorFatal);
                return;
            }

            if (exportingState)
            {
                progressBox.AppendText("I've started, so I'll finish.\r\n");
                //cancellationTokenSource.Cancel(); //Cancel immediately.
            }
            else
            {
                startPackagingButton.Text = "Abort Packaging";
            }


            ////
            ////
            ////BEGIN
            ////
            ////
            ////

            DirectoryInfo exportPath = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileNameWithoutExtension(Properties.Settings.Default.VpkLocation)));
            string tempFileLocation = Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileName(saveFileDialog1.FileName));
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            exportingState = true;

            
            List<string> includedCustomFiles = new List<string>();
            foreach (string itemChecked in customFileCheckList.CheckedItems)
            {
                includedCustomFiles.Add(itemChecked);
            }

            WriteMessage("Searching for files in the TF2 assets...", ExportState.Begin);
            ExportProcess.Export(pathToExecutableDirectory, customFilesCheckBox.Checked, includedCustomFiles, this);
            try
            {
                File.Delete(saveFileDialog1.FileName);
                File.Move(tempFileLocation, saveFileDialog1.FileName);
                WriteMessage("Operation complete.",ExportState.Success, "Export complete.");
            }
            catch (IOException)
            {
                WriteMessage("ERROR: The file is already in use by another process. Please close the process that is using this file.", ExportState.ErrorFatal, "An error has occurred during exporting. The target export file already exists, and cannot be written over.");
            }
            ClearAllTempFiles(exportPath, tempFileLocation);
            exportingState = false;
            startPackagingButton.Text = "Begin Packaging";
        }
        private void OperationCancelled()
        {
            if(!exportingState)
            {
                return; //HACK: Don't print out any more or show anything else.
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

        private void ManageParameterButton_Click(object sender, EventArgs e)
        {
            ManageParametersWindow f2 = new ManageParametersWindow
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
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (Directory.Exists(openFileDialog1.FileName))
            {
                gameLocationText.Text = openFileDialog1.FileName;
                pathToExecutableDirectory = openFileDialog1.FileName;
            }
            else
            {
                gameLocationText.Text = Path.GetDirectoryName(openFileDialog1.FileName);
                pathToExecutableDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
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
                    openFileDialog1.FileName = gameLocationText.Text;
                    pathToExecutableDirectory = openFileDialog1.FileName;
                }
                else
                {
                    openFileDialog1.FileName = Path.GetDirectoryName(gameLocationText.Text);
                    pathToExecutableDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
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
            OpenFileDialog1_FileOk(null, null);
        }

        private void RandomizerOffsetNumeric_ValueChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerOffset = (float)randomizerOffsetNumeric.Value;
        }

        private async void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            await XMLInteraction.WriteXmlParameters(completeUserDataPath);
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            await XMLInteraction.VerifyXMLIntegrity(completeUserDataPath);
            XMLInteraction.ReadXmlParameters(completeUserDataPath);
            RefreshMaterialParameterList();

            //TreeView directories = await Task.Run(() => PopulateVpkDirectoryListing(vpkDirectoryListing, 0, null));
            // vpkDirectoryListing.Nodes.Clear();
            // vpkDirectoryListing.Nodes.AddRange(directories)
        }

        private void OverwriteModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamForce = overwriteModeComboBox.SelectedIndex;
        }

        private void RandomizerOffsetNumeric2_ValueChanged(object sender, EventArgs e)
        {
            // if(XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamType.ToString().Contains("vector3"))
            // {
            //     XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerOffset = (float)randomizerOffsetNumeric.Value;
            // }
        }

        private void RandomizerOffsetNumeric3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ExcludedShadersButton_Click(object sender, EventArgs e)
        {
            ShaderFiltersWindow form = new ShaderFiltersWindow
            {
                parameterInfo = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex]
            };
            form.ShowDialog();
        }

        private async void MaterialParameterList_MouseClick(object sender, MouseEventArgs e)
        {
            //HACK: https://stackoverflow.com/a/4579701
            if ((e.Button == MouseButtons.Left) & (e.X > 13))
            {
                MaterialParameter selectedParameter = materialParameterDisplayList[materialParameterList.SelectedIndex].Param;
                materialParameterList.SetItemChecked(this.materialParameterList.SelectedIndex, !this.materialParameterList.GetItemChecked(this.materialParameterList.SelectedIndex));
                await XMLInteraction.WriteXmlParameters(completeUserDataPath);
                overwriteModeComboBox.SelectedIndex = selectedParameter.ParamForce;
                randomizerOffsetNumeric.DecimalPlaces = 7;
                deviationSettingsParam1Label.Text = "Parameter Random Deviation";
                deviationSettingsParam2Label.Hide();
                deviationSettingsParam3Label.Hide();
                randomizerOffsetNumeric2.Hide();
                randomizerOffsetNumeric3.Hide();
                if (selectedParameter.ParamType.ToString() == "integer") //Consider case.
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
                    toolStripStatusLabel1.Text = "Vector3 randomization is currently unimplemented. These settings will not be saved.";
                    deviationSettingsParam1Label.Text = "Parameter 1 Random Deviation";
                    deviationSettingsParam1Label.Show();
                    deviationSettingsParam2Label.Show();
                    deviationSettingsParam3Label.Show();
                    randomizerOffsetNumeric.Show();
                    randomizerOffsetNumeric2.Show();
                    randomizerOffsetNumeric3.Show();
                }
                randomizerChanceLabel.Text = selectedParameter.RandomizerChance.ToString();
                randomizerChanceTrackBar.Value = selectedParameter.RandomizerChance;
                randomizerOffsetNumeric.Value = (decimal)selectedParameter.RandomizerOffset;
                parameterSettingsGroupBox.Show();
            }
        }

        private void RandomizerScrollBarChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerChance = randomizerChanceTrackBar.Value;
        }

        private void RandomizerChanceTrackBar_Scroll(object sender, EventArgs e)
        {
            randomizerChanceLabel.Text = randomizerChanceTrackBar.Value.ToString();
        }

        private void RandomizerChanceLabel_TextChanged(object sender, EventArgs e)
        {
            //Is there a better way to handle this instead of reattaching the event?
            randomizerChanceLabel.TextChanged -= RandomizerChanceLabel_TextChanged;
            randomizerChanceLabel.Text += '%';
            randomizerChanceLabel.TextChanged += RandomizerChanceLabel_TextChanged;
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

        /// <summary>
        /// Writes a string message in the progress text box.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public void WriteMessage(string message)
        {
            progressBox.AppendText(message);
            progressBox.AppendText("\r\n");
        }

        /// <summary>
        /// Writes a string message in the progress text box, playing a sound as well.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        public void WriteMessage(string message, ExportState severity)
        {
            progressBox.AppendText(message);
            progressBox.AppendText("\r\n");
            PlayNotificationSound(severity);
        }

        /// <summary>
        /// Writes a string message in the progress text box, playing a sound and displaying a notifiation.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        public void WriteMessage(string message, ExportState severity, string balloonMessage)
        {
            progressBox.AppendText(message);
            progressBox.AppendText("\r\n");
            PlayNotificationSound(severity);
            DisplayNotificationBalloon(balloonMessage);
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
                parameterInfo = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex]
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
            }
        }

        private void CorruptionModeEnabled()
        {

        }

        private void RandomizerScrollBarChanged(object sender, KeyEventArgs e)
        {
            //XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerChance = randomizerChanceTrackBar.Value;
        }

        private void CorruptionSwapFilterButton_Click(object sender, EventArgs e)
        {
            FilterOptionsWindow form = new FilterOptionsWindow();
            form.ShowDialog();
        }

        private void CorruptionSwapTrackBar_Scroll(object sender, EventArgs e)
        {
            corruptionSwapChanceLabel.Text = corruptionSwapTrackBar.Value.ToString();
            materialCorruptionSettings.Probability = corruptionSwapTrackBar.Value;
        }

        private void CorruptionSwapChanceLabel_TextChanged(object sender, EventArgs e)
        {
            corruptionSwapChanceLabel.TextChanged -= CorruptionSwapChanceLabel_TextChanged;
            corruptionSwapChanceLabel.Text += '%';
            corruptionSwapChanceLabel.TextChanged += CorruptionSwapChanceLabel_TextChanged;
        }

        private void CorruptionSwapEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            materialCorruptionSettings.Enabled = corruptionSwapEnableCheckBox.Checked;
        }
    }
}
