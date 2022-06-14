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
    public partial class ImportParametersForm : Form
    {
        public MaterialParameter[] materialParameters;
        public LocalisationParameter[] localisationParameters;

        public ImportParametersForm()
        {
            InitializeComponent();
        }

        private void ImportParametersForm_Load(object sender, EventArgs e)
        {
            importedParameterList.Nodes.Add("Material Parameters");
            importedParameterList.Nodes.Add("Localisation Parameters");
            importedParameterList.Nodes[0].Nodes.AddRange(materialParameters.Select(x => new TreeNode(x.ParamName)).ToArray());
            importedParameterList.Nodes[1].Nodes.AddRange(localisationParameters.Select(x => new TreeNode(x.ParamName)).ToArray());
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

        }

        private void importedParameterList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNodeCollection item in e.Node.Nodes)
            {
                e.Node.Checked = true;
            }
        }
    }
}
