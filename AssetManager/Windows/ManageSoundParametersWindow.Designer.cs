namespace AssetManager
{
    partial class ManageSoundParametersWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.soundParameterList = new System.Windows.Forms.ListBox();
            this.RemoveParameterButton = new System.Windows.Forms.Button();
            this.AddParameterButton = new System.Windows.Forms.Button();
            this.soundTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.soundParameterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.regexSettingsGroup = new System.Windows.Forms.GroupBox();
            this.regexCheckFilesButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.soundRegexParameter = new System.Windows.Forms.TextBox();
            this.replaceSettingsGroup = new System.Windows.Forms.GroupBox();
            this.disableAllButton = new System.Windows.Forms.Button();
            this.enableAllButton = new System.Windows.Forms.Button();
            this.soundFileListingDataGridView = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviewButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.useRandomChoiceCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.soundscriptSettingsGroup = new System.Windows.Forms.GroupBox();
            this.modifySoundlevelTextBox = new System.Windows.Forms.TextBox();
            this.modifyPitchTextBox = new System.Windows.Forms.TextBox();
            this.modifyVolumeTextBox = new System.Windows.Forms.TextBox();
            this.modifySoundlevelCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.modifyPitchCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.modifyVolumeCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.modifyChannelComboBox = new System.Windows.Forms.ComboBox();
            this.modifyChannelCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.regexFileSettingsGroup = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.regexSettingsGroup.SuspendLayout();
            this.replaceSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundFileListingDataGridView)).BeginInit();
            this.soundscriptSettingsGroup.SuspendLayout();
            this.regexFileSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // soundParameterList
            // 
            this.soundParameterList.FormattingEnabled = true;
            this.soundParameterList.Location = new System.Drawing.Point(12, 12);
            this.soundParameterList.Name = "soundParameterList";
            this.soundParameterList.Size = new System.Drawing.Size(148, 420);
            this.soundParameterList.TabIndex = 18;
            this.soundParameterList.SelectedIndexChanged += new System.EventHandler(this.soundParameterList_SelectedIndexChanged);
            // 
            // RemoveParameterButton
            // 
            this.RemoveParameterButton.Location = new System.Drawing.Point(93, 438);
            this.RemoveParameterButton.Name = "RemoveParameterButton";
            this.RemoveParameterButton.Size = new System.Drawing.Size(67, 23);
            this.RemoveParameterButton.TabIndex = 20;
            this.RemoveParameterButton.Text = "Remove";
            this.RemoveParameterButton.UseVisualStyleBackColor = true;
            this.RemoveParameterButton.Click += new System.EventHandler(this.RemoveParameterButton_Click);
            // 
            // AddParameterButton
            // 
            this.AddParameterButton.Location = new System.Drawing.Point(12, 438);
            this.AddParameterButton.Name = "AddParameterButton";
            this.AddParameterButton.Size = new System.Drawing.Size(64, 23);
            this.AddParameterButton.TabIndex = 19;
            this.AddParameterButton.Text = "Add";
            this.AddParameterButton.UseVisualStyleBackColor = true;
            this.AddParameterButton.Click += new System.EventHandler(this.AddParameterButton_Click);
            // 
            // soundTypeComboBox
            // 
            this.soundTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.soundTypeComboBox.FormattingEnabled = true;
            this.soundTypeComboBox.Location = new System.Drawing.Point(581, 28);
            this.soundTypeComboBox.Name = "soundTypeComboBox";
            this.soundTypeComboBox.Size = new System.Drawing.Size(183, 21);
            this.soundTypeComboBox.TabIndex = 29;
            this.soundTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.soundTypeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Parameter Name";
            // 
            // soundParameterName
            // 
            this.soundParameterName.Location = new System.Drawing.Point(180, 29);
            this.soundParameterName.Name = "soundParameterName";
            this.soundParameterName.Size = new System.Drawing.Size(162, 20);
            this.soundParameterName.TabIndex = 28;
            this.soundParameterName.TextChanged += new System.EventHandler(this.soundParameterName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Parameter Type";
            // 
            // regexSettingsGroup
            // 
            this.regexSettingsGroup.Controls.Add(this.regexCheckFilesButton);
            this.regexSettingsGroup.Controls.Add(this.label3);
            this.regexSettingsGroup.Controls.Add(this.soundRegexParameter);
            this.regexSettingsGroup.Location = new System.Drawing.Point(180, 367);
            this.regexSettingsGroup.Name = "regexSettingsGroup";
            this.regexSettingsGroup.Size = new System.Drawing.Size(589, 68);
            this.regexSettingsGroup.TabIndex = 34;
            this.regexSettingsGroup.TabStop = false;
            this.regexSettingsGroup.Text = "Regular Expression (RegEx) Settings";
            // 
            // regexCheckFilesButton
            // 
            this.regexCheckFilesButton.Enabled = false;
            this.regexCheckFilesButton.Location = new System.Drawing.Point(461, 35);
            this.regexCheckFilesButton.Name = "regexCheckFilesButton";
            this.regexCheckFilesButton.Size = new System.Drawing.Size(122, 20);
            this.regexCheckFilesButton.TabIndex = 33;
            this.regexCheckFilesButton.Text = "Check Soundscripts";
            this.regexCheckFilesButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Soundscript Regular Expression Pattern";
            // 
            // soundRegexParameter
            // 
            this.soundRegexParameter.Location = new System.Drawing.Point(10, 35);
            this.soundRegexParameter.Name = "soundRegexParameter";
            this.soundRegexParameter.Size = new System.Drawing.Size(445, 20);
            this.soundRegexParameter.TabIndex = 24;
            this.soundRegexParameter.TextChanged += new System.EventHandler(this.soundRegexParameter_TextChanged);
            // 
            // replaceSettingsGroup
            // 
            this.replaceSettingsGroup.Controls.Add(this.disableAllButton);
            this.replaceSettingsGroup.Controls.Add(this.enableAllButton);
            this.replaceSettingsGroup.Controls.Add(this.soundFileListingDataGridView);
            this.replaceSettingsGroup.Controls.Add(this.useRandomChoiceCheckBox);
            this.replaceSettingsGroup.Location = new System.Drawing.Point(180, 67);
            this.replaceSettingsGroup.Name = "replaceSettingsGroup";
            this.replaceSettingsGroup.Size = new System.Drawing.Size(589, 294);
            this.replaceSettingsGroup.TabIndex = 35;
            this.replaceSettingsGroup.TabStop = false;
            this.replaceSettingsGroup.Text = "Replace Settings";
            // 
            // disableAllButton
            // 
            this.disableAllButton.Location = new System.Drawing.Point(293, 15);
            this.disableAllButton.Name = "disableAllButton";
            this.disableAllButton.Size = new System.Drawing.Size(75, 23);
            this.disableAllButton.TabIndex = 38;
            this.disableAllButton.Text = "Disable All";
            this.disableAllButton.UseVisualStyleBackColor = true;
            this.disableAllButton.Click += new System.EventHandler(this.disableAllButton_Click);
            // 
            // enableAllButton
            // 
            this.enableAllButton.Location = new System.Drawing.Point(374, 15);
            this.enableAllButton.Name = "enableAllButton";
            this.enableAllButton.Size = new System.Drawing.Size(75, 23);
            this.enableAllButton.TabIndex = 37;
            this.enableAllButton.Text = "Enable All";
            this.enableAllButton.UseVisualStyleBackColor = true;
            this.enableAllButton.Click += new System.EventHandler(this.enableAllButton_Click);
            // 
            // soundFileListingDataGridView
            // 
            this.soundFileListingDataGridView.AllowUserToAddRows = false;
            this.soundFileListingDataGridView.AllowUserToDeleteRows = false;
            this.soundFileListingDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.soundFileListingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.soundFileListingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Key,
            this.PreviewButton});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.soundFileListingDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.soundFileListingDataGridView.Location = new System.Drawing.Point(10, 42);
            this.soundFileListingDataGridView.Name = "soundFileListingDataGridView";
            this.soundFileListingDataGridView.ReadOnly = true;
            this.soundFileListingDataGridView.RowHeadersVisible = false;
            this.soundFileListingDataGridView.Size = new System.Drawing.Size(573, 246);
            this.soundFileListingDataGridView.TabIndex = 36;
            this.soundFileListingDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.soundFileListingDataGridView_CellContentClick);
            // 
            // Enable
            // 
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.ReadOnly = true;
            this.Enable.Width = 75;
            // 
            // Key
            // 
            this.Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Key.HeaderText = "Sound File";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            // 
            // PreviewButton
            // 
            this.PreviewButton.HeaderText = "Preview";
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.ReadOnly = true;
            this.PreviewButton.Text = "Play Sound";
            this.PreviewButton.Width = 145;
            // 
            // useRandomChoiceCheckBox
            // 
            this.useRandomChoiceCheckBox.AutoSize = true;
            this.useRandomChoiceCheckBox.Location = new System.Drawing.Point(10, 19);
            this.useRandomChoiceCheckBox.Name = "useRandomChoiceCheckBox";
            this.useRandomChoiceCheckBox.Size = new System.Drawing.Size(277, 17);
            this.useRandomChoiceCheckBox.TabIndex = 0;
            this.useRandomChoiceCheckBox.Text = "Use RandomChoice for Matching Soundscript Entries";
            this.useRandomChoiceCheckBox.UseVisualStyleBackColor = true;
            this.useRandomChoiceCheckBox.CheckedChanged += new System.EventHandler(this.useRandomChoiceCheckBox_CheckedChanged);
            // 
            // soundscriptSettingsGroup
            // 
            this.soundscriptSettingsGroup.Controls.Add(this.modifySoundlevelTextBox);
            this.soundscriptSettingsGroup.Controls.Add(this.modifyPitchTextBox);
            this.soundscriptSettingsGroup.Controls.Add(this.modifyVolumeTextBox);
            this.soundscriptSettingsGroup.Controls.Add(this.modifySoundlevelCheckBox);
            this.soundscriptSettingsGroup.Controls.Add(this.label7);
            this.soundscriptSettingsGroup.Controls.Add(this.modifyPitchCheckBox);
            this.soundscriptSettingsGroup.Controls.Add(this.label6);
            this.soundscriptSettingsGroup.Controls.Add(this.modifyVolumeCheckBox);
            this.soundscriptSettingsGroup.Controls.Add(this.label5);
            this.soundscriptSettingsGroup.Controls.Add(this.modifyChannelComboBox);
            this.soundscriptSettingsGroup.Controls.Add(this.modifyChannelCheckBox);
            this.soundscriptSettingsGroup.Controls.Add(this.label4);
            this.soundscriptSettingsGroup.Location = new System.Drawing.Point(180, 67);
            this.soundscriptSettingsGroup.Name = "soundscriptSettingsGroup";
            this.soundscriptSettingsGroup.Size = new System.Drawing.Size(219, 225);
            this.soundscriptSettingsGroup.TabIndex = 39;
            this.soundscriptSettingsGroup.TabStop = false;
            this.soundscriptSettingsGroup.Text = "Soundscript Settings";
            // 
            // modifySoundlevelTextBox
            // 
            this.modifySoundlevelTextBox.Location = new System.Drawing.Point(73, 180);
            this.modifySoundlevelTextBox.Name = "modifySoundlevelTextBox";
            this.modifySoundlevelTextBox.Size = new System.Drawing.Size(121, 20);
            this.modifySoundlevelTextBox.TabIndex = 14;
            this.modifySoundlevelTextBox.TextChanged += new System.EventHandler(this.modifySoundlevelTextBox_TextChanged);
            // 
            // modifyPitchTextBox
            // 
            this.modifyPitchTextBox.Location = new System.Drawing.Point(73, 134);
            this.modifyPitchTextBox.Name = "modifyPitchTextBox";
            this.modifyPitchTextBox.Size = new System.Drawing.Size(121, 20);
            this.modifyPitchTextBox.TabIndex = 13;
            this.modifyPitchTextBox.TextChanged += new System.EventHandler(this.modifyPitchTextBox_TextChanged);
            // 
            // modifyVolumeTextBox
            // 
            this.modifyVolumeTextBox.Location = new System.Drawing.Point(73, 87);
            this.modifyVolumeTextBox.Name = "modifyVolumeTextBox";
            this.modifyVolumeTextBox.Size = new System.Drawing.Size(121, 20);
            this.modifyVolumeTextBox.TabIndex = 12;
            this.modifyVolumeTextBox.TextChanged += new System.EventHandler(this.modifyVolumeTextBox_TextChanged);
            // 
            // modifySoundlevelCheckBox
            // 
            this.modifySoundlevelCheckBox.AutoSize = true;
            this.modifySoundlevelCheckBox.Location = new System.Drawing.Point(6, 160);
            this.modifySoundlevelCheckBox.Name = "modifySoundlevelCheckBox";
            this.modifySoundlevelCheckBox.Size = new System.Drawing.Size(143, 17);
            this.modifySoundlevelCheckBox.TabIndex = 10;
            this.modifySoundlevelCheckBox.Text = "Modify Soundlevel Value";
            this.modifySoundlevelCheckBox.UseVisualStyleBackColor = true;
            this.modifySoundlevelCheckBox.CheckedChanged += new System.EventHandler(this.modifySoundlevelCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Soundlevel";
            // 
            // modifyPitchCheckBox
            // 
            this.modifyPitchCheckBox.AutoSize = true;
            this.modifyPitchCheckBox.Location = new System.Drawing.Point(6, 113);
            this.modifyPitchCheckBox.Name = "modifyPitchCheckBox";
            this.modifyPitchCheckBox.Size = new System.Drawing.Size(114, 17);
            this.modifyPitchCheckBox.TabIndex = 7;
            this.modifyPitchCheckBox.Text = "Modify Pitch Value";
            this.modifyPitchCheckBox.UseVisualStyleBackColor = true;
            this.modifyPitchCheckBox.CheckedChanged += new System.EventHandler(this.modifyPitchCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pitch";
            // 
            // modifyVolumeCheckBox
            // 
            this.modifyVolumeCheckBox.AutoSize = true;
            this.modifyVolumeCheckBox.Location = new System.Drawing.Point(6, 66);
            this.modifyVolumeCheckBox.Name = "modifyVolumeCheckBox";
            this.modifyVolumeCheckBox.Size = new System.Drawing.Size(125, 17);
            this.modifyVolumeCheckBox.TabIndex = 4;
            this.modifyVolumeCheckBox.Text = "Modify Volume Value";
            this.modifyVolumeCheckBox.UseVisualStyleBackColor = true;
            this.modifyVolumeCheckBox.CheckedChanged += new System.EventHandler(this.modifyVolumeCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Volume";
            // 
            // modifyChannelComboBox
            // 
            this.modifyChannelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modifyChannelComboBox.FormattingEnabled = true;
            this.modifyChannelComboBox.Location = new System.Drawing.Point(73, 39);
            this.modifyChannelComboBox.Name = "modifyChannelComboBox";
            this.modifyChannelComboBox.Size = new System.Drawing.Size(121, 21);
            this.modifyChannelComboBox.TabIndex = 2;
            this.modifyChannelComboBox.SelectedIndexChanged += new System.EventHandler(this.modifyChannelComboBox_SelectedIndexChanged);
            // 
            // modifyChannelCheckBox
            // 
            this.modifyChannelCheckBox.AutoSize = true;
            this.modifyChannelCheckBox.Location = new System.Drawing.Point(6, 19);
            this.modifyChannelCheckBox.Name = "modifyChannelCheckBox";
            this.modifyChannelCheckBox.Size = new System.Drawing.Size(129, 17);
            this.modifyChannelCheckBox.TabIndex = 1;
            this.modifyChannelCheckBox.Text = "Modify Channel Value";
            this.modifyChannelCheckBox.UseVisualStyleBackColor = true;
            this.modifyChannelCheckBox.CheckedChanged += new System.EventHandler(this.modifyChannelCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Channel";
            // 
            // regexFileSettingsGroup
            // 
            this.regexFileSettingsGroup.Controls.Add(this.label8);
            this.regexFileSettingsGroup.Controls.Add(this.textBox1);
            this.regexFileSettingsGroup.Location = new System.Drawing.Point(180, 367);
            this.regexFileSettingsGroup.Name = "regexFileSettingsGroup";
            this.regexFileSettingsGroup.Size = new System.Drawing.Size(589, 62);
            this.regexFileSettingsGroup.TabIndex = 35;
            this.regexFileSettingsGroup.TabStop = false;
            this.regexFileSettingsGroup.Text = "Regular Expression (RegEx) Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(188, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Filename Regular Expression Pattern";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(557, 20);
            this.textBox1.TabIndex = 24;
            // 
            // ManageSoundParametersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 469);
            this.Controls.Add(this.regexFileSettingsGroup);
            this.Controls.Add(this.soundscriptSettingsGroup);
            this.Controls.Add(this.replaceSettingsGroup);
            this.Controls.Add(this.regexSettingsGroup);
            this.Controls.Add(this.soundTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.soundParameterName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.soundParameterList);
            this.Controls.Add(this.RemoveParameterButton);
            this.Controls.Add(this.AddParameterButton);
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.Name = "ManageSoundParametersWindow";
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageSoundParametersWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageSoundParametersWindow_Load);
            this.regexSettingsGroup.ResumeLayout(false);
            this.regexSettingsGroup.PerformLayout();
            this.replaceSettingsGroup.ResumeLayout(false);
            this.replaceSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundFileListingDataGridView)).EndInit();
            this.soundscriptSettingsGroup.ResumeLayout(false);
            this.soundscriptSettingsGroup.PerformLayout();
            this.regexFileSettingsGroup.ResumeLayout(false);
            this.regexFileSettingsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox soundParameterList;
        private System.Windows.Forms.Button RemoveParameterButton;
        private System.Windows.Forms.Button AddParameterButton;
        private System.Windows.Forms.ComboBox soundTypeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox soundParameterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox regexSettingsGroup;
        private System.Windows.Forms.Button regexCheckFilesButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox soundRegexParameter;
        private System.Windows.Forms.GroupBox replaceSettingsGroup;
        private System.Windows.Forms.CheckBox useRandomChoiceCheckBox;
        private System.Windows.Forms.DataGridView soundFileListingDataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewButtonColumn PreviewButton;
        private System.Windows.Forms.Button disableAllButton;
        private System.Windows.Forms.Button enableAllButton;
        private System.Windows.Forms.GroupBox soundscriptSettingsGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox modifyChannelComboBox;
        private System.Windows.Forms.CheckBox modifyChannelCheckBox;
        private System.Windows.Forms.CheckBox modifySoundlevelCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox modifyPitchCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox modifyVolumeCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox modifyPitchTextBox;
        private System.Windows.Forms.TextBox modifyVolumeTextBox;
        private System.Windows.Forms.TextBox modifySoundlevelTextBox;
        private System.Windows.Forms.GroupBox regexFileSettingsGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
    }
}