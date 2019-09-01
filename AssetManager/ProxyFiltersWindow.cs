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
    public partial class ProxyFiltersWindow : Form
    {
        public MaterialParameter parameterInfo;
        public ProxyFiltersWindow()
        {
            InitializeComponent();
        }
        string filterTypeString;
        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = parameterInfo.ProxyFilterMode;
            filterTypeString = Convert.ToBoolean(parameterInfo.ProxyFilterMode) ? "NOT be used" : "be USED";
            //0 = Will not be used if any proxy is on the file.
            //1 = Will be used if any proxy is on the file.
            label1.Text = "If any proxy on this list is found in a file,\n" + parameterInfo.ParamName + " will " + filterTypeString + ". Separate your proxies with a new line.";
            textBox1.Text = string.Join(Environment.NewLine, parameterInfo.ProxyFilterArray.ToArray());
        }

        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            string[] filters = textBox1.Text.Split(new string[] {Environment.NewLine},StringSplitOptions.None);
            parameterInfo.ProxyFilterArray.Clear();
            parameterInfo.ProxyFilterArray.AddRange(filters);
            await XMLInteraction.WriteXmlParameters(MainWindow.completeUserDataPath);
            Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameterInfo.ProxyFilterMode = comboBox1.SelectedIndex; //It works.
            filterTypeString = Convert.ToBoolean(parameterInfo.ProxyFilterMode) ? "ONLY affect" : "NOT affect";
            label1.Text = "Please type a list of shaders you would like \n" + parameterInfo.ParamName + " to " + filterTypeString + ", separating them with a new line.";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
