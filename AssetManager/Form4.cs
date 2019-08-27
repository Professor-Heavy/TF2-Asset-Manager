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
    public partial class Form4 : Form
    {
        public MaterialParameter parameterInfo;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int filterType = parameterInfo.ShaderFilterMode;
            string filterTypeString = Convert.ToBoolean(filterType) ? "NOT affect" : "ONLY affect";
            //0 = Filter will EXCLUDE any shaders in the list.
            //1 = Filter will ONLY AFFECT shaders in the list.
            label1.Text = "Please type a list of shaders you would like \n" + parameterInfo.ParamName + " to " + filterTypeString + ", separating them with a new line.";
            textBox1.Text = string.Join(Environment.NewLine, parameterInfo.ShaderFilterArray.ToArray());
        }

        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            string[] filters = textBox1.Text.Split(new string[] {Environment.NewLine},StringSplitOptions.None);
            parameterInfo.ShaderFilterArray.AddRange(filters);
            await XMLInteraction.WriteXmlParameters(Form1.completeUserDataPath);
            Close();
        }
    }
}
