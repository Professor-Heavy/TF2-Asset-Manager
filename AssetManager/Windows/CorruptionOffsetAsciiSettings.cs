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
            Random random = new Random();
            offsetPreviewTextBox.Text = TXTInteraction.OffsetStringDecimal(originalText, null, asciiSettings, true, random);
            if(TXTInteraction.OffsetGoesBeyondRange(originalText, null, asciiSettings, true, random))
            {
                corruptionOffsetWarningStatusLabel.Text = "Character goes beyond UTF-18 character limits.";
            }
            else
            {
                corruptionOffsetWarningStatusLabel.Text = string.Empty;
            }
        }

        private void simulateExampleButton_Click(object sender, EventArgs e)
        {
            AsciiSettings example = new AsciiSettings
            {
                OffsetLow = (int)offsetExampleNumeric.Value,
                OffsetHigh = (int)offsetExampleNumeric.Value,
                LowBoundEnabled = false,
                HighBoundEnabled = false,
                LowBoundValue = 0,
                HighBoundValue = 0,
                OutOfRangeSolver = OutOfRangeSolvers.StrictEnforce
            };
            Random random = new Random();
            offsetPreviewTextBox.Text = TXTInteraction.OffsetStringDecimal(originalText, null, example, true, random);

            if (TXTInteraction.OffsetGoesBeyondRange(originalText, null, example, true, random))
            {
                corruptionOffsetWarningStatusLabel.Text = "Character goes beyond UTF-18 character limits.";
            }
            else
            {
                corruptionOffsetWarningStatusLabel.Text = string.Empty;
            }
        }

        private void CorruptionOffsetAsciiSettings_Load(object sender, EventArgs e)
        {
            asciiSettings.OffsetLow = int.Parse(settings.Arguments["OffsetLow"]);
            asciiSettings.OffsetHigh = int.Parse(settings.Arguments["OffsetHigh"]);
            asciiSettings.LowBoundEnabled = settings.Arguments["LowBoundEnabled"] == "1";
            asciiSettings.HighBoundEnabled = settings.Arguments["HighBoundEnabled"] == "1";
            asciiSettings.LowBoundValue = int.Parse(settings.Arguments["LowBoundValue"]);
            asciiSettings.HighBoundValue = int.Parse(settings.Arguments["HighBoundValue"]);
            if(settings.Arguments.ContainsKey("OutOfRangeSolver"))
            {
                asciiSettings.OutOfRangeSolver = (OutOfRangeSolvers)int.Parse(settings.Arguments["OutOfRangeSolver"]);
            }
            corruptionLowOffsetNumeric.Value = asciiSettings.OffsetLow;
            corruptionHighOffsetNumeric.Value = asciiSettings.OffsetHigh;
            lowBoundsCheckBox.Checked = asciiSettings.LowBoundEnabled;
            highBoundsCheckBox.Checked = asciiSettings.HighBoundEnabled;

            lowBoundsNumeric.Value = asciiSettings.LowBoundValue;
            highBoundsNumeric.Value = asciiSettings.HighBoundValue;
            lowBoundsNumeric.Enabled = lowBoundsCheckBox.Checked;
            highBoundsNumeric.Enabled = highBoundsCheckBox.Checked;

            outOfRangeResolveComboBox.SelectedIndex = (int)asciiSettings.OutOfRangeSolver;
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
            settings.Arguments["OutOfRangeSolver"] = ((int)asciiSettings.OutOfRangeSolver).ToString();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void outOfRangeResolveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            asciiSettings.OutOfRangeSolver = (OutOfRangeSolvers)outOfRangeResolveComboBox.SelectedIndex;
        }
    }
}
