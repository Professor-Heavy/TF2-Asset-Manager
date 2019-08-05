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
        const string pathToGameDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Team Fortress 2";
        string pathToVpkTool = Path.Combine(pathToGameDirectory, "\\bin\\vpk.exe");
        static public string userDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        static public string completeUserDataPath = Path.Combine(userDataPath, "Team-Fortress-2-Asset-Manager");
        // readonly DirectoryInfo settingsDirectory = Directory.CreateDirectory(completeUserDataPath);
        // Uncomment this with the directory deleted as a test

        List<MaterialParameterDisplayListEntry> materialParameterDisplayList = new List<MaterialParameterDisplayListEntry>();
        public Form1()
        {
            InitializeComponent();
            XMLInteraction.ReadXmlParameters(completeUserDataPath);
            foreach (MaterialParameter param in XMLInteraction.MaterialParametersArrayList )
            {
                materialParameterDisplayList.Add(new MaterialParameterDisplayListEntry() { Position = materialParameterDisplayList.Count, Param = param, ParamName = param.ParamName});
            }
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
            //XMLInteraction.ImplementDefaultParameters();
            //XMLInteraction.ReadXmlParameters(completeUserDataPath);
            if (materialParameterList.CheckedItems.Count == 0)
            {
                progressBox.Text = "No parameters have been selected.";
                return;
            }
            button1.Enabled = false;
            progressBox.AppendText("Searching for files in the TF2 assets...\r\n");
            var returnedData = VPKInteraction.extractSpecificFileTypeFromVPK(Path.Combine(pathToGameDirectory, "tf\\tf2_misc_dir.vpk"), "vmt");
            progressBox.AppendText("Found " + returnedData.Count + " assets to edit.\r\n");
            foreach (var a in returnedData)
            {
                try
                {
                    VdfSerializerSettings settings = new VdfSerializerSettings();
                    settings.UsesEscapeSequences = false;
                    dynamic conversion = VdfConvert.Deserialize(returnedData[a.Key], settings);
                    for (var i = 0; i <= (materialParameterList.Items.Count - 1); i++)
                    {
                        if (materialParameterList.GetItemChecked(i))
                        {
                            MaterialParameterDisplayListEntry value = (materialParameterList.Items[i] as MaterialParameterDisplayListEntry);
                            switch (value.Param.ParamType)
                            {
                                case "vector3":
                                    if (value.Param.Parameter == "$color" || value.Param.Parameter == "$color2")
                                    {
                                        conversion = VMTInteraction.InsertVector3IntoMaterial(conversion,
                                                                                              VMTInteraction.PerformColorChecks(conversion.Key),
                                                                                              VMTInteraction.ConvertStringToVector3(value.Param.ParamValue));
                                    }
                                    else
                                    {
                                        conversion = VMTInteraction.InsertVector3IntoMaterial(conversion,
                                                                                              value.Param.Parameter,
                                                                                              VMTInteraction.ConvertStringToVector3(value.Param.ParamValue));
                                    }
                                    break;
                                case "integer":
                                    conversion = VMTInteraction.InsertIntIntoMaterial(conversion, value.Param.Parameter, Int32.Parse(value.Param.ParamValue));
                                    break;
                                case "bool":
                                    conversion = VMTInteraction.InsertIntIntoMaterial(conversion, value.Param.Parameter, Int32.Parse(value.Param.ParamValue));
                                    break;
                                case "string":
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
                    DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(a.Key));
                    di.Create();
                    try
                    {
                        File.AppendAllText(a.Key, VdfConvert.Serialize(conversion,settings));
                    }
                    catch(System.IO.DirectoryNotFoundException)
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

            }
            button1.Enabled = true;
            progressBox.AppendText("Operation complete.\r\n");
        }

        private void MaterialParameterList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != CheckState.Checked)
            {
                return;
            }
            if (materialParameterList.GetItemChecked(0))
            {
                materialParameterList.SetItemChecked(1, false);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(); 
        }

        private void MaterialParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
