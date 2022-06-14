using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManager
{
    public partial class FilterOptionsWindow : Form
    {
        public MaterialCorruptionSettings settings;
        public FilterOptionsWindow()
        {
            InitializeComponent();
        }

        private void ShaderFiltersExcludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(shaderFiltersExcludeRadioButton.Checked)
            {
                settings.ShaderFilterMode = 0;
            }
        }

        private void ShaderFiltersIncludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (shaderFiltersIncludeRadioButton.Checked)
            {
                settings.ShaderFilterMode = 1; //TODO: This goes against the idea of a confirmation button by setting it here. Why?
            }
        }

        private void ParameterFiltersExcludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (parameterFiltersExcludeRadioButton.Checked)
            {
                DialogResult warningWindowResult = MessageBox.Show("If you enable this, ANY parameter in a VMT file can be swapped. This can lead to unstable results if not used correctly.\nAre you sure you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warningWindowResult == DialogResult.No)
                {
                    parameterFiltersIncludeRadioButton.Checked = true;
                    parameterFiltersExcludeRadioButton.Checked = false;
                }
                else
                {
                    settings.ParameterFilterMode = 0; 
                }
            }
            
        }

        private void ParameterFiltersIncludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (parameterFiltersIncludeRadioButton.Checked)
            {
                settings.ParameterFilterMode = 1;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            string[] shaderFilters = shaderFiltersTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            settings.ShaderFilterArray.Clear();
            settings.ShaderFilterArray.AddRange(shaderFilters);

            string[] paramFilters = parameterFiltersTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            settings.ParameterFilterArray.Clear();
            settings.ParameterFilterArray.AddRange(paramFilters);

            if (shaderFiltersExcludeRadioButton.Checked)
            {
                settings.ShaderFilterMode = 0;
            }
            if (shaderFiltersIncludeRadioButton.Checked)
            {
                settings.ShaderFilterMode = 1;
            }

            if (settings.Arguments.ContainsKey("AffectSimilarShaders"))
            {
                settings.Arguments["AffectSimilarShaders"] = affectsSameShaders.Checked.ToString();
            }
            Close();
        }

        private void FilterOptionsWindow_Load(object sender, EventArgs e)
        {
            shaderFiltersTextBox.Text = string.Join(Environment.NewLine, settings.ShaderFilterArray.ToArray());
            parameterFiltersTextBox.Text = string.Join(Environment.NewLine, settings.ParameterFilterArray.ToArray());

            if(settings.ShaderFilterMode == 1)
            {
                shaderFiltersIncludeRadioButton.Checked = true;
                shaderFiltersExcludeRadioButton.Checked = false;
            }
            else
            {
                shaderFiltersExcludeRadioButton.Checked = true;
                shaderFiltersIncludeRadioButton.Checked = false;
            }

            if (settings.ParameterFilterMode == 1)
            {
                parameterFiltersIncludeRadioButton.Checked = true;
                parameterFiltersExcludeRadioButton.Checked = false;
            }
            else
            {
                parameterFiltersExcludeRadioButton.Checked = true;
                parameterFiltersIncludeRadioButton.Checked = false;
            }

            if(settings.Arguments.ContainsKey("AffectSimilarShaders"))
            {
                affectsSameShaders.Visible = true;
                affectsSameShaders.Checked = bool.Parse(settings.Arguments["AffectSimilarShaders"]);
            }
            parameterFiltersExcludeRadioButton.CheckedChanged += new EventHandler(this.ParameterFiltersExcludeRadioButton_CheckedChanged);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
