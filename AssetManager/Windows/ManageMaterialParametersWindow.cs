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
    public partial class ManageMaterialParametersWindow : Form
    {
        static List<MainWindow.MaterialParameterDisplayListEntry> materialParameterDisplayList = new List<MainWindow.MaterialParameterDisplayListEntry>();

        public MainWindow Parent;

        Dictionary<int, TextBox[]> proxyParameterTextBoxList = new Dictionary<int, TextBox[]>();
        Dictionary<string, string> comboBoxDataSource = new Dictionary<string, string>();

        public ManageMaterialParametersWindow()
        {
            InitializeComponent();
            
            foreach(TrackBar trackbar in colorSliderGroup.Controls.OfType<TrackBar>())
            {
                trackbar.Scroll += new EventHandler(ScrollBarScrolling);
            }
            
            foreach(MaterialParameterType type in MaterialParameterType.materialParameterTypeList)
            {
                comboBoxDataSource.Add(type.ParameterInternalName, type.ParameterName);
            }
            materialTypeComboBox.DataSource = new BindingSource(comboBoxDataSource, null);
            materialTypeComboBox.DisplayMember = "Value";
            materialTypeComboBox.ValueMember = "Key";
            
            RefreshParameterList();
        }

        public void RefreshParameterList()
        {
            materialParameterDisplayList.Clear();
            foreach (MaterialParameter param in XMLInteraction.materialParametersList)
            {
                materialParameterDisplayList.Add(new MainWindow.MaterialParameterDisplayListEntry() { Position = materialParameterDisplayList.Count, Param = param, ParamName = param.ParamName });
            }
            materialParameterList.DataSource = null;
            materialParameterList.DataSource = materialParameterDisplayList;
            materialParameterList.DisplayMember = "ParamName";
            materialParameterList.ValueMember = "Position";
        }

        private void AddParameterButton_Click(object sender, EventArgs e)
        {
            ParameterAddForm form = new ParameterAddForm
            {
                parent = this,
                context = ParameterAddForm.ParameterContext.Material
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
            MaterialParameter selectedParameter = XMLInteraction.materialParametersList[materialParameterList.SelectedIndex];
            materialParameterName.Text = selectedParameter.ParamName;
            materialParameter.Text = selectedParameter.Parameter;
            if(!selectedParameter.ParamType.UsesArrays)
            {
                materialParameterValue.Text = selectedParameter.ParamValue;
            }
            if(selectedParameter.ParamType.Delimiter)
            {
                materialParameterValue.Text = string.Join(",", selectedParameter.ParamValue);
            }

            if (comboBoxDataSource[selectedParameter.ParamType.ParameterInternalName] == null)
            {
                toolStripStatusLabel1.Text = materialParameterName.Text + " uses an invalid parameter type. This will cause an error when exporting.";
            }
            else
            {
                materialTypeComboBox.SelectedValue = selectedParameter.ParamType.ToString();
            }

            if(selectedParameter.ParamType.ParameterInternalName == "proxy")
            {
                RefreshProxyGroupBoxes(selectedParameter.ParamValue);
            }
        }

        private void MaterialTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(materialParameterList.SelectedIndex == -1)
            {
                return;
            }
            MaterialParameter selectedParameter = XMLInteraction.materialParametersList[materialParameterList.SelectedIndex];
            label3.Text = "Parameter";
            label4.Show();
            materialParameterValue.Show();
            colorCheckBox.Hide();
            multipleChoiceFormButton.Hide();
            proxyPropertiesGroup.Hide();
            if (materialTypeComboBox.SelectedValue.ToString() == "vector3")
            {
                colorCheckBox.Show();
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
            else if (materialTypeComboBox.SelectedValue.ToString() == "proxy")
            {
                label3.Text = "Proxy";
                label4.Hide();
                materialParameterValue.Hide();
                proxyPropertiesGroup.Show();
                if(selectedParameter.ParamValue.GetType() != typeof(List<string[]>)) //Are you sure? this causes conflict with MaterialTypeComboBox_SelectedChangeCommitted
                {
                    SetInitialParameterValue(selectedParameter);
                }
                RefreshProxyGroupBoxes(selectedParameter.ParamValue);
            }
            else if(materialTypeComboBox.SelectedValue.ToString() == "choices")
            {
                materialParameterValue.Hide();
                multipleChoiceFormButton.Show();
                toolStripStatusLabel1.Text = "The parameter type \"" + materialTypeComboBox.SelectedItem.ToString() + "\" is currently unimplemented. This parameter will not be packaged.";
            }
            else
            {
                proxyPropertiesGroup.Hide();
            }
            //XMLInteraction.MaterialParametersArrayList[materialParameterList.SelectedIndex].ParamType = MaterialParameterType.GetMaterialParameterType(materialTypeComboBox.SelectedItem.ToString());
            //Caused errors.
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
            MaterialParameter selectedParameter = XMLInteraction.materialParametersList[materialParameterList.SelectedIndex];
            if(!selectedParameter.ParamType.UsesArrays)
            {
                selectedParameter.ParamValue = materialParameterValue.Text;
            }
            if(selectedParameter.ParamType.Delimiter)
            {
                selectedParameter.ParamValue = new List<string>();
                selectedParameter.ParamValue.AddRange(materialParameterValue.Text.Split(','));
            }
        }
        private async void ManageMaterialParametersWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                await XMLInteraction.WriteXmlParameters(MainWindow.completeUserDataPath);
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
            XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].Parameter = materialParameter.Text;
        }

        private void MaterialParameterName_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].ParamName = materialParameterName.Text;
        }

        private void RemoveParameterButton_Click(object sender, EventArgs e)
        {
            if (materialParameterList.SelectedIndex != -1)
            {
                XMLInteraction.materialParametersList.RemoveAt(materialParameterList.SelectedIndex);
                RefreshParameterList();
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
                XMLInteraction.materialParametersList[materialParameterList.SelectedIndex].ParamValue = proxyParameterList;
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
            proxyPropertiesGroup.Controls.Add(newParameters[0]);
            proxyPropertiesGroup.Controls.Add(newParameters[1]);
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

        private TextBox[] CreateNewProxyParameter(string[] values = null, bool createControl = false)
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
                duplicatedValueTextBox.TextChanged += new System.EventHandler(ProxyParameterTextBox_TextChanged);
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
                CreateNewProxyParameter(proxyParameter, false);
            }
            
            addProxyButton.Enabled = proxyParameterTextBoxList.Count < 6;
            removeProxyButton.Enabled = proxyParameterTextBoxList.Count > 0;

            foreach (TextBox[] textBox in proxyParameterTextBoxList.Values)
            {
                proxyPropertiesGroup.Controls.Add(textBox[0]);
                proxyPropertiesGroup.Controls.Add(textBox[1]);
            }

            if (parameterArray.Count > 0)
            {
                addProxyButton.Location = new Point(140, proxyParameterTextBoxList.Last().Value[0].Location.Y + 26);
                removeProxyButton.Location = new Point(207, proxyParameterTextBoxList.Last().Value[0].Location.Y + 26);
            }
        }

        private void MultipleChoiceFormButton_Click(object sender, EventArgs e)
        {
            RandomChoicesWindow form = new RandomChoicesWindow
            {
                parameterInfo = XMLInteraction.materialParametersList[materialParameterList.SelectedIndex]
            };
            form.ShowDialog();
        }

        private void MaterialTypeComboBox_SelectedChangeCommitted(object sender, EventArgs e)
        {
            SetInitialParameterValue(XMLInteraction.materialParametersList[materialParameterList.SelectedIndex]);
        }

        private void SetInitialParameterValue(MaterialParameter materialParameter)
        {
            materialParameter.ParamType = MaterialParameterType.GetMaterialParameterType(materialTypeComboBox.SelectedValue.ToString());
            Type paramType = materialParameter.ParamType.ParameterType;
            if (materialParameter.ParamType.UsesArrays)
            {
                if (materialParameter.ParamType.UsesAttributes)
                {
                    materialParameter.ParamValue = new List<string[]>();
                }
                else
                {
                    materialParameter.ParamValue = new List<string>();
                }
            }
            else
            {
                if (materialParameter.ParamType.ParameterType.Name == "String")
                {
                    materialParameter.ParamValue = string.Empty;
                }
                else
                {
                    materialParameter.ParamValue = Activator.CreateInstance(paramType).ToString();
                }

                materialParameterValue.Text = materialParameter.ParamValue.ToString();
            }
        }

        private void ColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(colorCheckBox.Checked)
            {
                colorSliderGroup.Show();
            }
            else
            {
                colorSliderGroup.Hide();
            }
        }

        private void ColorCheckBox_VisibleChanged(object sender, EventArgs e)
        {
            if (!colorCheckBox.Visible)
            {
                colorCheckBox.Checked = false;
                colorSliderGroup.Hide();
            }
        }
    }
}
