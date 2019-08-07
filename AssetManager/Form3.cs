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
    public partial class MaterialParameterAddForm : Form
    {
        public Form2 Parent;
        public MaterialParameterAddForm()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            XMLInteraction.MaterialParametersArrayList.Add(new MaterialParameter(ParameterName.Text,"","integer","0"));
            XMLInteraction.WriteXmlParameters(Form1.completeUserDataPath);
            Parent.RefreshMaterialParameterList();
            Parent.Parent.RefreshMaterialParameterList(); //...what the hell
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
