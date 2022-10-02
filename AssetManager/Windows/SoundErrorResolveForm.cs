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
    public partial class SoundErrorResolveForm : Form
    {
        public SoundErrorResolveForm(params SoundFileEntry[] erroneousEntries)
        {
            InitializeComponent();
            entries = erroneousEntries;
        }

        SoundFileEntry[] entries = null;
        SoundFileEntry currentEntry
        {
            get { return entries[currentLoadedEntry]; }
        }
        int currentLoadedEntry = 0;

        string[] messages =
        {
            "This file is normal.\r\n\r\nNo action is required.",
            "The file \"{0}\" could not be found at the location \"{1}\".\r\n\r\nSearch again or check that the file exists.",
            "The file \"{0}\" could not be read as a valid audio file.\r\n\r\nUse a valid audio file.\r\nIf the file is a sound file, please send an issue report on this project's GitHub page.",
            "The file \"{0}\" has an incorrect sample rate.\r\n\r\nNo action is required.",
            "The file \"{0}\" has an incorrect bitrate.\r\n\r\nNo action is required."
        };
        private void SoundErrorResolveForm_Load(object sender, EventArgs e)
        {
            soundListBox.DataSource = entries;
            soundListBox.DisplayMember = "fileName";
            soundListBox.ValueMember = "fileLocation";
            LoadMessage();
        }

        private void LoadMessage()
        {
            messageTextBox.Text = string.Format(messages[(int)currentEntry.status], currentEntry.fileName, currentEntry.fileLocation);
        }

        private void LoadSecondaryMessage(SoundFileStatus newStatus)
        {
            if (newStatus == SoundFileStatus.Ok)
            {
                soundStatusLabel.Text = "Sound file exists and readable.";
            }
            if (newStatus > SoundFileStatus.AudioUnreadable)
            {
                soundStatusLabel.Text = "Sound file exists and readable. Displaying warning.";
            }
            if (newStatus == SoundFileStatus.LocationInvalid)
            {
                soundStatusLabel.Text = "Unable to find sound.";
            }
            if (XMLInteraction.VerifySoundFile(currentEntry.fileLocation) == SoundFileStatus.AudioUnreadable)
            {
                soundStatusLabel.Text = "Cannot read sound file.";
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SoundFileStatus initialStatus = currentEntry.status;
            SoundFileStatus newStatus = XMLInteraction.VerifySoundFile(currentEntry.fileLocation);
            LoadSecondaryMessage(newStatus);
            if(initialStatus != newStatus)
            {
                entries[currentLoadedEntry].status = newStatus;
            }
            XMLInteraction.ChangeSoundFile(currentEntry.id, currentEntry.fileLocation);
            LoadMessage();
        }

        private void soundListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLoadedEntry = soundListBox.SelectedIndex;
            LoadMessage();
        }

        private void openSoundFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            SoundFileStatus initialStatus = currentEntry.status;
            SoundFileStatus newStatus = XMLInteraction.VerifySoundFile(openSoundFileDialog.FileName);
            LoadSecondaryMessage(newStatus);
            if (initialStatus != newStatus)
            {
                entries[currentLoadedEntry].status = newStatus;
            }
            XMLInteraction.ChangeSoundFile(currentEntry.id, openSoundFileDialog.FileName);
            LoadMessage();
        }

        private void changeLocationButton_Click(object sender, EventArgs e)
        {
            openSoundFileDialog.ShowDialog();
        }
    }
}
