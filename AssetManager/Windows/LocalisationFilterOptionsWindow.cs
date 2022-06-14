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
    public partial class LocalisationFilterOptionsWindow : Form
    {
        public LocalisationCorruptionSettings settings;
        public LocalisationFilterOptionsWindow()
        {
            InitializeComponent();
        }

        private void LocalisationFilterOptionsWindow_Load(object sender, EventArgs e)
        {
            keyFiltersTextBox.Text = string.Join(Environment.NewLine, settings.KeyFilterArray.ToArray());

            regexFilteringCheckBox.Checked = settings.RegularExpressionEnabled;
            regexFilteringTextBox.Text = settings.RegularExpressionPattern;
            regexFilteringExclusionCheckBox.Checked = settings.RegularExpressionMode == 0; //TODO: Everything follows a pattern of exclude = 0, maybe there's an easy way to simplify every reference to exclusion.
            regexFilteringTextBox.Enabled = settings.RegularExpressionEnabled;
            regexFilteringExclusionCheckBox.Enabled = settings.RegularExpressionEnabled;
            regexForMatchesAndSwapsCheckBox.Enabled = settings.RegularExpressionEnabled;
            safeModeFilterCheckBox.Checked = settings.SafeMode;
            safeModeNewlinesCheckBox.Checked = settings.IgnoreNewlines;
            safeModeSkipUnsafeCheckBox.Checked = settings.SkipUnsafeEntries;
            if(settings.CorruptionType == LocalisationCorruptionSettings.CorruptionTypes.SwapEntries)
            {
                regexForMatchesAndSwapsCheckBox.Checked = settings.Arguments["RegexForMatchesAndSwaps"] == "true";
            }
            else
            {
                regexForMatchesAndSwapsCheckBox.Enabled = false;
            }
            

            if (settings.KeyFilterMode == 1)
            {
                keyFiltersIncludeRadioButton.Checked = true;
                keyFiltersExcludeRadioButton.Checked = false;
            }
            else
            {
                keyFiltersExcludeRadioButton.Checked = true;
                keyFiltersIncludeRadioButton.Checked = false;
            }

        }

        private void regexFilteringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            regexFilteringTextBox.Enabled = regexFilteringCheckBox.Checked;
            regexFilteringExclusionCheckBox.Enabled = regexFilteringCheckBox.Checked;
            regexForMatchesAndSwapsCheckBox.Enabled = regexFilteringCheckBox.Checked;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            settings.KeyFilterMode = keyFiltersExcludeRadioButton.Checked ? 0 : 1;
            string[] keyFilters = keyFiltersTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            settings.KeyFilterArray.Clear();
            settings.KeyFilterArray.AddRange(keyFilters);

            settings.RegularExpressionEnabled = regexFilteringCheckBox.Checked;
            settings.RegularExpressionPattern = regexFilteringTextBox.Text;
            settings.RegularExpressionMode = regexFilteringExclusionCheckBox.Checked ? 0 : 1;
            settings.SafeMode = safeModeFilterCheckBox.Checked;
            settings.IgnoreNewlines = safeModeNewlinesCheckBox.Checked;
            settings.SkipUnsafeEntries = safeModeSkipUnsafeCheckBox.Checked;

            if (settings.CorruptionType == LocalisationCorruptionSettings.CorruptionTypes.SwapEntries)
            {
                settings.Arguments["RegexForMatchesAndSwaps"] = regexForMatchesAndSwapsCheckBox.Checked ? "true" : "false";
            }

            Close();
        }
    }
}
