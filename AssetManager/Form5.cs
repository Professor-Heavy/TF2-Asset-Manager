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
    public partial class Form5 : Form
    {
        public MaterialParameter parameterInfo;
        public Form5()
        {
            InitializeComponent();
        }

        string filterTypeString;

        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            string[] filters = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            parameterInfo.RandomChoiceArray.Clear();
            parameterInfo.RandomChoiceArray.AddRange(filters);
            await XMLInteraction.WriteXmlParameters(Form1.completeUserDataPath);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Join(Environment.NewLine, parameterInfo.RandomChoiceArray.ToArray());
        }
    }
}
