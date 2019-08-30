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
    public partial class RandomChoicesWindow : Form
    {
        public MaterialParameter parameterInfo;
        public RandomChoicesWindow()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            string[] choices = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            parameterInfo.ParamValue.Clear();
            parameterInfo.ParamValue.AddRange(choices);
            await XMLInteraction.WriteXmlParameters(MainWindow.completeUserDataPath);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Join(Environment.NewLine, parameterInfo.ParamValue.ToArray());
        }
    }
}
