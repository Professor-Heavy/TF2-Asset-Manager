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
        string pathToExecutableDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Team Fortress 2";
        static public string userDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        static public string completeUserDataPath = Path.Combine(userDataPath, "Team-Fortress-2-Asset-Manager");
        static public bool exportingState = false;

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
            saveFileLocationText.Text = saveFileDialog1.InitialDirectory;
            saveFileDialog1.FileName = saveFileDialog1.InitialDirectory;
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
                    progressBox.AppendText("ERROR: Tne export directory is not accessible.");
                    PlayResultSound(ExportState.ErrorFatal);
                    return;
                }
            }
            catch (ArgumentException)
            {
                progressBox.AppendText("ERROR: Tne export directory is not accessible.");
                PlayResultSound(ExportState.ErrorFatal);
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
                        progressBox.AppendText("Parameter " + param.ParamName + " has been deselected.\r\n");
                        materialParameterList.SetItemChecked(i, false);
                    }
                }
            }
            if (materialParameterList.CheckedItems.Count == 0)
            {
                progressBox.AppendText("ERROR: No parameters have been selected.");
                PlayResultSound(ExportState.ErrorFatal);
                return;
            }

            ////
            ////
            ////BEGIN
            ////
            ////
            ///
            PlayResultSound(ExportState.Begin);
            bool useCustomFiles = customFilesCheckBox.Checked;
            DirectoryInfo path = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileNameWithoutExtension(saveFileDialog1.FileName)));
            string tempFileLocation = Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileName(saveFileDialog1.FileName));
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            if (exportingState)
            {
                progressBox.AppendText("I've started, so I'll finish.\r\n");
                //cancellationTokenSource.Cancel(); //Cancel immediately.
            }
            else
            {
                startPackagingButton.Text = "Abort Packaging";
            }
            exportingState = true;
            progressBox.AppendText("Searching for files in the TF2 assets...\r\n");
            Dictionary<string, string> returnedData;
            try
            {
                returnedData = await Task.Run(() => VPKInteraction.ExtractSpecificFileTypeFromVPK(Path.Combine(pathToExecutableDirectory, "tf\\tf2_misc_dir.vpk"), "vmt", token), token);
                progressBox.AppendText("Found " + returnedData.Count + " assets to edit.\r\n");
                if (useCustomFiles)
                {
                    List<string> includedCustomFiles = new List<string>();
                    foreach (string itemChecked in customFileCheckList.CheckedItems)
                    {
                        includedCustomFiles.Add(itemChecked);
                    }
                    Dictionary<string, string> customReturnedData = await Task.Run(() =>
                    VPKInteraction.ExtractSpecificFileTypesFromCustomDirectory(Path.Combine(pathToExecutableDirectory, "tf\\custom"), "vmt", includedCustomFiles, token), token);
                    foreach(var customFile in customReturnedData)
                    {
                        if(returnedData.ContainsKey(customFile.Key)) //TODO: This is a large dictionary. Is this a good idea?
                        {
                            progressBox.AppendText("Found custom file: " + customFile.Key + ". This custom file has overwritten another asset.\r\n");
                            returnedData[customFile.Key] = customFile.Value;
                        }
                        else
                        {
                            progressBox.AppendText("Found custom file: " + customFile.Key + ".\r\n");
                            returnedData.Add(customFile.Key, customFile.Value); //TODO: Maybe use enumerables...
                        }
                    }
                    Dictionary<string, string> customReturnedDataFromVpk = new Dictionary<string, string>();
                    string[] files = Directory.GetFiles(Path.Combine(pathToExecutableDirectory, "tf\\custom"), "*.vpk");
                    foreach (string file in files)
                    {
                        if(includedCustomFiles.Contains(Path.GetFileName(file)))
                        {
                            Dictionary<string, string> extractedVpk = VPKInteraction.ExtractSpecificFileTypeFromVPK(file, "vmt", token);
                            foreach (var customFile in extractedVpk)
                            {
                                if (returnedData.ContainsKey(customFile.Key)) //TODO: This is a large dictionary. Is this a good idea?
                                {
                                    progressBox.AppendText("Found custom file: " + customFile.Key + " in a VPK. This custom file has overwritten another asset.\r\n");
                                    returnedData[customFile.Key] = customFile.Value;
                                }
                                else
                                {
                                    progressBox.AppendText("Found custom file: " + customFile.Key + " in a VPK.\r\n");
                                    returnedData.Add(customFile.Key, customFile.Value); //TODO: Maybe use enumerables...
                                }
                            }
                        }
                    }
                    progressBox.AppendText("Found " + customReturnedData.Count + " custom assets (Excluding VPKs).\r\n");
                    //TODO: Maybe instead of creating two different functions for VPKs and folders... Merge them?
                }
            }
            catch (OperationCanceledException)
            {
                OperationCancelled();
                ClearAllTempFiles(path, tempFileLocation);
                return;
            }
            List<string> returnedErrors;
            try
            {
                returnedErrors = await Task.Run(() => ModifyVmtData(returnedData, path, token), token);
            }
            catch (OperationCanceledException)
            {
                OperationCancelled();
                ClearAllTempFiles(path, tempFileLocation);
                return;
            }
            foreach (string error in returnedErrors)
            {
                progressBox.AppendText(error);
            }
            progressBox.AppendText("Packaging file to VPK.\r\n");
            string vpkResult;
            try
            {
                vpkResult = await Task.Run(() => VPKInteraction.PackageToVpk(pathToExecutableDirectory, path, token), token);
            }
            catch (OperationCanceledException)
            {
                OperationCancelled();
                ClearAllTempFiles(path, tempFileLocation);
                return;
            }
            progressBox.AppendText(vpkResult);
            try
            {
                File.Delete(saveFileDialog1.FileName);
                File.Move(tempFileLocation, saveFileDialog1.FileName);
                PlayResultSound(ExportState.Success);
            }
            catch (IOException)
            {
                progressBox.AppendText("ERROR: The file is already in use by another process. Please close the process that is using this file.\r\n");
                PlayResultSound(ExportState.ErrorFatal);
            }
            progressBox.AppendText("Operation complete.\r\n");
            ClearAllTempFiles(path, tempFileLocation);
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
            saveFileLocationText.Text = saveFileDialog1.FileName;
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
            saveFileDialog1.FileName = saveFileLocationText.Text;
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

            TreeView directories = await Task.Run(() => PopulateVpkDirectoryListing(vpkDirectoryListing, 0, null));
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

        private List<string> ModifyVmtData(Dictionary<string, string> returnedData, DirectoryInfo exportPath, CancellationToken ct)
        {
            List<string> errorList = new List<string>();
            foreach (var a in returnedData)
            {
                try
                {
                    VdfSerializerSettings settings = new VdfSerializerSettings
                    {
                        UsesEscapeSequences = false
                    };
                    dynamic conversion = VdfConvert.Deserialize(returnedData[a.Key], settings);
                    Random randomNumGenerator = new Random();
                    for (var i = 0; i <= (materialParameterList.Items.Count - 1); i++)
                    {
                        if (materialParameterList.GetItemChecked(i))
                        {
                            MaterialParameterDisplayListEntry value = materialParameterList.Items[i] as MaterialParameterDisplayListEntry;
                            if (!TestForFilteredShaders(value.Param.ShaderFilterMode, conversion, value.Param.ShaderFilterArray))
                            {
                                continue;
                            }
                            if (!TestForFilteredProxies(value.Param.ProxyFilterMode, conversion, value.Param.ProxyFilterArray))
                            {
                                continue;
                            }
                            if (value.Param.RandomizerChance != 100
                                && randomNumGenerator.Next(1, 101) >= value.Param.RandomizerChance + 1) //Confirm this is accurate..?
                            {
                                continue;
                            }
                            
                            float valueOffset = value.Param.RandomizerOffset;
                            if (value.Param.RandomizerOffset != 0.0f)
                            {
                                valueOffset *= (float)(randomNumGenerator.NextDouble() * 2.0 - 1.0);
                            }
                            switch (value.Param.ParamType.ToString())
                            {
                                //TODO: Interpret float values
                                //case "vector3-float":
                                //    VMTInteraction.InsertVector3IntoMaterial(conversion,
                                //                                             value.Param.Parameter,
                                //                                             VMTInteraction.ConvertStringToVector3Float(value.Param.ParamValue));
                                //    break;
                                case "vector3":
                                    if (value.Param.Parameter == "$color" || value.Param.Parameter == "$color2")
                                    {
                                        conversion = VMTInteraction.InsertVector3IntoMaterial(conversion,
                                                                                              VMTInteraction.PerformColorChecks(conversion.Key),
                                                                                              VMTInteraction.ConvertStringToVector3Int(value.Param.ParamValue));
                                    }
                                    else
                                    {
                                        conversion = VMTInteraction.InsertVector3IntoMaterial(conversion,
                                                                                              value.Param.Parameter,
                                                                                              VMTInteraction.ConvertStringToVector3Int(value.Param.ParamValue));
                                    }
                                    break;
                                case "boolean":
                                    conversion = VMTInteraction.InsertValueIntoMaterial(conversion, value.Param.Parameter, Int32.Parse(value.Param.ParamValue));
                                    break;
                                case "integer":
                                    conversion = VMTInteraction.InsertValueIntoMaterial(conversion, value.Param.Parameter, Int32.Parse(value.Param.ParamValue) + (int)Math.Ceiling(valueOffset));
                                    break;
                                case "string":
                                    conversion = VMTInteraction.InsertValueIntoMaterial(conversion, value.Param.Parameter, value.Param.ParamValue);
                                    break;
                                case "float":
                                    conversion = VMTInteraction.InsertValueIntoMaterial(conversion, value.Param.Parameter, float.Parse(value.Param.ParamValue + valueOffset));
                                    break;
                                case "proxy":
                                    conversion = VMTInteraction.InsertProxyIntoMaterial(conversion, value.Param.Parameter, value.Param.ParamValue);
                                    break;
                                case "choices":
                                    conversion = VMTInteraction.InsertRandomChoiceIntoMaterial(conversion, value.Param.Parameter, value.Param.ParamValue);
                                    break;
                                default:
                                    break; //Unimplemented type.
                            }
                        }
                    }
                    DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Path.Combine(exportPath.FullName, a.Key)));
                    di.Create();
                    try
                    {
                        File.AppendAllText(Path.Combine(exportPath.FullName, a.Key), VdfConvert.Serialize(conversion, settings));
                    }
                    catch (FileNotFoundException)
                    {
                        errorList.Add("The file " + a.Key + " could not be modified since the file path is too long.\r\n");
                    }
                }
                catch (VdfException)
                {
                    errorList.Add("The file " + a.Key + " could not be modified due to an faulty data structure.\r\n");
                }
            }
            ct.ThrowIfCancellationRequested();
            return errorList;
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

        private bool TestForFilteredShaders(int filterMode, dynamic materialFile, List<string> shaderFilterArray)
        {
            foreach (string shaderFilter in shaderFilterArray)
            {
                //HACK: FilterMode == 0 returns false
                //materialFile.Key.Equals(shaderFilter, StringComparison.OrdinalIgnoreCase) compares the two regardless of case.
                if (materialFile.Key.Equals(shaderFilter, StringComparison.OrdinalIgnoreCase) == (filterMode == 0)) 
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Performs a test on a materialFile to see if a proxy exists, and returns the result of the filter. TODO: Simplify.
        /// </summary>
        /// <param name="filterMode">Set to 0 if it should NOT be used, set to 1 if it SHOULD ONLY be used.</param>
        /// <param name="materialFile"></param>
        /// <param name="proxyFilterArray"></param>
        /// <returns>True if the parameter be included, false if not.</returns>
        private bool TestForFilteredProxies(int filterMode, dynamic materialFile, List<string> proxyFilterArray) //Any possible simplifications?
        {
            if (filterMode == 0)
            {
                foreach (string proxyFilter in proxyFilterArray)
                {
                    if (VMTInteraction.ContainsProxy(materialFile, proxyFilter))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (string proxyFilter in proxyFilterArray)
                {
                    if (VMTInteraction.ContainsProxy(materialFile, proxyFilter))
                    {
                        return true;
                    }
                }
                return false;
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

        private void PlayResultSound(ExportState result)
        {
            string soundLocation = Path.Combine(Environment.CurrentDirectory, "sounds");
            SoundPlayer player = null;
            NotifyIcon notif = new NotifyIcon
            {
                Icon = Icon,
                BalloonTipTitle = "Team Fortress 2 Asset Manager",
                Visible = true
            };

            switch (result)
            {
                case ExportState.Begin:
                    notif.BalloonTipText = "Exporting has started.";
                    player = new SoundPlayer(Path.Combine(soundLocation, "begin.wav"));
                    break;
                case ExportState.Error:
                case ExportState.ErrorFatal:
                    notif.BalloonTipText = "A fatal error has occurred. Please see the application for details.";
                    player = new SoundPlayer(Path.Combine(soundLocation, "error.wav"));
                    break;
                case ExportState.Success:
                    notif.BalloonTipText = "Exporting has finished.";
                    player = new SoundPlayer(Path.Combine(soundLocation, "success.wav"));
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
            if(!this.ContainsFocus)
            {
                notif.ShowBalloonTip(5000);
            }
            else
            {
                notif.Dispose();
            }
            //HACK: https://stackoverflow.com/questions/13373060/show-a-balloon-notification#comment89015772_34956412
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
                return;
            }
            DialogResult warningWindowResult = MessageBox.Show("Corruption Mode is a fun way to completely screw up your game.\nWhile this mod may not have any lasting effects, there may be side effects if this mode is used too heavily.\nAre you sure you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (warningWindowResult == DialogResult.No)
            {
                materialCorruptionEnableCheckBox.Checked = false;
            }
        }

        private void CorruptionModeEnabled()
        {

        }

        private void RandomizerScrollBarChanged(object sender, KeyEventArgs e)
        {

        }
    }
}
