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
    public partial class ParameterAddForm : Form
    {
        public dynamic parent; //HACK: A dynamic type?!
        public enum ParameterContext
        {
            Material,
            Texture,
            Model,
            Particle,
            Localisation
        }
        public ParameterContext context;
        public ParameterAddForm()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            switch (context)
            {
                case ParameterContext.Material:
                    XMLInteraction.materialParametersList.Add(new MaterialParameter(ParameterName.Text, "", MaterialParameterType.GetMaterialParameterType("integer"), "0"));
                    break;
                case ParameterContext.Texture:
                    break;
                case ParameterContext.Model:
                    break;
                case ParameterContext.Particle:
                    break;
                case ParameterContext.Localisation:
                    XMLInteraction.localisationParametersList.Add(new LocalisationParameter(ParameterName.Text, ".*", MatchActions.Replace));
                    break;
                default:
                    break;
            }
            await XMLInteraction.WriteXmlParameters(MainWindow.completeUserDataPath);
            parent.RefreshParameterList();
            Close();
        }

        private void ParameterName_TextChanged(object sender, EventArgs e)
        {
            if(ParameterName.TextLength == 0)
            {
                ConfirmButton.Enabled = false;
            }
            else
            {
                ConfirmButton.Enabled = true;
            }
        }
    }
}
