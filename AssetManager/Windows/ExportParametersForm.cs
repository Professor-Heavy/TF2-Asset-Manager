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
    public partial class ExportParametersForm : Form
    {
        public MaterialParameter[] materialParameters;
        public LocalisationParameter[] localisationParameters;
        public SoundParameter[] soundParameters;

        public ExportParametersForm()
        {
            InitializeComponent();
        }

        private void ExportParametersForm_Load(object sender, EventArgs e)
        {
            exportParameterList.Nodes.Add("Material Parameters");
            exportParameterList.Nodes.Add("Localisation Parameters");
            exportParameterList.Nodes.Add("Sound Parameters");
            exportParameterList.Nodes[0].Nodes.AddRange(materialParameters.Select(x => new TreeNode(x.ParamName)).ToArray());
            exportParameterList.Nodes[1].Nodes.AddRange(localisationParameters.Select(x => new TreeNode(x.ParamName)).ToArray());
            exportParameterList.Nodes[2].Nodes.AddRange(soundParameters.Select(x => new TreeNode(x.ParamName)).ToArray());
        }

        List<string> RecusivelyCheckNodeChildren(TreeNodeCollection nodes, bool checkedOnly)
        {
            //Code reuse... Maybe this wouldn't hurt to put into its own public function, maybe even on its own control.
            List<string> recursiveItems = new List<string>();
            foreach (TreeNode item in nodes)
            {
                if (item.Nodes.Count > 0)
                {
                    recursiveItems.AddRange(RecusivelyCheckNodeChildren(item.Nodes, checkedOnly));
                }
                else
                {
                    if (checkedOnly && !item.Checked)
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
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //With the amount of code repetition on display here...
            List<MaterialParameter> selectedMaterialParameters = new List<MaterialParameter>();
            List<LocalisationParameter> selectedLocalisationParameters = new List<LocalisationParameter>();
            List<SoundParameter> selectedSoundParameters = new List<SoundParameter>();
            List<string> selectedNodes = RecusivelyCheckNodeChildren(exportParameterList.Nodes, true);
            foreach (string item in selectedNodes)
            {
                //TODO: This will result in an issue if 2 parameters have the exact same name.
                //The entire function could do with a rewrite.
                MaterialParameter materialMatch = materialParameters.FirstOrDefault(x => x.ParamName == item);
                if (materialMatch != null)
                {
                    selectedMaterialParameters.Add(materialMatch);
                }
                LocalisationParameter localisationMatch = localisationParameters.FirstOrDefault(x => x.ParamName == item);
                if (localisationMatch != null)
                {
                    selectedLocalisationParameters.Add(localisationMatch);
                }
                SoundParameter soundMatch = soundParameters.FirstOrDefault(x => x.ParamName == item);
                if (soundMatch != null)
                {
                    selectedSoundParameters.Add(soundMatch);
                }
            }
            XMLInteraction.WriteXmlParameters(saveFileDialog.FileName, false, selectedMaterialParameters.ToArray(), selectedLocalisationParameters.ToArray(), selectedSoundParameters.ToArray());
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportParameterList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode item in e.Node.Nodes)
            {
                item.Checked = e.Node.Checked;
            }
        }
    }
}
