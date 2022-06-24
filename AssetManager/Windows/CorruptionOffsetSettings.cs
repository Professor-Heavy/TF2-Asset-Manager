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
    public partial class CorruptionOffsetSettings : Form
    {
        public MaterialCorruptionSettings settings;
        public CorruptionOffsetSettings()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            settings.Arguments["OffsetLow"] = corruptionLowOffsetNumeric.Value.ToString();
            settings.Arguments["OffsetHigh"] = corruptionHighOffsetNumeric.Value.ToString();
            settings.Arguments["LowBoundEnabled"] = lowBoundsCheckBox.Checked ? "1" : "0";
            settings.Arguments["HighBoundEnabled"] = highBoundsCheckBox.Checked ? "1" : "0";
            settings.Arguments["LowBoundValue"] = lowBoundsNumeric.Value.ToString();
            settings.Arguments["HighBoundValue"] = highBoundsNumeric.Value.ToString();
            Close();
        }

        private void CorruptionOffsetSettings_Load(object sender, EventArgs e)
        {
            corruptionLowOffsetNumeric.Value = decimal.Parse(settings.Arguments["OffsetLow"]);
            corruptionHighOffsetNumeric.Value = decimal.Parse(settings.Arguments["OffsetHigh"]);
            lowBoundsCheckBox.Checked = settings.Arguments["LowBoundEnabled"] == "1";
            highBoundsCheckBox.Checked = settings.Arguments["HighBoundEnabled"] == "1";

            lowBoundsNumeric.Value = decimal.Parse(settings.Arguments["LowBoundValue"]);
            highBoundsNumeric.Value = decimal.Parse(settings.Arguments["HighBoundValue"]);
            lowBoundsNumeric.Enabled = lowBoundsCheckBox.Checked;
            highBoundsNumeric.Enabled = highBoundsCheckBox.Checked;
        }

        private void lowBoundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lowBoundsNumeric.Enabled = lowBoundsCheckBox.Checked;
        }

        private void highBoundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            highBoundsNumeric.Enabled = highBoundsCheckBox.Checked;
        }
    }
}
