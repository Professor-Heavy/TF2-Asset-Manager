namespace AssetManager
{
    partial class SoundErrorResolveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.soundListBox = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.changeLocationButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.soundStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openSoundFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.messageTextBox.Location = new System.Drawing.Point(154, 12);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.Size = new System.Drawing.Size(456, 173);
            this.messageTextBox.TabIndex = 1;
            // 
            // soundListBox
            // 
            this.soundListBox.FormattingEnabled = true;
            this.soundListBox.Location = new System.Drawing.Point(12, 12);
            this.soundListBox.Name = "soundListBox";
            this.soundListBox.Size = new System.Drawing.Size(136, 173);
            this.soundListBox.TabIndex = 0;
            this.soundListBox.SelectedIndexChanged += new System.EventHandler(this.soundListBox_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(154, 188);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(143, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search Again";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // changeLocationButton
            // 
            this.changeLocationButton.Location = new System.Drawing.Point(468, 188);
            this.changeLocationButton.Name = "changeLocationButton";
            this.changeLocationButton.Size = new System.Drawing.Size(142, 23);
            this.changeLocationButton.TabIndex = 3;
            this.changeLocationButton.Text = "Change File Location";
            this.changeLocationButton.UseVisualStyleBackColor = true;
            this.changeLocationButton.Click += new System.EventHandler(this.changeLocationButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 214);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(622, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // soundStatusLabel
            // 
            this.soundStatusLabel.Name = "soundStatusLabel";
            this.soundStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // openSoundFileDialog
            // 
            this.openSoundFileDialog.Filter = "Audio Files|*.wav;*.mp3";
            this.openSoundFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openSoundFileDialog_FileOk);
            // 
            // SoundErrorResolveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 236);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.changeLocationButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.soundListBox);
            this.Controls.Add(this.messageTextBox);
            this.Name = "SoundErrorResolveForm";
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.Load += new System.EventHandler(this.SoundErrorResolveForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.ListBox soundListBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button changeLocationButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel soundStatusLabel;
        private System.Windows.Forms.OpenFileDialog openSoundFileDialog;
    }
}