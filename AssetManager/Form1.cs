﻿using Gameloop.Vdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManager
{
    public partial class Form1 : Form
    {
        public class MaterialParameterDisplayListEntry
        {
            public int Position { get; set; }
            public MaterialParameter Param { get; set; }
            public string ParamName { get; set; }
        }
        // Initialize the directories, and create them if they don't exist.
        string pathToExecutableDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Team Fortress 2";
        static public string userDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        static public string completeUserDataPath = Path.Combine(userDataPath, "Team-Fortress-2-Asset-Manager");
        static public bool exportingState = false;

        // static 
        // static public CancellationToken cancellationToken = cancellationTokenSource.Token;

        List<MaterialParameterDisplayListEntry> materialParameterDisplayList = new List<MaterialParameterDisplayListEntry>();
        
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory(completeUserDataPath);
            //try
            //{
                XMLInteraction.ReadXmlParameters(completeUserDataPath);
            //}
            //catch (FormatException e)
            //{
                toolStripStatusLabel1.Text = "There was an error when loading the parameter file.";
                progressBox.AppendText("An error has occurred when parsing the parameters: " + e.Source);
            //}
            RefreshMaterialParameterList();
            saveFileLocationText.Text = saveFileDialog1.InitialDirectory;
            saveFileDialog1.FileName = saveFileDialog1.InitialDirectory;
            VPKInteraction.ReadVpk(Path.Combine(pathToExecutableDirectory, "tf\\tf2_misc_dir.vpk"));
            gameLocationText.Text = pathToExecutableDirectory;
            if (!confirmValidGame())
            {
                toolStripStatusLabel1.Text = "Warning: gameinfo.txt not present in specified directory. Please confirm the location to the \"tf\" folder in the Export tab.";
            }
        }

        public bool confirmValidGame()
        {
            if (!string.IsNullOrEmpty(pathToExecutableDirectory) && File.Exists(Path.Combine(pathToExecutableDirectory, "tf\\gameinfo.txt")))
            { return true; }
            else
            { return false; }
        }

        //Oh no.

        // public TreeView populateVpkDirectoryListing()
        // {
        //     TreeNode lastNode = null;
        //     TreeView result = new TreeView();
        //     string subPathAgg;
        //     foreach (string directory in VPKInteraction.vpkContents)
        //     {
        //         subPathAgg = string.Empty;
        //         foreach (string subPath in directory.Split('/'))
        //         {
        //             subPathAgg += subPath + '/';
        //             TreeNode[] nodes = result.Nodes.Find(subPathAgg, false);
        //             if (nodes.Length == 0)
        //             {
        //                 if (lastNode == null)
        //                 {
        //                     lastNode = result.Nodes.Add(subPathAgg, subPath);
        //                 }
        //                 else
        //                 {
        //                     lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
        //                 }
        //             }
        //             else
        //             {
        //                 lastNode = nodes[0];
        //             }
        //         }
        //     }
        //     return result;
        // }

        public void RefreshMaterialParameterList()
        {
            materialParameterDisplayList.Clear();
            foreach (MaterialParameter param in XMLInteraction.MaterialParametersArrayList)
            {
                materialParameterDisplayList.Add(new Form1.MaterialParameterDisplayListEntry() { Position = materialParameterDisplayList.Count, Param = param, ParamName = param.ParamName });
            }
            materialParameterList.DataSource = null;
            materialParameterList.DataSource = materialParameterDisplayList;
            materialParameterList.DisplayMember = "ParamName";
            materialParameterList.ValueMember = "Position";
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            progressBox.Clear();
            if(!confirmValidGame())
            {
                toolStripStatusLabel1.Text = "ERROR: Cannot export. gameinfo.txt not present in specified directory. Please confirm the location to the \"tf\" folder in the Export tab.";
                return;
            }
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(saveFileDialog1.FileName)))
                {
                    progressBox.AppendText("ERROR: Tne export directory is not accessible.");
                    return;
                }
            }
            catch (ArgumentException)
            {
                progressBox.AppendText("ERROR: Tne export directory is not accessible.");
                return;
            }
            //XMLInteraction.ImplementDefaultParameters();
            //XMLInteraction.ReadXmlParameters(completeUserDataPath);
            for (var i = 0; i <= (materialParameterList.Items.Count - 1); i++)
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
                progressBox.AppendText("No parameters have been selected.");
                return;
            }
            DirectoryInfo path = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileNameWithoutExtension(saveFileDialog1.FileName)));
            string tempFileLocation = Path.Combine(Path.GetTempPath(), "TF2AssetManager", Path.GetFileName(saveFileDialog1.FileName));
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            if (exportingState)
            {
                //progressBox.AppendText("Cancelling operation. Please wait...\r\n");
                //cancellationTokenSource.Cancel(); //Cancel immediately.
            }
            else
            {
                button1.Text = "Abort Packaging";
            }
            exportingState = true;
            progressBox.AppendText("Searching for files in the TF2 assets...\r\n");
            Dictionary<string, string> returnedData;
            try
            {
                returnedData = await Task.Run(() => VPKInteraction.ExtractSpecificFileTypeFromVPK(Path.Combine(pathToExecutableDirectory, "tf\\tf2_misc_dir.vpk"), "vmt", token), token);
            }
            catch (OperationCanceledException)
            {
                OperationCancelled();
                ClearAllTempFiles(path, tempFileLocation);
                return;
            }
            progressBox.AppendText("Found " + returnedData.Count + " assets to edit.\r\n");
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
            }
            catch (IOException)
            {
                progressBox.AppendText("ERROR: The file is already in use by another process. Please close the process that is using this file.\r\n");
            }
            progressBox.AppendText("Operation complete.\r\n");
            ClearAllTempFiles(path, tempFileLocation);
            exportingState = false;
            button1.Text = "Begin Packaging";
        }
        private void OperationCancelled()
        {
            if(!exportingState)
            {
                return; //HACK: Don't print out any more or show anything else.
            }
            progressBox.AppendText("The operation was cancelled.");
            exportingState = false;
            button1.Text = "Begin Packaging";
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
        private async void MaterialParameterList_ItemCheck(object sender, ItemCheckEventArgs e) //Move all these to a selection event once select w/o ticking becomes possible.
        {
            await XMLInteraction.WriteXmlParameters(completeUserDataPath);
            overwriteModeComboBox.SelectedIndex = materialParameterDisplayList[e.Index].Param.ParamForce;
            randomizerOffsetNumeric.DecimalPlaces = 7;
            deviationSettingsParam1Label.Text = "Parameter Random Deviation";
            deviationSettingsParam2Label.Hide();
            deviationSettingsParam3Label.Hide();
            randomizerOffsetNumeric2.Hide();
            randomizerOffsetNumeric3.Hide();
            if (materialParameterDisplayList[e.Index].Param.ParamType == "integer") //Consider case.
            {
                randomizerOffsetNumeric.DecimalPlaces = 0;
                deviationSettingsGroupBox.Show();
            }
            else if (materialParameterDisplayList[e.Index].Param.ParamType == "bool"
                     || materialParameterDisplayList[e.Index].Param.ParamType == "proxy")
            {
                deviationSettingsGroupBox.Hide();
            }
            else if (materialParameterDisplayList[e.Index].Param.ParamType.Contains("vector3"))
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
            randomizerChanceNumeric.Value = materialParameterDisplayList[e.Index].Param.RandomizerChance;
            randomizerOffsetNumeric.Value = (decimal)materialParameterDisplayList[e.Index].Param.RandomizerOffset;
            parameterSettingsGroupBox.Show();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Parent = this;
            f2.ShowDialog(); 
        }

        private void MaterialParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            if (confirmValidGame())
            {
                gameLocationValidLabel.Text = "gameinfo.txt found.";
            }
            else
            {
                gameLocationValidLabel.Text = "gameinfo.txt missing.";
            }
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
            if(confirmValidGame())
            {
                gameLocationValidLabel.Text = "gameinfo.txt found.";
            }
            else
            {
                gameLocationValidLabel.Text = "gameinfo.txt missing.";
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameLocationText_LostFocus(null, null);
            SaveFileLocationText_Leave(null, null);
            OpenFileDialog1_FileOk(null, null);
        }

        private void RandomizerChanceNumeric_ValueChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerChance = (int)randomizerChanceNumeric.Value;
        }

        private void RandomizerOffsetNumeric_ValueChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerOffset = (float)randomizerOffsetNumeric.Value;
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await XMLInteraction.WriteXmlParameters(completeUserDataPath);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // vpkDirectoryListing.CheckBoxes = false;
            // vpkDirectoryListing.Nodes.Add("Please wait...");
            // TreeView directories = await Task.Run(() => populateVpkDirectoryListing());
            // vpkDirectoryListing.Nodes.Clear();
            // vpkDirectoryListing.Nodes.Add(directories.Nodes[0]);
        }

        private void OverwriteModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamForce = overwriteModeComboBox.SelectedIndex;
        }

        private void RandomizerOffsetNumeric2_ValueChanged(object sender, EventArgs e)
        {
            if(XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamType.Contains("vector3"))
            {
                XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerOffset = (float)randomizerOffsetNumeric.Value;
            }
        }

        private void RandomizerOffsetNumeric3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ExcludedShadersButton_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.parameterName = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamName;
            f4.ShowDialog();
        }

        private List<string> ModifyVmtData(Dictionary<string, string> returnedData, DirectoryInfo exportPath, CancellationToken ct)
        {
            List<string> errorList = new List<string>();
            foreach (var a in returnedData)
            {
                try
                {
                    VdfSerializerSettings settings = new VdfSerializerSettings();
                    settings.UsesEscapeSequences = false;
                    dynamic conversion = VdfConvert.Deserialize(returnedData[a.Key], settings);
                    Random randomNumGenerator = new Random();
                    for (var i = 0; i <= (materialParameterList.Items.Count - 1); i++)
                    {
                        if (materialParameterList.GetItemChecked(i))
                        {
                            MaterialParameterDisplayListEntry value = materialParameterList.Items[i] as MaterialParameterDisplayListEntry;
                            if (value.Param.RandomizerChance != 100 && randomNumGenerator.Next(1, 101) >= value.Param.RandomizerChance + 1) //Confirm this is accurate..?
                            {
                                continue;
                            }
                            bool shaderFilterFailed = false;
                            foreach(string shaderFilter in value.Param.ShaderFilterArray)
                            {
                                Console.WriteLine(conversion.Key);
                                if(conversion.Key = shaderFilter)
                                {
                                    shaderFilterFailed = true;
                                    break;
                                }
                            }
                            if(shaderFilterFailed)
                            {
                                continue;
                            }
                            float valueOffset = value.Param.RandomizerOffset;
                            if (value.Param.RandomizerOffset != 0.0f)
                            {
                                valueOffset = (float)randomNumGenerator.NextDouble() * (valueOffset - (valueOffset * -1)) + (valueOffset * -1);
                            }
                            switch (value.Param.ParamType)
                            {
                                case "vector3-float":
                                    VMTInteraction.InsertVector3IntoMaterial(conversion,
                                                                             value.Param.Parameter,
                                                                             VMTInteraction.ConvertStringToVector3Float(value.Param.ParamValue));
                                    break;
                                case "vector3-integer":
                                case "vector3-color":
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
                                case "bool":
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
                                    conversion = VMTInteraction.InsertProxyIntoMaterial(conversion, value.Param.Parameter, value.Param.ProxyParameterArray);
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
                    catch (System.IO.FileNotFoundException)
                    {
                        errorList.Add("The file " + a.Key + " could not be modified since the file path is too long.\r\n");
                    }
                }
                catch (Gameloop.Vdf.VdfException)
                {
                    errorList.Add("The file " + a.Key + " could not be modified due to an faulty data structure.\r\n");
                }
            }
            ct.ThrowIfCancellationRequested();
            return errorList;
        }
    }
}
