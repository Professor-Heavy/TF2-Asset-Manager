namespace AssetManager
{
    partial class LocalisationFilterOptionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalisationFilterOptionsWindow));
            this.keyFiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.shaderFiltersPanel = new System.Windows.Forms.Panel();
            this.keyFiltersExcludeRadioButton = new System.Windows.Forms.RadioButton();
            this.keyFiltersIncludeRadioButton = new System.Windows.Forms.RadioButton();
            this.keyFiltersTextBox = new System.Windows.Forms.TextBox();
            this.keyFiltersLabel = new System.Windows.Forms.Label();
            this.regularExpressionFiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.regexForMatchesAndSwapsCheckBox = new System.Windows.Forms.CheckBox();
            this.regexFilteringExclusionCheckBox = new System.Windows.Forms.CheckBox();
            this.regexFilteringCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regexFilteringTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.safeModeNewlinesCheckBox = new System.Windows.Forms.CheckBox();
            this.safeModeSkipUnsafeCheckBox = new System.Windows.Forms.CheckBox();
            this.safeModeFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.keyFiltersGroupBox.SuspendLayout();
            this.shaderFiltersPanel.SuspendLayout();
            this.regularExpressionFiltersGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyFiltersGroupBox
            // 
            this.keyFiltersGroupBox.Controls.Add(this.shaderFiltersPanel);
            this.keyFiltersGroupBox.Controls.Add(this.keyFiltersTextBox);
            this.keyFiltersGroupBox.Controls.Add(this.keyFiltersLabel);
            this.keyFiltersGroupBox.Location = new System.Drawing.Point(12, 12);
            this.keyFiltersGroupBox.Name = "keyFiltersGroupBox";
            this.keyFiltersGroupBox.Size = new System.Drawing.Size(275, 426);
            this.keyFiltersGroupBox.TabIndex = 0;
            this.keyFiltersGroupBox.TabStop = false;
            this.keyFiltersGroupBox.Text = "Token Key Filter";
            // 
            // shaderFiltersPanel
            // 
            this.shaderFiltersPanel.Controls.Add(this.keyFiltersExcludeRadioButton);
            this.shaderFiltersPanel.Controls.Add(this.keyFiltersIncludeRadioButton);
            this.shaderFiltersPanel.Location = new System.Drawing.Point(10, 397);
            this.shaderFiltersPanel.Name = "shaderFiltersPanel";
            this.shaderFiltersPanel.Size = new System.Drawing.Size(253, 23);
            this.shaderFiltersPanel.TabIndex = 7;
            // 
            // keyFiltersExcludeRadioButton
            // 
            this.keyFiltersExcludeRadioButton.AutoSize = true;
            this.keyFiltersExcludeRadioButton.Checked = true;
            this.keyFiltersExcludeRadioButton.Location = new System.Drawing.Point(0, 6);
            this.keyFiltersExcludeRadioButton.Name = "keyFiltersExcludeRadioButton";
            this.keyFiltersExcludeRadioButton.Size = new System.Drawing.Size(89, 17);
            this.keyFiltersExcludeRadioButton.TabIndex = 1;
            this.keyFiltersExcludeRadioButton.TabStop = true;
            this.keyFiltersExcludeRadioButton.Text = "Exclude Keys";
            this.keyFiltersExcludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // keyFiltersIncludeRadioButton
            // 
            this.keyFiltersIncludeRadioButton.AutoSize = true;
            this.keyFiltersIncludeRadioButton.Location = new System.Drawing.Point(156, 6);
            this.keyFiltersIncludeRadioButton.Name = "keyFiltersIncludeRadioButton";
            this.keyFiltersIncludeRadioButton.Size = new System.Drawing.Size(94, 17);
            this.keyFiltersIncludeRadioButton.TabIndex = 2;
            this.keyFiltersIncludeRadioButton.Text = "Only Use Keys";
            this.keyFiltersIncludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // keyFiltersTextBox
            // 
            this.keyFiltersTextBox.Location = new System.Drawing.Point(13, 54);
            this.keyFiltersTextBox.Multiline = true;
            this.keyFiltersTextBox.Name = "keyFiltersTextBox";
            this.keyFiltersTextBox.Size = new System.Drawing.Size(253, 343);
            this.keyFiltersTextBox.TabIndex = 5;
            // 
            // keyFiltersLabel
            // 
            this.keyFiltersLabel.Location = new System.Drawing.Point(7, 16);
            this.keyFiltersLabel.Name = "keyFiltersLabel";
            this.keyFiltersLabel.Size = new System.Drawing.Size(256, 35);
            this.keyFiltersLabel.TabIndex = 6;
            this.keyFiltersLabel.Text = "Type in localisation token keys that you would like to exclude from corruption, s" +
    "eparated by a new line.";
            this.keyFiltersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // regularExpressionFiltersGroupBox
            // 
            this.regularExpressionFiltersGroupBox.Controls.Add(this.regexForMatchesAndSwapsCheckBox);
            this.regularExpressionFiltersGroupBox.Controls.Add(this.regexFilteringExclusionCheckBox);
            this.regularExpressionFiltersGroupBox.Controls.Add(this.regexFilteringCheckBox);
            this.regularExpressionFiltersGroupBox.Controls.Add(this.label3);
            this.regularExpressionFiltersGroupBox.Controls.Add(this.regexFilteringTextBox);
            this.regularExpressionFiltersGroupBox.Location = new System.Drawing.Point(293, 12);
            this.regularExpressionFiltersGroupBox.Name = "regularExpressionFiltersGroupBox";
            this.regularExpressionFiltersGroupBox.Size = new System.Drawing.Size(495, 90);
            this.regularExpressionFiltersGroupBox.TabIndex = 1;
            this.regularExpressionFiltersGroupBox.TabStop = false;
            this.regularExpressionFiltersGroupBox.Text = "Regular Expression Filter (RegEx)";
            // 
            // regexForMatchesAndSwapsCheckBox
            // 
            this.regexForMatchesAndSwapsCheckBox.AutoSize = true;
            this.regexForMatchesAndSwapsCheckBox.Location = new System.Drawing.Point(6, 65);
            this.regexForMatchesAndSwapsCheckBox.Name = "regexForMatchesAndSwapsCheckBox";
            this.regexForMatchesAndSwapsCheckBox.Size = new System.Drawing.Size(223, 17);
            this.regexForMatchesAndSwapsCheckBox.TabIndex = 35;
            this.regexForMatchesAndSwapsCheckBox.Text = "Use Regular Expression for Swap Targets";
            this.toolTip1.SetToolTip(this.regexForMatchesAndSwapsCheckBox, "If enabled, the RegEx pattern will also apply for any localisation entries select" +
        "ed to be swapped with the initial matched entry.");
            this.regexForMatchesAndSwapsCheckBox.UseVisualStyleBackColor = true;
            // 
            // regexFilteringExclusionCheckBox
            // 
            this.regexFilteringExclusionCheckBox.AutoSize = true;
            this.regexFilteringExclusionCheckBox.Location = new System.Drawing.Point(6, 42);
            this.regexFilteringExclusionCheckBox.Name = "regexFilteringExclusionCheckBox";
            this.regexFilteringExclusionCheckBox.Size = new System.Drawing.Size(182, 17);
            this.regexFilteringExclusionCheckBox.TabIndex = 34;
            this.regexFilteringExclusionCheckBox.Text = "Exclude Matches from Corruption";
            this.regexFilteringExclusionCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.regexFilteringExclusionCheckBox, "If selected, Regular Expression matches will be treated inversely, with matches b" +
        "eing ignored from the corruption.");
            this.regexFilteringExclusionCheckBox.UseVisualStyleBackColor = true;
            // 
            // regexFilteringCheckBox
            // 
            this.regexFilteringCheckBox.AutoSize = true;
            this.regexFilteringCheckBox.Location = new System.Drawing.Point(6, 19);
            this.regexFilteringCheckBox.Name = "regexFilteringCheckBox";
            this.regexFilteringCheckBox.Size = new System.Drawing.Size(139, 17);
            this.regexFilteringCheckBox.TabIndex = 33;
            this.regexFilteringCheckBox.Text = "Use Regular Expression";
            this.regexFilteringCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.regexFilteringCheckBox, "Toggles Regular Expression features for this corruption.");
            this.regexFilteringCheckBox.UseVisualStyleBackColor = true;
            this.regexFilteringCheckBox.CheckedChanged += new System.EventHandler(this.regexFilteringCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Regular Expression Pattern";
            // 
            // regexFilteringTextBox
            // 
            this.regexFilteringTextBox.Location = new System.Drawing.Point(204, 31);
            this.regexFilteringTextBox.Name = "regexFilteringTextBox";
            this.regexFilteringTextBox.Size = new System.Drawing.Size(285, 20);
            this.regexFilteringTextBox.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.safeModeNewlinesCheckBox);
            this.groupBox1.Controls.Add(this.safeModeSkipUnsafeCheckBox);
            this.groupBox1.Controls.Add(this.safeModeFilterCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(293, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 90);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Miscellaneous Filters";
            // 
            // safeModeNewlinesCheckBox
            // 
            this.safeModeNewlinesCheckBox.AutoSize = true;
            this.safeModeNewlinesCheckBox.Location = new System.Drawing.Point(6, 66);
            this.safeModeNewlinesCheckBox.Name = "safeModeNewlinesCheckBox";
            this.safeModeNewlinesCheckBox.Size = new System.Drawing.Size(172, 17);
            this.safeModeNewlinesCheckBox.TabIndex = 35;
            this.safeModeNewlinesCheckBox.Text = "Filter \\n newlines in Safe Mode";
            this.toolTip1.SetToolTip(this.safeModeNewlinesCheckBox, "If enabled, any character with \\n will be seen as a special character, and will b" +
        "e filtered out by Safe Mode.");
            this.safeModeNewlinesCheckBox.UseVisualStyleBackColor = true;
            // 
            // safeModeSkipUnsafeCheckBox
            // 
            this.safeModeSkipUnsafeCheckBox.AutoSize = true;
            this.safeModeSkipUnsafeCheckBox.Location = new System.Drawing.Point(6, 42);
            this.safeModeSkipUnsafeCheckBox.Name = "safeModeSkipUnsafeCheckBox";
            this.safeModeSkipUnsafeCheckBox.Size = new System.Drawing.Size(194, 17);
            this.safeModeSkipUnsafeCheckBox.TabIndex = 34;
            this.safeModeSkipUnsafeCheckBox.Text = "Ignore Unsafe Entries in Safe Mode";
            this.safeModeSkipUnsafeCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.safeModeSkipUnsafeCheckBox, resources.GetString("safeModeSkipUnsafeCheckBox.ToolTip"));
            this.safeModeSkipUnsafeCheckBox.UseVisualStyleBackColor = true;
            // 
            // safeModeFilterCheckBox
            // 
            this.safeModeFilterCheckBox.AutoSize = true;
            this.safeModeFilterCheckBox.Location = new System.Drawing.Point(6, 19);
            this.safeModeFilterCheckBox.Name = "safeModeFilterCheckBox";
            this.safeModeFilterCheckBox.Size = new System.Drawing.Size(78, 17);
            this.safeModeFilterCheckBox.TabIndex = 33;
            this.safeModeFilterCheckBox.Text = "Safe Mode";
            this.safeModeFilterCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.safeModeFilterCheckBox, "If enabled, this filter will ignore any special characters when altering localisa" +
        "tion tokens.");
            this.safeModeFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(409, 444);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(379, 23);
            this.confirmButton.TabIndex = 37;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 444);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(391, 23);
            this.cancelButton.TabIndex = 36;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // LocalisationFilterOptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.regularExpressionFiltersGroupBox);
            this.Controls.Add(this.keyFiltersGroupBox);
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalisationFilterOptionsWindow";
            this.ShowInTaskbar = false;
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.Load += new System.EventHandler(this.LocalisationFilterOptionsWindow_Load);
            this.keyFiltersGroupBox.ResumeLayout(false);
            this.keyFiltersGroupBox.PerformLayout();
            this.shaderFiltersPanel.ResumeLayout(false);
            this.shaderFiltersPanel.PerformLayout();
            this.regularExpressionFiltersGroupBox.ResumeLayout(false);
            this.regularExpressionFiltersGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox keyFiltersGroupBox;
        private System.Windows.Forms.Panel shaderFiltersPanel;
        private System.Windows.Forms.RadioButton keyFiltersExcludeRadioButton;
        private System.Windows.Forms.RadioButton keyFiltersIncludeRadioButton;
        private System.Windows.Forms.TextBox keyFiltersTextBox;
        private System.Windows.Forms.Label keyFiltersLabel;
        private System.Windows.Forms.GroupBox regularExpressionFiltersGroupBox;
        private System.Windows.Forms.TextBox regexFilteringTextBox;
        private System.Windows.Forms.CheckBox regexFilteringCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox regexFilteringExclusionCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox safeModeSkipUnsafeCheckBox;
        private System.Windows.Forms.CheckBox safeModeFilterCheckBox;
        private System.Windows.Forms.CheckBox safeModeNewlinesCheckBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox regexForMatchesAndSwapsCheckBox;
    }
}