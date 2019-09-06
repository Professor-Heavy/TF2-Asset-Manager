namespace AssetManager
{
    partial class FilterOptionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterOptionsWindow));
            this.shaderFiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.shaderFiltersTextBox = new System.Windows.Forms.TextBox();
            this.shaderFiltersExcludeRadioButton = new System.Windows.Forms.RadioButton();
            this.shaderFiltersIncludeRadioButton = new System.Windows.Forms.RadioButton();
            this.shaderFiltersLabel = new System.Windows.Forms.Label();
            this.parameterFiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.parameterFiltersLabel = new System.Windows.Forms.Label();
            this.parameterFiltersIncludeRadioButton = new System.Windows.Forms.RadioButton();
            this.parameterFiltersExcludeRadioButton = new System.Windows.Forms.RadioButton();
            this.parameterFiltersTextBox = new System.Windows.Forms.TextBox();
            this.shaderFiltersPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shaderFiltersGroupBox.SuspendLayout();
            this.parameterFiltersGroupBox.SuspendLayout();
            this.shaderFiltersPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shaderFiltersGroupBox
            // 
            this.shaderFiltersGroupBox.Controls.Add(this.shaderFiltersPanel);
            this.shaderFiltersGroupBox.Controls.Add(this.shaderFiltersLabel);
            this.shaderFiltersGroupBox.Controls.Add(this.shaderFiltersTextBox);
            this.shaderFiltersGroupBox.Location = new System.Drawing.Point(12, 12);
            this.shaderFiltersGroupBox.Name = "shaderFiltersGroupBox";
            this.shaderFiltersGroupBox.Size = new System.Drawing.Size(272, 426);
            this.shaderFiltersGroupBox.TabIndex = 0;
            this.shaderFiltersGroupBox.TabStop = false;
            this.shaderFiltersGroupBox.Text = "Shader Filters";
            // 
            // shaderFiltersTextBox
            // 
            this.shaderFiltersTextBox.Location = new System.Drawing.Point(13, 54);
            this.shaderFiltersTextBox.Multiline = true;
            this.shaderFiltersTextBox.Name = "shaderFiltersTextBox";
            this.shaderFiltersTextBox.Size = new System.Drawing.Size(253, 343);
            this.shaderFiltersTextBox.TabIndex = 0;
            // 
            // shaderFiltersExcludeRadioButton
            // 
            this.shaderFiltersExcludeRadioButton.AutoSize = true;
            this.shaderFiltersExcludeRadioButton.Checked = true;
            this.shaderFiltersExcludeRadioButton.Location = new System.Drawing.Point(0, 6);
            this.shaderFiltersExcludeRadioButton.Name = "shaderFiltersExcludeRadioButton";
            this.shaderFiltersExcludeRadioButton.Size = new System.Drawing.Size(105, 17);
            this.shaderFiltersExcludeRadioButton.TabIndex = 1;
            this.shaderFiltersExcludeRadioButton.TabStop = true;
            this.shaderFiltersExcludeRadioButton.Text = "Exclude Shaders";
            this.shaderFiltersExcludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // shaderFiltersIncludeRadioButton
            // 
            this.shaderFiltersIncludeRadioButton.AutoSize = true;
            this.shaderFiltersIncludeRadioButton.Location = new System.Drawing.Point(149, 6);
            this.shaderFiltersIncludeRadioButton.Name = "shaderFiltersIncludeRadioButton";
            this.shaderFiltersIncludeRadioButton.Size = new System.Drawing.Size(110, 17);
            this.shaderFiltersIncludeRadioButton.TabIndex = 2;
            this.shaderFiltersIncludeRadioButton.Text = "Only Use Shaders";
            this.shaderFiltersIncludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // shaderFiltersLabel
            // 
            this.shaderFiltersLabel.Location = new System.Drawing.Point(10, 16);
            this.shaderFiltersLabel.Name = "shaderFiltersLabel";
            this.shaderFiltersLabel.Size = new System.Drawing.Size(256, 35);
            this.shaderFiltersLabel.TabIndex = 3;
            this.shaderFiltersLabel.Text = "Type in shaders that you would like to exclude from corruption, separated by a ne" +
    "w line.";
            this.shaderFiltersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // parameterFiltersGroupBox
            // 
            this.parameterFiltersGroupBox.Controls.Add(this.panel1);
            this.parameterFiltersGroupBox.Controls.Add(this.parameterFiltersLabel);
            this.parameterFiltersGroupBox.Controls.Add(this.parameterFiltersTextBox);
            this.parameterFiltersGroupBox.Location = new System.Drawing.Point(290, 12);
            this.parameterFiltersGroupBox.Name = "parameterFiltersGroupBox";
            this.parameterFiltersGroupBox.Size = new System.Drawing.Size(272, 426);
            this.parameterFiltersGroupBox.TabIndex = 4;
            this.parameterFiltersGroupBox.TabStop = false;
            this.parameterFiltersGroupBox.Text = "Parameter Filters";
            // 
            // parameterFiltersLabel
            // 
            this.parameterFiltersLabel.Location = new System.Drawing.Point(10, 16);
            this.parameterFiltersLabel.Name = "parameterFiltersLabel";
            this.parameterFiltersLabel.Size = new System.Drawing.Size(256, 35);
            this.parameterFiltersLabel.TabIndex = 3;
            this.parameterFiltersLabel.Text = "Type in parameters that you would like to exclude from corruption, separated by a" +
    " new line.";
            this.parameterFiltersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // parameterFiltersIncludeRadioButton
            // 
            this.parameterFiltersIncludeRadioButton.AutoSize = true;
            this.parameterFiltersIncludeRadioButton.Location = new System.Drawing.Point(135, 6);
            this.parameterFiltersIncludeRadioButton.Name = "parameterFiltersIncludeRadioButton";
            this.parameterFiltersIncludeRadioButton.Size = new System.Drawing.Size(124, 17);
            this.parameterFiltersIncludeRadioButton.TabIndex = 2;
            this.parameterFiltersIncludeRadioButton.Text = "Only Use Parameters";
            this.parameterFiltersIncludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // parameterFiltersExcludeRadioButton
            // 
            this.parameterFiltersExcludeRadioButton.AutoSize = true;
            this.parameterFiltersExcludeRadioButton.Checked = true;
            this.parameterFiltersExcludeRadioButton.Location = new System.Drawing.Point(0, 6);
            this.parameterFiltersExcludeRadioButton.Name = "parameterFiltersExcludeRadioButton";
            this.parameterFiltersExcludeRadioButton.Size = new System.Drawing.Size(119, 17);
            this.parameterFiltersExcludeRadioButton.TabIndex = 1;
            this.parameterFiltersExcludeRadioButton.TabStop = true;
            this.parameterFiltersExcludeRadioButton.Text = "Exclude Parameters";
            this.parameterFiltersExcludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // parameterFiltersTextBox
            // 
            this.parameterFiltersTextBox.Location = new System.Drawing.Point(13, 54);
            this.parameterFiltersTextBox.Multiline = true;
            this.parameterFiltersTextBox.Name = "parameterFiltersTextBox";
            this.parameterFiltersTextBox.Size = new System.Drawing.Size(253, 343);
            this.parameterFiltersTextBox.TabIndex = 0;
            // 
            // shaderFiltersPanel
            // 
            this.shaderFiltersPanel.Controls.Add(this.shaderFiltersExcludeRadioButton);
            this.shaderFiltersPanel.Controls.Add(this.shaderFiltersIncludeRadioButton);
            this.shaderFiltersPanel.Location = new System.Drawing.Point(13, 397);
            this.shaderFiltersPanel.Name = "shaderFiltersPanel";
            this.shaderFiltersPanel.Size = new System.Drawing.Size(253, 23);
            this.shaderFiltersPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.parameterFiltersIncludeRadioButton);
            this.panel1.Controls.Add(this.parameterFiltersExcludeRadioButton);
            this.panel1.Location = new System.Drawing.Point(13, 397);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 23);
            this.panel1.TabIndex = 5;
            // 
            // FilterOptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 449);
            this.Controls.Add(this.parameterFiltersGroupBox);
            this.Controls.Add(this.shaderFiltersGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilterOptionsWindow";
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.shaderFiltersGroupBox.ResumeLayout(false);
            this.shaderFiltersGroupBox.PerformLayout();
            this.parameterFiltersGroupBox.ResumeLayout(false);
            this.parameterFiltersGroupBox.PerformLayout();
            this.shaderFiltersPanel.ResumeLayout(false);
            this.shaderFiltersPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox shaderFiltersGroupBox;
        private System.Windows.Forms.Label shaderFiltersLabel;
        private System.Windows.Forms.RadioButton shaderFiltersIncludeRadioButton;
        private System.Windows.Forms.RadioButton shaderFiltersExcludeRadioButton;
        private System.Windows.Forms.TextBox shaderFiltersTextBox;
        private System.Windows.Forms.GroupBox parameterFiltersGroupBox;
        private System.Windows.Forms.Label parameterFiltersLabel;
        private System.Windows.Forms.RadioButton parameterFiltersIncludeRadioButton;
        private System.Windows.Forms.RadioButton parameterFiltersExcludeRadioButton;
        private System.Windows.Forms.TextBox parameterFiltersTextBox;
        private System.Windows.Forms.Panel shaderFiltersPanel;
        private System.Windows.Forms.Panel panel1;
    }
}