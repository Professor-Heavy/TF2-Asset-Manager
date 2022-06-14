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
    public partial class RegexMatchDisplayWindow : Form
    {

        public Dictionary<string, string> results;

        public RegexMatchDisplayWindow()
        {
            InitializeComponent();
        }

        private void RegexMatchDisplayWindow_Load(object sender, EventArgs e)
        {
            int count = 0;
            foreach (KeyValuePair<string, string> result in results)
            {
                regexResultsDataGridView.Rows.Add(new string[3] {count.ToString(), result.Key, result.Value });
                count++;
            }
        }
    }
}
