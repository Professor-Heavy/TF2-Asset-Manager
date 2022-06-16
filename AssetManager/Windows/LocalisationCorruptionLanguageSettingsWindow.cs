using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManager
{
    public partial class LocalisationCorruptionLanguageSettings : Form
    {
        public LocalisationCorruptionSettings settings;
        class LanguageSettings
        {
            public bool enabled;
            public string language;
            public bool regexOverrideEnabled;
            public string regexOverrideValue;
            public bool weightOverrideEnabled;
            public decimal weightOverrideValue;
        }
        List<LanguageSettings> languages;
        string[] availableLanguages;
        LanguageSettings currentlySelectedLanguage;
        public LocalisationCorruptionLanguageSettings()
        {
            InitializeComponent();
        }

        string fileFormatPattern = @"tf_(.*)\.txt";

        private void LocalisationCorruptionLanguageSettings_Load(object sender, EventArgs e)
        {
            string[] languagesEnabled = settings.Arguments["LanguagesEnabled"].Split(',');
            
            string[] overrideRegexEnabled = settings.Arguments["OverrideRegexEnabled"].Split(',');
            //TODO: I don't even think it's worth mentioning just why this next line is a bad idea.
            //The regex could clash with the split delimiter if ,s are used in the regex pattern.
            string[] overrideRegexValues = settings.Arguments["OverrideRegexValues"].Split(',');
            string[] overrideWeightEnabled = settings.Arguments["OverrideWeightEnabled"].Split(',');
            string[] overrideWeightValues = settings.Arguments["OverrideWeightValues"].Split(',');
            languages = new List<LanguageSettings>();
            for (int i = 0; i < languagesEnabled.Length; i++)
            {
                languages.Add(new LanguageSettings
                {
                    enabled = true,
                    language = languagesEnabled[i],
                    regexOverrideEnabled = int.Parse(overrideRegexEnabled[i]) >= 1,
                    regexOverrideValue = overrideRegexValues[i],
                    weightOverrideEnabled = int.Parse(overrideWeightEnabled[i]) >= 1,
                    weightOverrideValue = decimal.Parse(overrideWeightValues[i])
                });
            }
            //Using the properites directly may be a better idea in overall code.
            availableLanguages = TXTInteraction.CheckLanguages(Properties.Settings.Default.GameLocation, true);
            localisationLanguageList.Items.AddRange(availableLanguages);
            
            foreach (string language in languagesEnabled)
            {
                int index = Array.IndexOf(availableLanguages, string.Format("tf_{0}.txt", language));
                localisationLanguageList.SetItemChecked(index, true);
            }

            globalRegexEnabledCheckBox.Checked = settings.Arguments["GlobalRegexEnabled"] == "true";
            globalRegexTextBox.Enabled = globalRegexEnabledCheckBox.Checked;
            globalRegexTextBox.Text = settings.Arguments["GlobalRegex"];
            globalWeightsNumericEntry.Value = decimal.Parse(settings.Arguments["GlobalWeight"]);
        }

        private void localisationLanguageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            languageOverrideGroupBox.Visible = localisationLanguageList.SelectedIndex >= 0;
            bool isEnabled = localisationLanguageList.GetItemChecked(localisationLanguageList.SelectedIndex);
            languageOverrideGroupBox.Enabled = isEnabled;

            languageOverrideGroupBox.Text = "Language Override Settings (" + availableLanguages[localisationLanguageList.SelectedIndex] + ")";

            string langParseFromFileName = Regex.Match(availableLanguages[localisationLanguageList.SelectedIndex], fileFormatPattern).Groups[1].Value;
            bool isLanguageInList = languages.Where(x => x.language == langParseFromFileName).Count() > 0;
            if (isLanguageInList)
            {
                currentlySelectedLanguage = languages.First(x => x.language == langParseFromFileName);
            }
            if (isEnabled)
            {
                if (!isLanguageInList)
                {
                    //Was just enabled. No doubt.
                    languages.Add(new LanguageSettings()
                    {
                        enabled = true,
                        language = langParseFromFileName,
                        regexOverrideEnabled = false,
                        regexOverrideValue = "",
                        weightOverrideEnabled = false,
                        weightOverrideValue = 1.000m
                    });
                    currentlySelectedLanguage = languages.Last();
                }
                overrideRegexCheckBox.Checked = currentlySelectedLanguage.regexOverrideEnabled;
                overrideRegexTextBox.Text = currentlySelectedLanguage.regexOverrideValue;
                overrideWeightsCheckBox.Checked = currentlySelectedLanguage.weightOverrideEnabled;
                overrideWeightsNumericEntry.Value = currentlySelectedLanguage.weightOverrideValue;

                overrideRegexTextBox.Enabled = currentlySelectedLanguage.regexOverrideEnabled;
                overrideWeightsNumericEntry.Enabled = currentlySelectedLanguage.weightOverrideEnabled;
            }
            else
            {
                if (isLanguageInList)
                {
                    languages.Remove(currentlySelectedLanguage);
                }
            }

            
        }

        private void overrideRegexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            overrideRegexTextBox.Enabled = overrideRegexCheckBox.Checked;
            currentlySelectedLanguage.regexOverrideEnabled = overrideRegexCheckBox.Checked;
        }

        private void overrideWeightsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            overrideWeightsNumericEntry.Enabled = overrideWeightsCheckBox.Checked;
            currentlySelectedLanguage.weightOverrideEnabled = overrideWeightsCheckBox.Checked;
        }

        private void globalRegexEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalRegexTextBox.Enabled = globalRegexEnabledCheckBox.Checked;
        }

        private void globalRegexTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void globalWeightsNumericEntry_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            settings.Arguments["GlobalRegexEnabled"] = globalRegexEnabledCheckBox.Checked ? "true" : "false";
            settings.Arguments["GlobalRegex"] = globalRegexTextBox.Text;
            settings.Arguments["GlobalWeight"] = globalWeightsNumericEntry.Value.ToString();

            settings.Arguments["LanguagesEnabled"] = string.Join(",", languages.Select(x => x.language));
            settings.Arguments["OverrideRegexEnabled"] = string.Join(",", languages.Select(x => x.regexOverrideEnabled ? "1" : "0"));
            settings.Arguments["OverrideRegexValues"] = string.Join(",", languages.Select(x => x.regexOverrideValue));
            settings.Arguments["OverrideWeightEnabled"] = string.Join(",", languages.Select(x => x.weightOverrideEnabled ? "1" : "0"));
            settings.Arguments["OverrideWeightValues"] = string.Join(",", languages.Select(x => x.weightOverrideValue));
            settings.Arguments["IgnoreNoMatchingTokens"] = ignoreNoMatchingTokensCheckBox.Checked ? "true" : "false";
            Close();
        }

        private void overrideRegexTextBox_TextChanged(object sender, EventArgs e)
        {
            currentlySelectedLanguage.regexOverrideValue = overrideRegexTextBox.Text;
        }

        private void overrideWeightsNumericEntry_ValueChanged(object sender, EventArgs e)
        {
            currentlySelectedLanguage.weightOverrideValue = overrideWeightsNumericEntry.Value;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
