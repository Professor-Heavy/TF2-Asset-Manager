using Gameloop.Vdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using Gameloop.Vdf.Linq;
using System.Collections;

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
        // readonly DirectoryInfo settingsDirectory = Directory.CreateDirectory(completeUserDataPath);
        // Uncomment this with the directory deleted as a test

        List<MaterialParameterDisplayListEntry> materialParameterDisplayList = new List<MaterialParameterDisplayListEntry>();
        public Form1()
        {
            InitializeComponent();
            XMLInteraction.ReadXmlParameters(completeUserDataPath);
            RefreshMaterialParameterList();
            saveFileLocationText.Text = saveFileDialog1.InitialDirectory;
            saveFileDialog1.FileName = saveFileDialog1.InitialDirectory;
            VPKInteraction.readVpk(Path.Combine(pathToExecutableDirectory, "tf\\tf2_misc_dir.vpk"));
            gameLocationText.Text = pathToExecutableDirectory;
            //vpkDirectoryListing.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
            if(!confirmValidGame())
            {
                toolStripStatusLabel1.Text = "Warning: gameinfo.txt not present in specified directory. Please confirm the location to the \"tf\" folder in the Export tab.";
            }
        }

        public bool confirmValidGame()
        {
            Console.WriteLine(pathToExecutableDirectory);
            if (!string.IsNullOrEmpty(pathToExecutableDirectory) && File.Exists(Path.Combine(pathToExecutableDirectory, "tf\\gameinfo.txt")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public TreeNode populateVpkDirectoryListing(List<DirectoryInfo> directoryInfoList)
        //{
        //    var directoryNode = new TreeNode(directoryInfo.Name);
        //    foreach (var directory in VPKInteraction.vpkContents)
        //    {
        //        directoryNode.Nodes.Add(CreateDirectoryNode(directory));
        //    }
        //    foreach (var file in directoryInfo.GetFiles())
        //    {
        //        directoryNode.Nodes.Add(new TreeNode(file.Name));
        //    }
        //}

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

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
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
            button1.Enabled = false;
            progressBox.AppendText("Searching for files in the TF2 assets...\r\n");
            var returnedData = VPKInteraction.extractSpecificFileTypeFromVPK(Path.Combine(pathToExecutableDirectory, "tf\\tf2_misc_dir.vpk"), "vmt");
            progressBox.AppendText("Found " + returnedData.Count + " assets to edit.\r\n");
            DirectoryInfo path = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(saveFileDialog1.FileName)));
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
                                default:
                                    break; //Unimplemented type.
                            }
                        }
                    }
                    // The following is the AddProxy thing I made for the pulsing rainbows. Use it as basis.
                    //
                    // if(materialParameterList.GetItemChecked(1)) 
                    // {
                    //     int[] colorArray = { 0, 0, 0 };
                    //     List<KeyValuePair<string, string>> proxyParams = new List<KeyValuePair<string, string>>()
                    //     {
                    //         new KeyValuePair<string, string>("sineperiod", "0.6"),
                    //         new KeyValuePair<string, string>("sinemin", "0"),
                    //         new KeyValuePair<string, string>("sinemax", "7"),
                    //         new KeyValuePair<string, string>("timeoffset", "0"),
                    //         new KeyValuePair<string, string>("resultVar", "$color")
                    //     };
                    //     conversion = VMTInteraction.InsertVector3IntoMaterial(conversion, colorArray);
                    //     conversion = VMTInteraction.AddProxy(conversion, "Sine", proxyParams);
                    // }
                    //
                    DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Path.Combine(path.FullName, a.Key)));
                    di.Create();
                    try
                    {
                        File.AppendAllText(Path.Combine(path.FullName,a.Key), VdfConvert.Serialize(conversion,settings));
                    }
                    catch(System.IO.FileNotFoundException)
                    {
                        progressBox.AppendText("The file " + a.Key + " could not be modified since the file path is too long.\r\n");
                    }
                }
                catch (Gameloop.Vdf.VdfException)
                {
                    progressBox.AppendText("The file " + a.Key + " could not be modified due to an faulty data structure.\r\n");
                }
            }
            using (Process pProcess = new Process())
            {
                progressBox.AppendText("Please wait, program will stall while packaging to VPK.\r\n");
                pProcess.StartInfo.FileName = Path.Combine(pathToExecutableDirectory, "bin\\vpk.exe");
                pProcess.StartInfo.Arguments = Path.GetDirectoryName(path.FullName + "/");
                pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pProcess.StartInfo.CreateNoWindow = true;
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.Start();
                string output = pProcess.StandardOutput.ReadToEnd();
                progressBox.AppendText("vpk.exe: " + output);
                pProcess.WaitForExit();
            }
            string tempFileLocation = Path.Combine(Path.GetTempPath(), Path.GetFileName(saveFileDialog1.FileName));
            //if (File.Exists(saveFileDialog1.FileName))
            //{
                try
                {
                    File.Delete(saveFileDialog1.FileName);
                    File.Move(tempFileLocation, saveFileDialog1.FileName);
                }
                catch (IOException)
                {
                    progressBox.AppendText("ERROR: The file is already in use by another process. Please close the process that is using this file.\r\n");
                }
            //}
            progressBox.AppendText("Operation complete.\r\n");
            ClearAllTempFiles(path, tempFileLocation);
            button1.Enabled = true;
        }
        private void ClearAllTempFiles(DirectoryInfo directory, string tempFile)
        {
            directory.Delete(true);
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
        private async void MaterialParameterList_ItemCheck(object sender, ItemCheckEventArgs e) //Move all these to a selection event once select w/o ticking becomes possible.
        {
            await XMLInteraction.WriteXmlParameters(completeUserDataPath);
            randomizerOffsetNumeric.DecimalPlaces = 7;
            deviationSettingsParam1Label.Text = "Parameter Random Deviation";
            deviationSettingsParam2Label.Hide();
            deviationSettingsParam3Label.Hide();
            randomizerOffsetNumeric2.Hide();
            randomizerOffsetNumeric3.Hide();
            Console.WriteLine(materialParameterDisplayList[e.Index].Param.ParamType);
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

        private void RandomizerDeviationNumeric_ValueChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].RandomizerOffset = (float)randomizerOffsetNumeric.Value;
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await XMLInteraction.WriteXmlParameters(completeUserDataPath);
        }
    }
}
