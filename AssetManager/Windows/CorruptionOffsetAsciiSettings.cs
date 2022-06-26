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
    public partial class CorruptionOffsetAsciiSettings : Form
    {
        public LocalisationCorruptionSettings settings;
        AsciiSettings asciiSettings = new AsciiSettings();

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorruptionOffsetAsciiSettings));
        string originalText;
        public CorruptionOffsetAsciiSettings()
        {
            originalText = resources.GetString("offsetPreviewTextBox.Text");
            InitializeComponent();
        }

        private void simulateCorruptionButton_Click(object sender, EventArgs e)
        {
            offsetPreviewTextBox.Text = TXTInteraction.OffsetStringDecimal(originalText, null, asciiSettings, true);
        }

        private void simulateExampleButton_Click(object sender, EventArgs e)
        {
            offsetPreviewTextBox.Text = TXTInteraction.OffsetStringDecimal(originalText, null, new AsciiSettings
            {
                OffsetLow = (int)offsetExampleNumeric.Value,
                OffsetHigh = (int)offsetExampleNumeric.Value,
                LowBoundEnabled = false,
                HighBoundEnabled = false,
                LowBoundValue = 0,
                HighBoundValue = 0
            }, true);
        }

        private void CorruptionOffsetAsciiSettings_Load(object sender, EventArgs e)
        {
            asciiSettings.OffsetLow = int.Parse(settings.Arguments["OffsetLow"]);
            asciiSettings.OffsetHigh = int.Parse(settings.Arguments["OffsetHigh"]);
            asciiSettings.LowBoundEnabled = settings.Arguments["LowBoundEnabled"] == "1";
            asciiSettings.HighBoundEnabled = settings.Arguments["HighBoundEnabled"] == "1";
            asciiSettings.LowBoundValue = int.Parse(settings.Arguments["LowBoundValue"]);
            asciiSettings.HighBoundValue = int.Parse(settings.Arguments["HighBoundValue"]);

            corruptionLowOffsetNumeric.Value = asciiSettings.OffsetLow;
            corruptionHighOffsetNumeric.Value = asciiSettings.OffsetHigh;
            lowBoundsCheckBox.Checked = asciiSettings.LowBoundEnabled;
            highBoundsCheckBox.Checked = asciiSettings.HighBoundEnabled;

            lowBoundsNumeric.Value = asciiSettings.LowBoundValue;
            highBoundsNumeric.Value = asciiSettings.HighBoundValue;
            lowBoundsNumeric.Enabled = lowBoundsCheckBox.Checked;
            highBoundsNumeric.Enabled = highBoundsCheckBox.Checked;
        }

        private void corruptionLowOffsetNumeric_ValueChanged(object sender, EventArgs e)
        {
            asciiSettings.OffsetLow = (int)corruptionLowOffsetNumeric.Value;
        }

        private void corruptionHighOffsetNumeric_ValueChanged(object sender, EventArgs e)
        {
            asciiSettings.OffsetHigh = (int)corruptionHighOffsetNumeric.Value;
        }

        private void lowBoundsNumeric_ValueChanged(object sender, EventArgs e)
        {
            asciiSettings.LowBoundValue = (int)lowBoundsNumeric.Value;
        }

        private void highBoundsNumeric_ValueChanged(object sender, EventArgs e)
        {
            asciiSettings.HighBoundValue = (int)highBoundsNumeric.Value;
        }

        private void lowBoundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            asciiSettings.LowBoundEnabled = lowBoundsCheckBox.Checked;
            lowBoundsNumeric.Enabled = lowBoundsCheckBox.Checked;
        }

        private void highBoundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            asciiSettings.HighBoundEnabled = highBoundsCheckBox.Checked;
            highBoundsNumeric.Enabled = highBoundsCheckBox.Checked;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            settings.Arguments["OffsetLow"] = asciiSettings.OffsetLow.ToString();
            settings.Arguments["OffsetHigh"] = asciiSettings.OffsetHigh.ToString();
            settings.Arguments["LowBoundEnabled"] = asciiSettings.LowBoundEnabled ? "1" : "0";
            settings.Arguments["HighBoundEnabled"] = asciiSettings.HighBoundEnabled ? "1" : "0";
            settings.Arguments["LowBoundValue"] = asciiSettings.LowBoundValue.ToString();
            settings.Arguments["HighBoundValue"] = asciiSettings.HighBoundValue.ToString();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
