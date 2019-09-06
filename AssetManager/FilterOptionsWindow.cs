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
        public FilterOptionsWindow()
        {
            InitializeComponent();
        }

        private void ShaderFiltersIncludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            shaderFiltersExcludeRadioButton.Checked = false;
        }

        private void ShaderFiltersExcludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            shaderFiltersIncludeRadioButton.Checked = false;
        }

        private void ParameterFiltersIncludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            parameterFiltersExcludeRadioButton.Checked = false;
        }

        private void ParameterFiltersExcludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            parameterFiltersIncludeRadioButton.Checked = false;
        }
    }
}
