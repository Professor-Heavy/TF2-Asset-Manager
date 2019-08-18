using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManager
{
    public partial class Form2 : Form
    {
        static List<Form1.MaterialParameterDisplayListEntry> materialParameterDisplayList = new List<Form1.MaterialParameterDisplayListEntry>();
        List<string> materialParameterTypeList = new List<string>{"vector3-int", "vector3-color", "vector3-float","string","bool","proxy"};

        public Form1 Parent;

        public Form2()
        {
            InitializeComponent();
            foreach (string item in materialParameterTypeList)
            {
                //materialTypeComboBox.Items.Add(item);
            }
            RefreshMaterialParameterList();
        }

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

        private void AddParameterButton_Click(object sender, EventArgs e)
        {
            MaterialParameterAddForm form = new MaterialParameterAddForm();
            form.Parent = this;
            form.ShowDialog();
        }

        private void MaterialParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialParameterList.SelectedIndex == -1 || materialParameterList.SelectedIndex >= materialParameterList.Items.Count)
            {
                materialParameterList.SelectedIndex = 0;
            }
            toolStripStatusLabel1.Text = "";
            materialParameterName.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamName;
            materialParameter.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].Parameter;
            materialParameterValue.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamValue;
            if (materialTypeComboBox.Items.IndexOf(XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamType) == -1)
            {
                materialTypeComboBox.Text = "";
                toolStripStatusLabel1.Text = materialParameterName.Text + " uses an invalid parameter type. This will result in an error when packaging.";
            }
            else
            {
                materialTypeComboBox.SelectedItem = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamType;
            }
        }

        private void MaterialTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(materialTypeComboBox.SelectedItem.ToString());
            if (materialTypeComboBox.SelectedItem.ToString() == "vector3-color")
            {
                colorSliderGroup.Show();
                int[] parameterColorValue;
                try
                {
                    parameterColorValue = Array.ConvertAll<string, int>(materialParameterValue.Text.Split(','), int.Parse);
                    if (parameterColorValue.Length != 3)
                    {
                        parameterColorValue = new int[] { 0, 0, 0 };
                    }
                }
                catch(FormatException)
                {
                    parameterColorValue = new int[] { 0, 0, 0 };
                }
                redLabel.Text = parameterColorValue[0].ToString();
                greenLabel.Text = parameterColorValue[1].ToString();
                blueLabel.Text = parameterColorValue[2].ToString();

                redTrackBar.Value = parameterColorValue[0];
                greenTrackBar.Value = parameterColorValue[1];
                blueTrackBar.Value = parameterColorValue[2];

                colorPreview.BackColor = Color.FromArgb(parameterColorValue[0], parameterColorValue[1], parameterColorValue[2]);
            }
            else if (materialTypeComboBox.SelectedItem.ToString() == "proxy")
            {
                toolStripStatusLabel1.Text = "The parameter type \"" +materialTypeComboBox.SelectedItem.ToString() + "\" is currently unimplemented. This parameter will not be packaged.";
            }
            else
            {
                colorSliderGroup.Hide();
            }
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamType = materialTypeComboBox.SelectedItem.ToString();
        }
        private void ScrollBarScrolling(object sender, EventArgs e)
        {
            colorPreview.BackColor = Color.FromArgb(redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
        }
        private void ScrollBarsChanged(object sender, EventArgs e)
        {
            materialParameterValue.Text = redLabel.Text + "," + greenLabel.Text + "," + blueLabel.Text;
        }
        private void RedTrackBar_Scroll(object sender, EventArgs e)
        {
            redLabel.Text = redTrackBar.Value.ToString();
        }
        private void GreenTrackBar_Scroll(object sender, EventArgs e)
        {
            greenLabel.Text = greenTrackBar.Value.ToString();
        }

        private void BlueTrackBar_Scroll(object sender, EventArgs e)
        {
            blueLabel.Text = blueTrackBar.Value.ToString();
        }
        private void MaterialParameterValue_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamValue = materialParameterValue.Text;
        }

        private async void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                await XMLInteraction.WriteXmlParameters(Form1.completeUserDataPath);
                Parent.RefreshMaterialParameterList();
            }
            catch(IOException)
            {
                toolStripStatusLabel1.Text = "Could not save settings. Configuration file may be missing or locked.";
                e.Cancel = true;
            }
            
        }

        private void MaterialParameter_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].Parameter = materialParameter.Text;
        }

        private void MaterialParameterName_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamName = materialParameterName.Text;
        }

        private void RemoveParameterButton_Click(object sender, EventArgs e)
        {
            if (materialParameterList.SelectedIndex != -1)
            {
                XMLInteraction.MaterialParametersArrayList.RemoveAt(materialParameterList.SelectedIndex);
                RefreshMaterialParameterList();
            }
            else
            {
                toolStripStatusLabel1.Text = "Please select a parameter to remove first.";
            }
        }
    }
}
