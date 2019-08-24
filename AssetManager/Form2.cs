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
using AssetManager;

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
                toolStripStatusLabel1.Text = materialParameterName.Text + " uses an invalid parameter type. This will cause an error when exporting.";
            }
            else
            {
                materialTypeComboBox.SelectedItem = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamType;
            }
            if (materialTypeComboBox.Text == "proxy")
            {
                label10.Show();
                proxyParameterTextBox1.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray[0][0];
                proxyParameterTextBox2.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray[1][0];
                proxyParameterTextBox3.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray[2][0];
                proxyParameterTextBox4.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray[3][0];
                proxyValueTextBox1.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray[0][1];
                proxyValueTextBox2.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray[1][1];
                proxyValueTextBox3.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray[2][1];
                proxyValueTextBox4.Text = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray[3][1];
                label10.Hide();
            }
        }

        private void MaterialTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = "Value";
            label4.Show();
            materialParameterValue.Show();
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
                label3.Text = "Proxy";
                label4.Hide();
                materialParameterValue.Hide();
                colorSliderGroup.Hide();
                proxyPropertiesGroup.Show();
            }
            else if(materialTypeComboBox.SelectedItem.ToString() == "Parameter Swapper")
            {
                toolStripStatusLabel1.Text = "The parameter type \"" + materialTypeComboBox.SelectedItem.ToString() + "\" is currently unimplemented. This parameter will not be packaged.";
            }
            else
            {
                colorSliderGroup.Hide();
                proxyPropertiesGroup.Hide();
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

        private void ProxyParameterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Modified) //Hack.
            {
                XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].proxyParameterArray = new List<string[]>
                {
                    new string[] {proxyParameterTextBox1.Text, proxyValueTextBox1.Text},
                    new string[] {proxyParameterTextBox2.Text, proxyValueTextBox2.Text},
                    new string[] {proxyParameterTextBox3.Text, proxyValueTextBox3.Text},
                    new string[] {proxyParameterTextBox4.Text, proxyValueTextBox4.Text}
                };
            }
        }
    }
}
