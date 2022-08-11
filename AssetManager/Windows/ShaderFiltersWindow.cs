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
    public partial class ShaderFiltersWindow : Form
    {
        public MaterialParameter parameterInfo;
        bool dirty = false;
        public ShaderFiltersWindow()
        {
            InitializeComponent();
        }
        string filterTypeString;
        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = parameterInfo.ShaderFilterMode;
            filterTypeString = Convert.ToBoolean(parameterInfo.ShaderFilterMode) ? "ONLY affect": "NOT affect";
            //0 = Filter will EXCLUDE any shaders in the list.
            //1 = Filter will ONLY AFFECT shaders in the list.
            label1.Text = "Please type a list of shaders you would like \n" + parameterInfo.ParamName + " to " + filterTypeString + ", separating them with a new line.";
            textBox1.Text = string.Join(Environment.NewLine, parameterInfo.ShaderFilterArray.ToArray());
        }

        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            string[] filters = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            parameterInfo.ShaderFilterArray.Clear();
            parameterInfo.ShaderFilterArray.AddRange(filters);
            Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dirty = true;
            parameterInfo.ShaderFilterMode = comboBox1.SelectedIndex; //It works.
            filterTypeString = Convert.ToBoolean(parameterInfo.ShaderFilterMode) ? "ONLY affect" : "NOT affect";
            label1.Text = "Please type a list of shaders you would like \n" + parameterInfo.ParamName + " to " + filterTypeString + ", separating them with a new line.";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dirty = true;
        }
    }
}
