﻿using System;
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
        Dictionary<string, string> comboBoxDataSource = new Dictionary<string, string>();
        public ManageSoundParametersWindow()
        {
            InitializeComponent();

            foreach (SoundParameterType type in SoundParameterType.soundParameterTypeList)
            {
                comboBoxDataSource.Add(type.ParameterInternalName, type.ParameterName);
            }
            soundTypeComboBox.DataSource = new BindingSource(comboBoxDataSource, null);
            soundTypeComboBox.DisplayMember = "Value";
            soundTypeComboBox.ValueMember = "Key";

            RefreshParameterList();

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
            soundParameterName.Enabled = validSelection;
            useRandomChoiceCheckBox.Enabled = validSelection;
            soundFileListingDataGridView.Enabled = validSelection;
            soundTypeComboBox.Enabled = validSelection;
            soundRegexParameter.Enabled = validSelection;
            RemoveParameterButton.Enabled = validSelection;
        }

        private void useRandomChoiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            XMLInteraction.soundParametersList[soundParameterList.SelectedIndex].ReplaceUsingRndWave = useRandomChoiceCheckBox.Enabled;
        }
    }
}