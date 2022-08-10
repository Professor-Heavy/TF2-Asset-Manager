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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.soundFileListingDataGridView = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviewButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.useRandomChoiceCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.regexSettingsGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundFileListingDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // soundParameterList
            // 
            this.soundParameterList.FormattingEnabled = true;
            this.soundParameterList.Location = new System.Drawing.Point(12, 12);
            this.soundParameterList.Name = "soundParameterList";
            this.soundParameterList.Size = new System.Drawing.Size(148, 394);
            this.soundParameterList.TabIndex = 18;
            this.soundParameterList.SelectedIndexChanged += new System.EventHandler(this.soundParameterList_SelectedIndexChanged);
            // 
            // RemoveParameterButton
            // 
            this.RemoveParameterButton.Location = new System.Drawing.Point(93, 412);
            this.RemoveParameterButton.Name = "RemoveParameterButton";
            this.RemoveParameterButton.Size = new System.Drawing.Size(67, 23);
            this.RemoveParameterButton.TabIndex = 20;
            this.RemoveParameterButton.Text = "Remove";
            this.RemoveParameterButton.UseVisualStyleBackColor = true;
            this.RemoveParameterButton.Click += new System.EventHandler(this.RemoveParameterButton_Click);
            // 
            // AddParameterButton
            // 
            this.AddParameterButton.Location = new System.Drawing.Point(12, 412);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.soundFileListingDataGridView);
            this.groupBox1.Controls.Add(this.useRandomChoiceCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(180, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 294);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replace Settings";
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.soundFileListingDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
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
            // ManageSoundParametersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 451);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.regexSettingsGroup);
            this.Controls.Add(this.soundTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.soundParameterName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.soundParameterList);
            this.Controls.Add(this.RemoveParameterButton);
            this.Controls.Add(this.AddParameterButton);
            this.Name = "ManageSoundParametersWindow";
            this.Text = "ManageSoundParametersWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageSoundParametersWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageSoundParametersWindow_Load);
            this.regexSettingsGroup.ResumeLayout(false);
            this.regexSettingsGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundFileListingDataGridView)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox useRandomChoiceCheckBox;
        private System.Windows.Forms.DataGridView soundFileListingDataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewButtonColumn PreviewButton;
    }
}