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
        public string parameterName;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int filterType;
            //0 = Filter will EXCLUDE any shaders in the list.
            //1 = Filter will ONLY AFFECT shaders in the list.
            label1.Text = "Please type a list of shaders you would not like " + parameterName + " to affect, separating them with a new line.";
        }
    }
}
