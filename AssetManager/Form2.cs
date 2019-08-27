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

        Dictionary<int, TextBox[]> proxyParameterTextBoxList = new Dictionary<int, TextBox[]>();
        

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
            MaterialParameterAddForm form = new MaterialParameterAddForm
            {
                Parent = this
            };
            form.ShowDialog();
        }

        private void MaterialParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialParameterList.SelectedIndex == -1 || materialParameterList.SelectedIndex >= materialParameterList.Items.Count)
            {
                materialParameterList.SelectedIndex = 0;
            }
            toolStripStatusLabel1.Text = "";
            MaterialParameter selectedParameter = XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex];
            materialParameterName.Text = selectedParameter.ParamName;
            materialParameter.Text = selectedParameter.Parameter;
            materialParameterValue.Text = selectedParameter.ParamValue;
            if (materialTypeComboBox.Items.IndexOf(selectedParameter.ParamType) == -1)
            {
                toolStripStatusLabel1.Text = materialParameterName.Text + " uses an invalid parameter type. This will cause an error when exporting.";
            }
            else
            {
                materialTypeComboBox.SelectedItem = selectedParameter.ParamType;
            }
            if (materialTypeComboBox.Text == "proxy") //Is there a better way to populate these values?
            {
                RefreshProxyGroupBoxes(selectedParameter.ProxyParameterArray);
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
                proxyPropertiesGroup.Hide();
                int[] parameterColorValue;
                try
                {
                    parameterColorValue = Array.ConvertAll(materialParameterValue.Text.Split(','), int.Parse);
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
                RefreshProxyGroupBoxes(XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ProxyParameterArray);
            }
            else if(materialTypeComboBox.SelectedItem.ToString() == "Parameter Swapper")
            {
                colorSliderGroup.Hide();
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
                List<string[]> proxyParameterList = new List<string[]>(); //TODO: Create a new value every time it changes?! ARE YOU INSANE?!
                foreach (TextBox[] textBox in proxyParameterTextBoxList.Values)
                {
                    proxyParameterList.Add(new string[] { textBox[0].Text, textBox[1].Text });
                }
                XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ProxyParameterArray = proxyParameterList;
            }
        }

        private void ClearProxyParameter()
        {
            proxyPropertiesGroup.Controls.Remove(proxyParameterTextBoxList.Last().Value[0]);
            proxyPropertiesGroup.Controls.Remove(proxyParameterTextBoxList.Last().Value[1]);
            proxyParameterTextBoxList.Remove(proxyParameterTextBoxList.Last().Key);
            addProxyButton.Location = new Point(addProxyButton.Location.X, addProxyButton.Location.Y - 26);
            removeProxyButton.Location = new Point(removeProxyButton.Location.X, removeProxyButton.Location.Y - 26);
        }

        private void AddProxyButton_Click(object sender, EventArgs e)
        {
            TextBox[] newParameters;
            newParameters = CreateNewProxyParameter();
            addProxyButton.Enabled = proxyParameterTextBoxList.Count < 6; //hey look, i did a smart
            removeProxyButton.Enabled = proxyParameterTextBoxList.Count > 0;
        }

        private void RemoveProxyButton_Click(object sender, EventArgs e)
        {
            ClearProxyParameter();
            addProxyButton.Enabled = proxyParameterTextBoxList.Count < 6; //maybe the code reuse is not smart
            removeProxyButton.Enabled = proxyParameterTextBoxList.Count > 0;
        }

        public TextBox proxyParameterTextBox;
        public TextBox proxyValueTextBox;

        private TextBox[] CreateNewProxyParameter(string[] values = null)
        {
            TextBox[] returnValue;
            if (proxyParameterTextBoxList.Count == 0)
            {
                returnValue = CreateFirstTextBoxes();
            }
            else
            {
                TextBox parameterTextBox = proxyParameterTextBoxList.Last().Value[0];
                TextBox valueTextBox = proxyParameterTextBoxList.Last().Value[1];

                TextBox duplicatedParameterTextBox = new TextBox();
                TextBox duplicatedValueTextBox = new TextBox();

                duplicatedParameterTextBox.Size = parameterTextBox.Size;
                duplicatedParameterTextBox.Location = new Point(parameterTextBox.Location.X, parameterTextBox.Location.Y + 26);
                duplicatedParameterTextBox.TextChanged += new System.EventHandler(ProxyParameterTextBox_TextChanged);

                duplicatedValueTextBox.Size = valueTextBox.Size;
                duplicatedValueTextBox.Location = new Point(valueTextBox.Location.X, valueTextBox.Location.Y + 26);
                duplicatedParameterTextBox.TextChanged += new System.EventHandler(ProxyParameterTextBox_TextChanged);
                returnValue = new TextBox[]
                {
                    duplicatedParameterTextBox,
                    duplicatedValueTextBox
                };
            }
            if (values != null)
            {
                returnValue[0].Text = values[0];
                returnValue[1].Text = values[1];
            }
            proxyParameterTextBoxList.Add(proxyParameterTextBoxList.Count, returnValue);
            addProxyButton.Location = new Point(addProxyButton.Location.X, addProxyButton.Location.Y + 26);
            removeProxyButton.Location = new Point(removeProxyButton.Location.X, removeProxyButton.Location.Y + 26);
            return returnValue;
        }

        private TextBox[] CreateFirstTextBoxes()
        {
            proxyParameterTextBox = new TextBox
            {
                Location = new Point(6, 32),
                Name = "proxyParameterTextBox",
                Size = new Size(190, 20),
                TabIndex = 8
            };
            proxyParameterTextBox.TextChanged += new System.EventHandler(ProxyParameterTextBox_TextChanged);

            proxyValueTextBox = new TextBox
            {
                Location = new Point(202, 32),
                Name = "proxyValueTextBox",
                Size = new Size(184, 20),
                TabIndex = 9
            };
            proxyValueTextBox.TextChanged += new System.EventHandler(ProxyParameterTextBox_TextChanged);
            TextBox[] createdTextBoxes = new TextBox[] { proxyParameterTextBox, proxyValueTextBox };
            return createdTextBoxes;
        }

        private void RefreshProxyGroupBoxes(List<string[]> parameterArray)
        {
            proxyParameterTextBoxList.Clear();
            while(proxyPropertiesGroup.Controls.OfType<TextBox>().Count() != 0)
            {
                foreach (TextBox textBox in proxyPropertiesGroup.Controls.OfType<TextBox>())
                {
                    textBox.Dispose();
                    proxyPropertiesGroup.Controls.Remove(textBox);
                }
            }
            foreach (string[] proxyParameter in parameterArray)
            {
                CreateNewProxyParameter(proxyParameter);
            }
            if (proxyParameterTextBoxList.Count >= 6)
            {
                addProxyButton.Enabled = false;
            }
            if (proxyParameterTextBoxList.Count <= 0)
            {
                removeProxyButton.Enabled = false;
            }
            foreach (TextBox[] textBox in proxyParameterTextBoxList.Values)
            {
                proxyPropertiesGroup.Controls.Add(textBox[0]);
                proxyPropertiesGroup.Controls.Add(textBox[1]);
            }
            addProxyButton.Location = new Point(140, proxyParameterTextBoxList.Last().Value[0].Location.Y);
            removeProxyButton.Location = new Point(207, proxyParameterTextBoxList.Last().Value[0].Location.Y);
        }
    }
}
