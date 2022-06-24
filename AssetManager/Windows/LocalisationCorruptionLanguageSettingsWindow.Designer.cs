namespace AssetManager
{
    partial class LocalisationCorruptionLanguageSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalisationCorruptionLanguageSettings));
            this.localisationLanguageList = new System.Windows.Forms.CheckedListBox();
            this.detectedLanguagesGroupBox = new System.Windows.Forms.GroupBox();
            this.generalSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.ignoreRepeatingTokensCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.globalWeightsNumericEntry = new System.Windows.Forms.NumericUpDown();
            this.globalRegexTextBox = new System.Windows.Forms.TextBox();
            this.globalRegexEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.languageOverrideGroupBox = new System.Windows.Forms.GroupBox();
            this.overrideWeightsNumericEntry = new System.Windows.Forms.NumericUpDown();
            this.overrideRegexTextBox = new System.Windows.Forms.TextBox();
            this.overrideWeightsCheckBox = new System.Windows.Forms.CheckBox();
            this.overrideRegexCheckBox = new System.Windows.Forms.CheckBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ignoreNoMatchingTokensCheckBox = new System.Windows.Forms.CheckBox();
            this.detectedLanguagesGroupBox.SuspendLayout();
            this.generalSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.globalWeightsNumericEntry)).BeginInit();
            this.languageOverrideGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overrideWeightsNumericEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // localisationLanguageList
            // 
            this.localisationLanguageList.FormattingEnabled = true;
            this.localisationLanguageList.Location = new System.Drawing.Point(6, 19);
            this.localisationLanguageList.Name = "localisationLanguageList";
            this.localisationLanguageList.Size = new System.Drawing.Size(242, 379);
            this.localisationLanguageList.TabIndex = 0;
            this.localisationLanguageList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.localisationLanguageList_ItemCheck);
            this.localisationLanguageList.SelectedIndexChanged += new System.EventHandler(this.localisationLanguageList_SelectedIndexChanged);
            // 
            // detectedLanguagesGroupBox
            // 
            this.detectedLanguagesGroupBox.Controls.Add(this.localisationLanguageList);
            this.detectedLanguagesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.detectedLanguagesGroupBox.Name = "detectedLanguagesGroupBox";
            this.detectedLanguagesGroupBox.Size = new System.Drawing.Size(254, 412);
            this.detectedLanguagesGroupBox.TabIndex = 1;
            this.detectedLanguagesGroupBox.TabStop = false;
            this.detectedLanguagesGroupBox.Text = "Detected Languages";
            // 
            // generalSettingsGroupBox
            // 
            this.generalSettingsGroupBox.Controls.Add(this.ignoreNoMatchingTokensCheckBox);
            this.generalSettingsGroupBox.Controls.Add(this.ignoreRepeatingTokensCheckBox);
            this.generalSettingsGroupBox.Controls.Add(this.label1);
            this.generalSettingsGroupBox.Controls.Add(this.globalWeightsNumericEntry);
            this.generalSettingsGroupBox.Controls.Add(this.globalRegexTextBox);
            this.generalSettingsGroupBox.Controls.Add(this.globalRegexEnabledCheckBox);
            this.generalSettingsGroupBox.Location = new System.Drawing.Point(272, 12);
            this.generalSettingsGroupBox.Name = "generalSettingsGroupBox";
            this.generalSettingsGroupBox.Size = new System.Drawing.Size(285, 116);
            this.generalSettingsGroupBox.TabIndex = 2;
            this.generalSettingsGroupBox.TabStop = false;
            this.generalSettingsGroupBox.Text = "General Settings";
            // 
            // ignoreRepeatingTokensCheckBox
            // 
            this.ignoreRepeatingTokensCheckBox.AutoSize = true;
            this.ignoreRepeatingTokensCheckBox.Location = new System.Drawing.Point(6, 90);
            this.ignoreRepeatingTokensCheckBox.Name = "ignoreRepeatingTokensCheckBox";
            this.ignoreRepeatingTokensCheckBox.Size = new System.Drawing.Size(231, 17);
            this.ignoreRepeatingTokensCheckBox.TabIndex = 6;
            this.ignoreRepeatingTokensCheckBox.Text = "Use Another Language if Entry is Repeated";
            this.toolTip1.SetToolTip(this.ignoreRepeatingTokensCheckBox, resources.GetString("ignoreRepeatingTokensCheckBox.ToolTip"));
            this.ignoreRepeatingTokensCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Global Weights";
            // 
            // globalWeightsNumericEntry
            // 
            this.globalWeightsNumericEntry.DecimalPlaces = 3;
            this.globalWeightsNumericEntry.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.globalWeightsNumericEntry.Location = new System.Drawing.Point(134, 41);
            this.globalWeightsNumericEntry.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.globalWeightsNumericEntry.Name = "globalWeightsNumericEntry";
            this.globalWeightsNumericEntry.Size = new System.Drawing.Size(68, 20);
            this.globalWeightsNumericEntry.TabIndex = 3;
            this.toolTip1.SetToolTip(this.globalWeightsNumericEntry, "Weights decide the likelihood of languages being selected at random. Using this a" +
        "longside Override Weights will change the chances of getting specific languages." +
        "");
            this.globalWeightsNumericEntry.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.globalWeightsNumericEntry.ValueChanged += new System.EventHandler(this.globalWeightsNumericEntry_ValueChanged);
            // 
            // globalRegexTextBox
            // 
            this.globalRegexTextBox.Location = new System.Drawing.Point(134, 17);
            this.globalRegexTextBox.Name = "globalRegexTextBox";
            this.globalRegexTextBox.Size = new System.Drawing.Size(145, 20);
            this.globalRegexTextBox.TabIndex = 2;
            this.globalRegexTextBox.TextChanged += new System.EventHandler(this.globalRegexTextBox_TextChanged);
            // 
            // globalRegexEnabledCheckBox
            // 
            this.globalRegexEnabledCheckBox.AutoSize = true;
            this.globalRegexEnabledCheckBox.Location = new System.Drawing.Point(6, 19);
            this.globalRegexEnabledCheckBox.Name = "globalRegexEnabledCheckBox";
            this.globalRegexEnabledCheckBox.Size = new System.Drawing.Size(121, 17);
            this.globalRegexEnabledCheckBox.TabIndex = 0;
            this.globalRegexEnabledCheckBox.Text = "Swap Target Regex";
            this.toolTip1.SetToolTip(this.globalRegexEnabledCheckBox, "If enabled, a regex search will be performed on the swap target.\r\nOther regex set" +
        "tings for this corruption can be found under Filter Settings in the main window." +
        "");
            this.globalRegexEnabledCheckBox.UseVisualStyleBackColor = true;
            this.globalRegexEnabledCheckBox.CheckedChanged += new System.EventHandler(this.globalRegexEnabledCheckBox_CheckedChanged);
            // 
            // languageOverrideGroupBox
            // 
            this.languageOverrideGroupBox.Controls.Add(this.overrideWeightsNumericEntry);
            this.languageOverrideGroupBox.Controls.Add(this.overrideRegexTextBox);
            this.languageOverrideGroupBox.Controls.Add(this.overrideWeightsCheckBox);
            this.languageOverrideGroupBox.Controls.Add(this.overrideRegexCheckBox);
            this.languageOverrideGroupBox.Location = new System.Drawing.Point(272, 134);
            this.languageOverrideGroupBox.Name = "languageOverrideGroupBox";
            this.languageOverrideGroupBox.Size = new System.Drawing.Size(285, 72);
            this.languageOverrideGroupBox.TabIndex = 4;
            this.languageOverrideGroupBox.TabStop = false;
            this.languageOverrideGroupBox.Text = "Language Override Settings";
            this.languageOverrideGroupBox.Visible = false;
            // 
            // overrideWeightsNumericEntry
            // 
            this.overrideWeightsNumericEntry.DecimalPlaces = 3;
            this.overrideWeightsNumericEntry.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.overrideWeightsNumericEntry.Location = new System.Drawing.Point(134, 42);
            this.overrideWeightsNumericEntry.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.overrideWeightsNumericEntry.Name = "overrideWeightsNumericEntry";
            this.overrideWeightsNumericEntry.Size = new System.Drawing.Size(68, 20);
            this.overrideWeightsNumericEntry.TabIndex = 3;
            this.overrideWeightsNumericEntry.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.overrideWeightsNumericEntry.ValueChanged += new System.EventHandler(this.overrideWeightsNumericEntry_ValueChanged);
            // 
            // overrideRegexTextBox
            // 
            this.overrideRegexTextBox.Location = new System.Drawing.Point(126, 18);
            this.overrideRegexTextBox.Name = "overrideRegexTextBox";
            this.overrideRegexTextBox.Size = new System.Drawing.Size(153, 20);
            this.overrideRegexTextBox.TabIndex = 2;
            this.overrideRegexTextBox.TextChanged += new System.EventHandler(this.overrideRegexTextBox_TextChanged);
            // 
            // overrideWeightsCheckBox
            // 
            this.overrideWeightsCheckBox.AutoSize = true;
            this.overrideWeightsCheckBox.Location = new System.Drawing.Point(6, 43);
            this.overrideWeightsCheckBox.Name = "overrideWeightsCheckBox";
            this.overrideWeightsCheckBox.Size = new System.Drawing.Size(103, 17);
            this.overrideWeightsCheckBox.TabIndex = 1;
            this.overrideWeightsCheckBox.Text = "Override Weight";
            this.toolTip1.SetToolTip(this.overrideWeightsCheckBox, "If enabled, a weight can be specified that only applies to the current selected l" +
        "anguage.\r\n");
            this.overrideWeightsCheckBox.UseVisualStyleBackColor = true;
            this.overrideWeightsCheckBox.CheckedChanged += new System.EventHandler(this.overrideWeightsCheckBox_CheckedChanged);
            // 
            // overrideRegexCheckBox
            // 
            this.overrideRegexCheckBox.AutoSize = true;
            this.overrideRegexCheckBox.Location = new System.Drawing.Point(6, 20);
            this.overrideRegexCheckBox.Name = "overrideRegexCheckBox";
            this.overrideRegexCheckBox.Size = new System.Drawing.Size(100, 17);
            this.overrideRegexCheckBox.TabIndex = 0;
            this.overrideRegexCheckBox.Text = "Override Regex";
            this.toolTip1.SetToolTip(this.overrideRegexCheckBox, "If enabled, a regex pattern can be specified that only applies to the current sel" +
        "ected language.");
            this.overrideRegexCheckBox.UseVisualStyleBackColor = true;
            this.overrideRegexCheckBox.CheckedChanged += new System.EventHandler(this.overrideRegexCheckBox_CheckedChanged);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(294, 430);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(264, 23);
            this.confirmButton.TabIndex = 12;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 430);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(276, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ignoreNoMatchingTokensCheckBox
            // 
            this.ignoreNoMatchingTokensCheckBox.AutoSize = true;
            this.ignoreNoMatchingTokensCheckBox.Location = new System.Drawing.Point(6, 67);
            this.ignoreNoMatchingTokensCheckBox.Name = "ignoreNoMatchingTokensCheckBox";
            this.ignoreNoMatchingTokensCheckBox.Size = new System.Drawing.Size(236, 17);
            this.ignoreNoMatchingTokensCheckBox.TabIndex = 7;
            this.ignoreNoMatchingTokensCheckBox.Text = "Use Another Language if no Token is Found\r\n";
            this.toolTip1.SetToolTip(this.ignoreNoMatchingTokensCheckBox, "If checked, other selected languages will be checked if the first random choice f" +
        "or a token does not have a corresponding token in its language.");
            this.ignoreNoMatchingTokensCheckBox.UseVisualStyleBackColor = true;
            // 
            // LocalisationCorruptionLanguageSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 462);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.languageOverrideGroupBox);
            this.Controls.Add(this.generalSettingsGroupBox);
            this.Controls.Add(this.detectedLanguagesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalisationCorruptionLanguageSettings";
            this.ShowInTaskbar = false;
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.Load += new System.EventHandler(this.LocalisationCorruptionLanguageSettings_Load);
            this.detectedLanguagesGroupBox.ResumeLayout(false);
            this.generalSettingsGroupBox.ResumeLayout(false);
            this.generalSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.globalWeightsNumericEntry)).EndInit();
            this.languageOverrideGroupBox.ResumeLayout(false);
            this.languageOverrideGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overrideWeightsNumericEntry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox localisationLanguageList;
        private System.Windows.Forms.GroupBox detectedLanguagesGroupBox;
        private System.Windows.Forms.GroupBox generalSettingsGroupBox;
        private System.Windows.Forms.NumericUpDown globalWeightsNumericEntry;
        private System.Windows.Forms.TextBox globalRegexTextBox;
        private System.Windows.Forms.CheckBox globalRegexEnabledCheckBox;
        private System.Windows.Forms.GroupBox languageOverrideGroupBox;
        private System.Windows.Forms.NumericUpDown overrideWeightsNumericEntry;
        private System.Windows.Forms.TextBox overrideRegexTextBox;
        private System.Windows.Forms.CheckBox overrideWeightsCheckBox;
        private System.Windows.Forms.CheckBox overrideRegexCheckBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ignoreRepeatingTokensCheckBox;
        private System.Windows.Forms.CheckBox ignoreNoMatchingTokensCheckBox;
    }
}