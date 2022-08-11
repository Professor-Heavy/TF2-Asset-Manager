using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManager
{
    public partial class ManageLocalisationParametersWindow : Form
    {
        static List<MainWindow.LocalisationParameterDisplayListEntry> localisationParameterDisplayList = new List<MainWindow.LocalisationParameterDisplayListEntry>();

        public MainWindow Parent;

        Dictionary<string, string> comboBoxDataSource = new Dictionary<string, string>();
        public ManageLocalisationParametersWindow()
        {
            InitializeComponent();

            foreach (LocalisationParameterType type in LocalisationParameterType.localisationParameterTypeList)
            {
                comboBoxDataSource.Add(type.ParameterInternalName, type.ParameterName);
            }
            localisationTypeComboBox.DataSource = new BindingSource(comboBoxDataSource, null);
            localisationTypeComboBox.DisplayMember = "Value";
            localisationTypeComboBox.ValueMember = "Key";

            RefreshParameterList();

            LocalisationTypeComboBox_SelectedIndexChanged(localisationTypeComboBox, null);
        }

        public void RefreshParameterList()
        {
            localisationParameterDisplayList.Clear();
            foreach (LocalisationParameter param in XMLInteraction.localisationParametersList)
            {
                localisationParameterDisplayList.Add(new MainWindow.LocalisationParameterDisplayListEntry() { Position = localisationParameterDisplayList.Count, Param = param, ParamName = param.ParamName });
            }
            localisationParameterList.DataSource = null;
            localisationParameterList.DataSource = localisationParameterDisplayList;
            localisationParameterList.DisplayMember = "ParamName";
            localisationParameterList.ValueMember = "Position";
        }

        private void RegexCheckButton_Click(object sender, EventArgs e)
        {
            regexPreviewTextBox.ForeColor = Color.Black;
            try
            {
                bool regexResult = CheckRegexWithPreview(); 
                if(!regexResult)
                {
                    DialogResult warningWindowResult = MessageBox.Show("Regex did not match anything in the preview.\nWould you like to try matching by the localisation file and displaying the results?\nThis may take a while.", "No matches found", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if(warningWindowResult == DialogResult.Yes)
                    {
                        statusBarText.Text = "Searching tf_english.txt...";
                        this.Enabled = false;
                        ConfirmSearch();
                    }
                }
            }
            catch(ArgumentException error)
            {
                statusBarText.Text = "An error occured when parsing the regex pattern: " + error.Message;
                this.Enabled = true;
            }
        }

        private void ConfirmSearch()
        {
            string userRegex = localisationRegexParameter.Text;
            string rawString;
            try
            {
                rawString = File.ReadAllText(Path.Combine(Properties.Settings.Default.GameLocation, "tf\\resource\\tf_english.txt"));
                Dictionary<string, string> regexEntries = TXTInteraction.PerformRegexTest(rawString);
                Dictionary<string, string> regexMatches = new Dictionary<string, string>();
                foreach (KeyValuePair<string,string> entry in regexEntries)
                {
                    if (Regex.Match(entry.Value, userRegex).Success)
                    {
                        regexMatches.Add(entry.Key, entry.Value);
                    }
                }
                if (regexMatches.Count != 0)
                {
                    statusBarText.Text = regexMatches.Count + " matches found.";
                    RegexMatchDisplayWindow f2 = new RegexMatchDisplayWindow
                    {
                        results = regexMatches
                    };
                    f2.ShowDialog();
                }
                else
                {
                    statusBarText.Text = "No matches found.";
                }
                this.Enabled = true;
            }
            catch(IOException ex)
            {
                statusBarText.Text = "Unable to read localisation file. Please confirm that the file exists and that the installation directory is correct.";
                this.Enabled = true;
            }
        }

        private bool CheckRegexWithPreview()
        {
            statusBarText.Text = string.Empty;
            MatchCollection matches = TXTInteraction.PerformSingleRegexTest(regexPreviewTextBox.Text, localisationRegexParameter.Text);
            if(matches.Count != 0)
            {
                foreach(Match m in matches)
                {
                    regexPreviewTextBox.Select(m.Index, m.Length);
                    regexPreviewTextBox.SelectionColor = Color.Red;
                }
                return true;
            }
            return false;
        }

        private void RegexFilteringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            regexSettingsGroup.Enabled = regexFilteringCheckBox.Checked;
        }

        private void LocalisationParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (localisationParameterList.SelectedIndex == -1 || localisationParameterList.SelectedIndex >= localisationParameterList.Items.Count)
            {
                //TODO: Recent scenarios have come up lately in where users may just have nothing on this list at all. Sometimes they can just... remove everything.
                localisationParameterList.SelectedIndex = 0;
            }
            LocalisationParameter selectedParameter = XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex];
            LocalisationParameterType selectedParamType = LocalisationParameterType.localisationParameterTypeList[(int)selectedParameter.Actions];
            localisationParameterName.Text = selectedParameter.ParamName;
            localisationTypeComboBox.SelectedValue = selectedParamType.ParameterInternalName;
            localisationRegexParameter.Text = selectedParameter.Regex;
            replaceStringEntryTextBox.Text = selectedParameter.ReplaceString;
            regexFilteringCheckBox.Checked = selectedParameter.UsesRegex;
        }

        private void LocalisationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (localisationTypeComboBox.SelectedValue.ToString() == "replacechar")
            {
                regexFilteringCheckBox.Checked = true;
                regexFilteringCheckBox.Enabled = false;
                replaceStringEntryTextBox.Enabled = true;
            }
            else
            {
                regexFilteringCheckBox.Enabled = true;
                replaceStringEntryTextBox.Enabled = false;
            }
        }

        private void ReplaceStringEntryTextBox_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex].ReplaceString = replaceStringEntryTextBox.Text;
        }

        private void LocalisationRegexParameter_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex].Regex = localisationRegexParameter.Text;
        }

        private void LocalisationParameterName_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.localisationParametersList[localisationParameterList.SelectedIndex].ParamName = localisationParameterName.Text;
        }

        private async void ManageLocalisationParametersWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Parent.RefreshLocalisationParameterList();
            }
            catch (IOException)
            {
                statusBarText.Text = "Could not save settings. Configuration file may be missing or locked.";
                e.Cancel = true;
            }
        }

        private void AddParameterButton_Click(object sender, EventArgs e)
        {
            ParameterAddForm form = new ParameterAddForm
            {
                parent = this,
                context = ParameterAddForm.ParameterContext.Localisation
            };
            form.ShowDialog();
        }

        private void RemoveParameterButton_Click(object sender, EventArgs e)
        {

        }

        private void regexCheckFilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                statusBarText.Text = "Searching tf_english.txt...";
                this.Enabled = false;
                ConfirmSearch();
            }
            catch (ArgumentException error)
            {
                statusBarText.Text = "An error occured when parsing the regex pattern: " + error.Message;
                this.Enabled = true;
            }
        }
    }
}
