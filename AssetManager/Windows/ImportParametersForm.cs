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
            Close();
        }

        /// <summary>
        /// Returns a list of all child nodes. Does not return any parent nodes.
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        List<string> RecusivelyCheckNodeChildren(TreeNodeCollection nodes, bool checkedOnly)
        {
            List<string> recursiveItems = new List<string>();
            foreach (TreeNode item in nodes)
            {
                if(item.Nodes.Count > 0)
                {
                    recursiveItems.AddRange(RecusivelyCheckNodeChildren(item.Nodes, checkedOnly));
                }
                else
                {
                    if(checkedOnly && !item.Checked)
                    {
                        continue;
                    }
                    recursiveItems.Add(item.Text);
                }
            }
            return recursiveItems;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            List<MaterialParameter> selectedMaterialParameters = new List<MaterialParameter>();
            List<LocalisationParameter> selectedLocalisationParameters = new List<LocalisationParameter>();
            List<string> selectedNodes = RecusivelyCheckNodeChildren(importedParameterList.Nodes, true);
            foreach (string item in selectedNodes)
            {
                //TODO: This will result in an issue if 2 parameters have the exact same name.
                //The entire function could do with a rewrite.
                MaterialParameter materialMatch = materialParameters.FirstOrDefault(x => x.ParamName == item);
                if(materialMatch != null)
                {
                    selectedMaterialParameters.Add(materialMatch);
                }
                LocalisationParameter localisationMatch = localisationParameters.FirstOrDefault(x => x.ParamName == item);
                if (localisationMatch != null)
                {
                    selectedLocalisationParameters.Add(localisationMatch);
                }
            }

            //TODO: Before moving onto any other types, it may be wise to reconsider my ways of storing all of these parameters as classes...
            XMLInteraction.AddParametersToList(selectedMaterialParameters.ToArray()); 
            XMLInteraction.AddParametersToList(selectedLocalisationParameters.ToArray());

            Close();
        }

        private void importedParameterList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //Checking a child of a parent does not reflect that to the parent (such as a 3-state checkbox).
            //Now may be the time to create a control for it.
            foreach (TreeNode item in e.Node.Nodes)
            {
                item.Checked = e.Node.Checked;
            }
        }
    }
}
