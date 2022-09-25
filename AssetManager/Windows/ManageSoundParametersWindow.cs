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
    public partial class ManageSoundParametersWindow : Form
    {
        static List<MainWindow.SoundParameterDisplayListEntry> soundParameterDisplayList = new List<MainWindow.SoundParameterDisplayListEntry>();
        public MainWindow Parent;
        Dictionary<string, string> typeComboBoxDataSource = new Dictionary<string, string>();
        Dictionary<string, string> channelComboBoxDataSource = new Dictionary<string, string>();
        public ManageSoundParametersWindow()
        {
            InitializeComponent();

            foreach (SoundParameterType type in SoundParameterType.soundParameterTypeList)
            {
                typeComboBoxDataSource.Add(type.ParameterInternalName, type.ParameterName);
            }
            soundTypeComboBox.DataSource = new BindingSource(typeComboBoxDataSource, null);
            soundTypeComboBox.DisplayMember = "Value";
            soundTypeComboBox.ValueMember = "Key";

            RefreshParameterList();

            if (soundParameterDisplayList.Count == 0)
            {
                soundParameterName.Enabled = false;
                useRandomChoiceCheckBox.Enabled = false;
                soundFileListingDataGridView.Enabled = false;
                soundTypeComboBox.Enabled = false;
                RemoveParameterButton.Enabled = false;

                //soundRegexParameter.Enabled = false;
                //enableAllButton.Enabled = false;
                //disableAllButton.Enabled = false;

                replaceSettingsGroup.Enabled = false;
                soundscriptSettingsGroup.Enabled = true;
                regexSettingsGroup.Enabled = false;
            }
            modifyChannelComboBox.Items.AddRange(Enum.GetNames(typeof(Channels)));
            soundTypeComboBox_SelectedIndexChanged(soundTypeComboBox, null);
        }

        private void ManageSoundParametersWindow_Load(object sender, EventArgs e)
        {
            
        }

        public void RefreshParameterList()
        {
            soundParameterDisplayList.Clear();
            foreach (SoundParameter param in XMLInteraction.soundParametersList)
            {
                soundParameterDisplayList.Add(new MainWindow.SoundParameterDisplayListEntry() { Position = soundParameterDisplayList.Count, Param = param, ParamName = param.ParamName });
            }
            soundParameterList.DataSource = null;
            soundParameterList.DataSource = soundParameterDisplayList;
            soundParameterList.DisplayMember = "ParamName";
            soundParameterList.ValueMember = "Position";
            
        }

        private void soundTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = soundTypeComboBox.SelectedValue.ToString();
            if (selectedValue == "replacesoundscript")
            {
                if (soundParameterList.SelectedIndex != -1)
                {
                    XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Actions = SoundActions.ReplaceFileEntry;
                }
                replaceSettingsGroup.Visible = true;
                soundscriptSettingsGroup.Visible = false;
                regexFileSettingsGroup.Visible = false;
                regexSettingsGroup.Visible = true;
            }
            if (selectedValue == "modifysoundscript")
            {
                if (soundParameterList.SelectedIndex != -1)
                {
                    XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Actions = SoundActions.ModifySoundscript;
                }
                replaceSettingsGroup.Visible = false;
                soundscriptSettingsGroup.Visible = true;
                regexFileSettingsGroup.Visible = false;
                regexSettingsGroup.Visible = true;

                modifyChannelComboBox.Enabled = modifyChannelCheckBox.Checked;
                modifyVolumeTextBox.Enabled = modifyVolumeCheckBox.Checked;
                modifyPitchTextBox.Enabled = modifyPitchCheckBox.Checked;
                modifySoundlevelTextBox.Enabled = modifySoundlevelCheckBox.Checked;

                if (!XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry.HasValue)
                {
                    XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry = new SoundscriptEntry();
                }
            }
            if (selectedValue == "replacesoundfile")
            {
                if (soundParameterList.SelectedIndex != -1)
                {
                    XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Actions = SoundActions.ReplaceFileDirect;
                }
                replaceSettingsGroup.Visible = true;
                soundscriptSettingsGroup.Visible = false;
                regexFileSettingsGroup.Visible = true;
                regexSettingsGroup.Visible = false;
            }
        }

        private void AddParameterButton_Click(object sender, EventArgs e)
        {
            ParameterAddForm form = new ParameterAddForm
            {
                parent = this,
                context = ParameterAddForm.ParameterContext.Sound
            };
            form.ShowDialog();
        }

        private void RemoveParameterButton_Click(object sender, EventArgs e)
        {
            if (soundParameterList.SelectedIndex != -1)
            {
                soundParameterList.BeginUpdate();
                XMLInteraction.soundParametersList.RemoveAt(soundParameterList.SelectedIndex);
                RefreshParameterList();
                soundParameterList.EndUpdate();
            }
        }

        private void soundFileListingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridSender = (DataGridView)sender;
            if (dataGridSender.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex > -1)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)dataGridSender.Rows[e.RowIndex].Cells[0];
                checkBox.Value = !(bool)checkBox.Value;
                string selectedLocation = dataGridSender.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                if ((bool)checkBox.Value == true)
                {
                    XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.Add(new SoundFileEntry
                    {
                        id = e.RowIndex,
                        fileLocation = selectedLocation
                    });
                }
                else
                {
                    XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.Remove(
                        XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.First
                        (x => x.fileLocation == selectedLocation));
                }
            }
            if (dataGridSender.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell button = (DataGridViewButtonCell)dataGridSender.Rows[e.RowIndex].Cells[2];
                //Cell 0 contains the location.
                string location = dataGridSender.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                if (WAVInteraction.AssignNewSound(location))
                {
                    WAVInteraction.PlaySound();
                    button.Value = "Stop Sound";
                    foreach (DataGridViewRow row in dataGridSender.Rows)
                    {
                        if (row.Index == e.RowIndex)
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    WAVInteraction.StopSound();
                    button.Value = "Play Sound";
                }
            }
        }

        private void ManageSoundParametersWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parent.RefreshSoundParameterList();
        }

        private void soundRegexParameter_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Regex = soundRegexParameter.Text;
        }

        private void soundParameterName_TextChanged(object sender, EventArgs e)
        {
            XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].ParamName = soundParameterName.Text;
        }

        private void soundParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool validSelection = soundParameterList.SelectedIndex != -1;

            if(validSelection)
            {
                SoundParameter selectedParameter = XMLInteraction.soundParametersList[soundParameterList.SelectedIndex];
                SoundParameterType selectedParamType = SoundParameterType.soundParameterTypeList[(int)selectedParameter.Actions];
                soundTypeComboBox.SelectedIndex = (int)selectedParameter.Actions;
                if (selectedParamType.ParameterInternalName == "replacesoundscript")
                {
                    soundParameterName.Text = selectedParameter.ParamName;
                    //soundTypeComboBox.SelectedValue = selectedParamType.ParameterInternalName;
                    soundRegexParameter.Text = selectedParameter.Regex;
                    useRandomChoiceCheckBox.Checked = selectedParameter.ReplaceUsingRndWave;
                    soundFileListingDataGridView.Rows.Clear();
                    foreach (SoundFileEntry entry in XMLInteraction.soundFilesList)
                    {
                        bool enabled = XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.Contains(entry);
                        soundFileListingDataGridView.Rows.Add(enabled, entry.fileLocation, "Play Sound");
                    }
                }
                if (selectedParamType.ParameterInternalName == "modifysoundscript")
                {
                    if(!selectedParameter.Entry.HasValue)
                    {
                        XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry = new SoundscriptEntry();
                    }
                    SoundscriptEntry entry = selectedParameter.Entry.Value;
                    modifyChannelCheckBox.Checked = entry.channel != Channels.Unchanged;
                    modifyChannelComboBox.SelectedValue = entry.channel;
                    modifyVolumeCheckBox.Checked = entry.volume != string.Empty;
                    modifyVolumeTextBox.Text = entry.volume;
                    modifyPitchCheckBox.Checked = entry.pitch != string.Empty;
                    modifyPitchTextBox.Text = entry.pitch;
                    modifySoundlevelCheckBox.Checked = entry.soundlevel != string.Empty;
                    modifySoundlevelTextBox.Text = entry.soundlevel;
                }
            }
            soundParameterName.Enabled = validSelection;
            useRandomChoiceCheckBox.Enabled = validSelection;
            soundFileListingDataGridView.Enabled = validSelection;
            soundTypeComboBox.Enabled = validSelection;
            RemoveParameterButton.Enabled = validSelection;
            //soundRegexParameter.Enabled = validSelection;
            //enableAllButton.Enabled = validSelection;
            //disableAllButton.Enabled = validSelection;

            replaceSettingsGroup.Enabled = validSelection;
            soundscriptSettingsGroup.Enabled = validSelection;
            regexSettingsGroup.Enabled = validSelection;
        }

        private void useRandomChoiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].ReplaceUsingRndWave = useRandomChoiceCheckBox.Enabled;
        }

        private void disableAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in soundFileListingDataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells[0];
                checkBox.Value = false;
                string selectedLocation = row.Cells[1].FormattedValue.ToString();
                bool exists = XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.Any(x => x.fileLocation == selectedLocation);
                if (exists)
                {
                    XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.Remove(XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.First
                    (x => x.fileLocation == selectedLocation));
                }
            }
        }

        private void enableAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in soundFileListingDataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells[0];
                checkBox.Value = true;
                string selectedLocation = row.Cells[1].FormattedValue.ToString();
                bool exists = XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.Any(x => x.fileLocation == selectedLocation);
                if (!exists)
                {
                    XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Sounds.Add(new SoundFileEntry
                    {
                        id = row.Index,
                        fileLocation = selectedLocation
                    });
                }
                
            }
        }

        private void modifyChannelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            modifyChannelComboBox.Enabled = modifyChannelCheckBox.Checked;
        }

        private void modifyVolumeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            modifyVolumeTextBox.Enabled = modifyVolumeCheckBox.Checked;
        }

        private void modifyPitchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            modifyPitchTextBox.Enabled = modifyPitchCheckBox.Checked;
        }

        private void modifySoundlevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            modifySoundlevelTextBox.Enabled = modifySoundlevelCheckBox.Checked;
        }

        private void modifyChannelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoundscriptEntry currentEntryValue = XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry.Value;
            XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry = new SoundscriptEntry
            {
                channel = (Channels)modifyChannelComboBox.SelectedIndex,
                volume = currentEntryValue.volume,
                pitch = currentEntryValue.pitch,
                soundlevel = currentEntryValue.soundlevel
            };
        }

        private void modifyVolumeTextBox_TextChanged(object sender, EventArgs e)
        {
            SoundscriptEntry currentEntryValue = XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry.Value;
            XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry = new SoundscriptEntry
            {
                channel = currentEntryValue.channel,
                volume = modifyVolumeTextBox.Text,
                pitch = currentEntryValue.pitch,
                soundlevel = currentEntryValue.soundlevel
            };
        }

        private void modifyPitchTextBox_TextChanged(object sender, EventArgs e)
        {
            SoundscriptEntry currentEntryValue = XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry.Value;
            XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry = new SoundscriptEntry
            {
                channel = currentEntryValue.channel,
                volume = currentEntryValue.volume,
                pitch = modifyPitchTextBox.Text,
                soundlevel = currentEntryValue.soundlevel
            };
        }

        private void modifySoundlevelTextBox_TextChanged(object sender, EventArgs e)
        {
            SoundscriptEntry currentEntryValue = XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry.Value;
            XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].Entry = new SoundscriptEntry
            {
                channel = currentEntryValue.channel,
                volume = currentEntryValue.volume,
                pitch = currentEntryValue.pitch,
                soundlevel = modifySoundlevelTextBox.Text
            };
        }
    }
}
