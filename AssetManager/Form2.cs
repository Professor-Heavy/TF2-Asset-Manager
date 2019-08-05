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
    public partial class Form2 : Form
    {
        static List<Form1.MaterialParameterDisplayListEntry> materialParameterDisplayList = new List<Form1.MaterialParameterDisplayListEntry>();
        public Form2()
        {
            InitializeComponent();
            RefreshMaterialParameterList();
        }

        public void RefreshMaterialParameterList()
        {
            materialParameterDisplayList.Clear();
            foreach (MaterialParameter param in XMLInteraction.MaterialParametersArrayList)
            {
                materialParameterDisplayList.Add(new Form1.MaterialParameterDisplayListEntry() { Position = materialParameterDisplayList.Count, Param = param, ParamName = param.ParamName });
            }
            materialParameterList.DataSource = materialParameterDisplayList;
            materialParameterList.DisplayMember = "ParamName";
            materialParameterList.ValueMember = "Position";
        }

        private void AddParameterButton_Click(object sender, EventArgs e)
        {
            MaterialParameterAddForm form = new MaterialParameterAddForm();
            form.Parent = this;
            form.ShowDialog();
        }
    }
}
