namespace AssetManager
{
    partial class ManageLocalisationParametersWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageLocalisationParametersWindow));
            this.localisationParameterList = new System.Windows.Forms.ListBox();
            this.RemoveParameterButton = new System.Windows.Forms.Button();
            this.AddParameterButton = new System.Windows.Forms.Button();
            this.statusBarText = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.localisationRegexParameter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.localisationParameterName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.localisationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.regexCheckButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.regexSafeModeCheckBox = new System.Windows.Forms.CheckBox();
            this.regexFilteringCheckBox = new System.Windows.Forms.CheckBox();
            this.regexCheckFilesButton = new System.Windows.Forms.Button();
            this.regexSettingsGroup = new System.Windows.Forms.GroupBox();
            this.regexPreviewTextBox = new System.Windows.Forms.RichTextBox();
            this.replaceStringEntryTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusBar.SuspendLayout();
            this.regexSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // localisationParameterList
            // 
            this.localisationParameterList.FormattingEnabled = true;
            this.localisationParameterList.Location = new System.Drawing.Point(12, 12);
            this.localisationParameterList.Name = "localisationParameterList";
            this.localisationParameterList.Size = new System.Drawing.Size(148, 433);
            this.localisationParameterList.TabIndex = 18;
            this.localisationParameterList.SelectedIndexChanged += new System.EventHandler(this.LocalisationParameterList_SelectedIndexChanged);
            // 
            // RemoveParameterButton
            // 
            this.RemoveParameterButton.Location = new System.Drawing.Point(93, 449);
            this.RemoveParameterButton.Name = "RemoveParameterButton";
            this.RemoveParameterButton.Size = new System.Drawing.Size(67, 23);
            this.RemoveParameterButton.TabIndex = 20;
            this.RemoveParameterButton.Text = "Remove";
            this.RemoveParameterButton.UseVisualStyleBackColor = true;
            this.RemoveParameterButton.Click += new System.EventHandler(this.RemoveParameterButton_Click);
            // 
            // AddParameterButton
            // 
            this.AddParameterButton.Location = new System.Drawing.Point(12, 449);
            this.AddParameterButton.Name = "AddParameterButton";
            this.AddParameterButton.Size = new System.Drawing.Size(64, 23);
            this.AddParameterButton.TabIndex = 19;
            this.AddParameterButton.Text = "Add";
            this.AddParameterButton.UseVisualStyleBackColor = true;
            this.AddParameterButton.Click += new System.EventHandler(this.AddParameterButton_Click);
            // 
            // statusBarText
            // 
            this.statusBarText.ActiveLinkColor = System.Drawing.Color.Black;
            this.statusBarText.ForeColor = System.Drawing.Color.Black;
            this.statusBarText.Name = "statusBarText";
            this.statusBarText.Size = new System.Drawing.Size(0, 17);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarText});
            this.statusBar.Location = new System.Drawing.Point(0, 481);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(593, 22);
            this.statusBar.TabIndex = 21;
            this.statusBar.Text = "statusStrip1";
            // 
            // localisationRegexParameter
            // 
            this.localisationRegexParameter.Location = new System.Drawing.Point(10, 57);
            this.localisationRegexParameter.Name = "localisationRegexParameter";
            this.localisationRegexParameter.Size = new System.Drawing.Size(281, 20);
            this.localisationRegexParameter.TabIndex = 24;
            this.localisationRegexParameter.TextChanged += new System.EventHandler(this.LocalisationRegexParameter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Parameter Name";
            // 
            // localisationParameterName
            // 
            this.localisationParameterName.Location = new System.Drawing.Point(176, 28);
            this.localisationParameterName.Name = "localisationParameterName";
            this.localisationParameterName.Size = new System.Drawing.Size(162, 20);
            this.localisationParameterName.TabIndex = 23;
            this.localisationParameterName.TextChanged += new System.EventHandler(this.LocalisationParameterName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Regular Expression Pattern";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Parameter Type";
            // 
            // localisationTypeComboBox
            // 
            this.localisationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localisationTypeComboBox.FormattingEnabled = true;
            this.localisationTypeComboBox.Location = new System.Drawing.Point(398, 27);
            this.localisationTypeComboBox.Name = "localisationTypeComboBox";
            this.localisationTypeComboBox.Size = new System.Drawing.Size(183, 21);
            this.localisationTypeComboBox.TabIndex = 25;
            this.localisationTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.LocalisationTypeComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Preview";
            // 
            // regexCheckButton
            // 
            this.regexCheckButton.Location = new System.Drawing.Point(297, 42);
            this.regexCheckButton.Name = "regexCheckButton";
            this.regexCheckButton.Size = new System.Drawing.Size(102, 20);
            this.regexCheckButton.TabIndex = 30;
            this.regexCheckButton.Text = "Check Preview";
            this.toolTip1.SetToolTip(this.regexCheckButton, "Check the preview for any matches for this pattern.\r\nIf no match is found, the lo" +
        "calisation file can be checked instead.");
            this.regexCheckButton.UseVisualStyleBackColor = true;
            this.regexCheckButton.Click += new System.EventHandler(this.RegexCheckButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 100;
            // 
            // regexSafeModeCheckBox
            // 
            this.regexSafeModeCheckBox.AutoSize = true;
            this.regexSafeModeCheckBox.Location = new System.Drawing.Point(10, 19);
            this.regexSafeModeCheckBox.Name = "regexSafeModeCheckBox";
            this.regexSafeModeCheckBox.Size = new System.Drawing.Size(78, 17);
            this.regexSafeModeCheckBox.TabIndex = 31;
            this.regexSafeModeCheckBox.Text = "Safe Mode";
            this.toolTip1.SetToolTip(this.regexSafeModeCheckBox, resources.GetString("regexSafeModeCheckBox.ToolTip"));
            this.regexSafeModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // regexFilteringCheckBox
            // 
            this.regexFilteringCheckBox.AutoSize = true;
            this.regexFilteringCheckBox.Location = new System.Drawing.Point(176, 101);
            this.regexFilteringCheckBox.Name = "regexFilteringCheckBox";
            this.regexFilteringCheckBox.Size = new System.Drawing.Size(96, 17);
            this.regexFilteringCheckBox.TabIndex = 32;
            this.regexFilteringCheckBox.Text = "Regex Filtering";
            this.regexFilteringCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.regexFilteringCheckBox, "Only affects strings that match the specified Regex Pattern.\r\nThis is kept on whe" +
        "n using Replace Characters.");
            this.regexFilteringCheckBox.UseVisualStyleBackColor = true;
            this.regexFilteringCheckBox.CheckedChanged += new System.EventHandler(this.RegexFilteringCheckBox_CheckedChanged);
            // 
            // regexCheckFilesButton
            // 
            this.regexCheckFilesButton.Location = new System.Drawing.Point(297, 68);
            this.regexCheckFilesButton.Name = "regexCheckFilesButton";
            this.regexCheckFilesButton.Size = new System.Drawing.Size(102, 20);
            this.regexCheckFilesButton.TabIndex = 33;
            this.regexCheckFilesButton.Text = "Check Loc. File";
            this.toolTip1.SetToolTip(this.regexCheckFilesButton, "Check the preview for any matches for this pattern.\r\nIf no match is found, the lo" +
        "calisation file can be checked instead.");
            this.regexCheckFilesButton.UseVisualStyleBackColor = true;
            this.regexCheckFilesButton.Click += new System.EventHandler(this.regexCheckFilesButton_Click);
            // 
            // regexSettingsGroup
            // 
            this.regexSettingsGroup.Controls.Add(this.regexCheckFilesButton);
            this.regexSettingsGroup.Controls.Add(this.regexPreviewTextBox);
            this.regexSettingsGroup.Controls.Add(this.regexSafeModeCheckBox);
            this.regexSettingsGroup.Controls.Add(this.label3);
            this.regexSettingsGroup.Controls.Add(this.regexCheckButton);
            this.regexSettingsGroup.Controls.Add(this.localisationRegexParameter);
            this.regexSettingsGroup.Controls.Add(this.label4);
            this.regexSettingsGroup.Location = new System.Drawing.Point(176, 124);
            this.regexSettingsGroup.Name = "regexSettingsGroup";
            this.regexSettingsGroup.Size = new System.Drawing.Size(405, 354);
            this.regexSettingsGroup.TabIndex = 33;
            this.regexSettingsGroup.TabStop = false;
            this.regexSettingsGroup.Text = "Regular Expression (RegEx) Settings";
            // 
            // regexPreviewTextBox
            // 
            this.regexPreviewTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regexPreviewTextBox.Location = new System.Drawing.Point(10, 102);
            this.regexPreviewTextBox.Name = "regexPreviewTextBox";
            this.regexPreviewTextBox.ReadOnly = true;
            this.regexPreviewTextBox.Size = new System.Drawing.Size(389, 246);
            this.regexPreviewTextBox.TabIndex = 32;
            this.regexPreviewTextBox.Text = resources.GetString("regexPreviewTextBox.Text");
            // 
            // replaceStringEntryTextBox
            // 
            this.replaceStringEntryTextBox.Location = new System.Drawing.Point(176, 73);
            this.replaceStringEntryTextBox.Name = "replaceStringEntryTextBox";
            this.replaceStringEntryTextBox.Size = new System.Drawing.Size(405, 20);
            this.replaceStringEntryTextBox.TabIndex = 33;
            this.replaceStringEntryTextBox.TextChanged += new System.EventHandler(this.ReplaceStringEntryTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Replace With";
            // 
            // ManageLocalisationParametersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 503);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.replaceStringEntryTextBox);
            this.Controls.Add(this.localisationParameterList);
            this.Controls.Add(this.localisationTypeComboBox);
            this.Controls.Add(this.regexSettingsGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regexFilteringCheckBox);
            this.Controls.Add(this.localisationParameterName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.RemoveParameterButton);
            this.Controls.Add(this.AddParameterButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageLocalisationParametersWindow";
            this.ShowInTaskbar = false;
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageLocalisationParametersWindow_FormClosing);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.regexSettingsGroup.ResumeLayout(false);
            this.regexSettingsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox localisationParameterList;
        private System.Windows.Forms.Button RemoveParameterButton;
        private System.Windows.Forms.Button AddParameterButton;
        private System.Windows.Forms.ToolStripStatusLabel statusBarText;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.TextBox localisationRegexParameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox localisationParameterName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox localisationTypeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button regexCheckButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox regexSafeModeCheckBox;
        private System.Windows.Forms.CheckBox regexFilteringCheckBox;
        private System.Windows.Forms.GroupBox regexSettingsGroup;
        private System.Windows.Forms.RichTextBox regexPreviewTextBox;
        private System.Windows.Forms.TextBox replaceStringEntryTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button regexCheckFilesButton;
    }
}