namespace AssetManager
{
    partial class CorruptionOffsetSettings
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
            this.corruptionHighOffsetLabel = new System.Windows.Forms.Label();
            this.corruptionHighOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            this.corruptionLowOffsetLabel = new System.Windows.Forms.Label();
            this.corruptionLowOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lowBoundsCheckBox = new System.Windows.Forms.CheckBox();
            this.lowBoundsNumeric = new System.Windows.Forms.NumericUpDown();
            this.highBoundsNumeric = new System.Windows.Forms.NumericUpDown();
            this.highBoundsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionHighOffsetNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionLowOffsetNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowBoundsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highBoundsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // corruptionHighOffsetLabel
            // 
            this.corruptionHighOffsetLabel.AutoSize = true;
            this.corruptionHighOffsetLabel.Location = new System.Drawing.Point(15, 31);
            this.corruptionHighOffsetLabel.Name = "corruptionHighOffsetLabel";
            this.corruptionHighOffsetLabel.Size = new System.Drawing.Size(116, 13);
            this.corruptionHighOffsetLabel.TabIndex = 7;
            this.corruptionHighOffsetLabel.Text = "Highest Random Value";
            // 
            // corruptionHighOffsetNumeric
            // 
            this.corruptionHighOffsetNumeric.Location = new System.Drawing.Point(158, 29);
            this.corruptionHighOffsetNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.corruptionHighOffsetNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.corruptionHighOffsetNumeric.Name = "corruptionHighOffsetNumeric";
            this.corruptionHighOffsetNumeric.Size = new System.Drawing.Size(76, 20);
            this.corruptionHighOffsetNumeric.TabIndex = 6;
            this.toolTip1.SetToolTip(this.corruptionHighOffsetNumeric, "Sets the highest possible range that parameters can be offset by.");
            // 
            // corruptionLowOffsetLabel
            // 
            this.corruptionLowOffsetLabel.AutoSize = true;
            this.corruptionLowOffsetLabel.Location = new System.Drawing.Point(15, 8);
            this.corruptionLowOffsetLabel.Name = "corruptionLowOffsetLabel";
            this.corruptionLowOffsetLabel.Size = new System.Drawing.Size(114, 13);
            this.corruptionLowOffsetLabel.TabIndex = 5;
            this.corruptionLowOffsetLabel.Text = "Lowest Random Value";
            // 
            // corruptionLowOffsetNumeric
            // 
            this.corruptionLowOffsetNumeric.Location = new System.Drawing.Point(158, 6);
            this.corruptionLowOffsetNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.corruptionLowOffsetNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.corruptionLowOffsetNumeric.Name = "corruptionLowOffsetNumeric";
            this.corruptionLowOffsetNumeric.Size = new System.Drawing.Size(76, 20);
            this.corruptionLowOffsetNumeric.TabIndex = 4;
            this.toolTip1.SetToolTip(this.corruptionLowOffsetNumeric, "Sets the lowest possible range that parameters can be offset by.");
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(132, 106);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(114, 23);
            this.confirmButton.TabIndex = 10;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 106);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // lowBoundsCheckBox
            // 
            this.lowBoundsCheckBox.AutoSize = true;
            this.lowBoundsCheckBox.Location = new System.Drawing.Point(18, 57);
            this.lowBoundsCheckBox.Name = "lowBoundsCheckBox";
            this.lowBoundsCheckBox.Size = new System.Drawing.Size(137, 17);
            this.lowBoundsCheckBox.TabIndex = 11;
            this.lowBoundsCheckBox.Text = "Enforce Minimum Value";
            this.toolTip1.SetToolTip(this.lowBoundsCheckBox, "Allows for a limit to be placed on offsets, preventing them from going below this" +
        " value.");
            this.lowBoundsCheckBox.UseVisualStyleBackColor = true;
            this.lowBoundsCheckBox.CheckedChanged += new System.EventHandler(this.lowBoundsCheckBox_CheckedChanged);
            // 
            // lowBoundsNumeric
            // 
            this.lowBoundsNumeric.Location = new System.Drawing.Point(158, 55);
            this.lowBoundsNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.lowBoundsNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.lowBoundsNumeric.Name = "lowBoundsNumeric";
            this.lowBoundsNumeric.Size = new System.Drawing.Size(76, 20);
            this.lowBoundsNumeric.TabIndex = 12;
            this.toolTip1.SetToolTip(this.lowBoundsNumeric, "Sets the lowest possible range that parameters can be offset by.");
            // 
            // highBoundsNumeric
            // 
            this.highBoundsNumeric.Location = new System.Drawing.Point(158, 79);
            this.highBoundsNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.highBoundsNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.highBoundsNumeric.Name = "highBoundsNumeric";
            this.highBoundsNumeric.Size = new System.Drawing.Size(76, 20);
            this.highBoundsNumeric.TabIndex = 14;
            this.toolTip1.SetToolTip(this.highBoundsNumeric, "Sets the lowest possible range that parameters can be offset by.");
            // 
            // highBoundsCheckBox
            // 
            this.highBoundsCheckBox.AutoSize = true;
            this.highBoundsCheckBox.Location = new System.Drawing.Point(18, 80);
            this.highBoundsCheckBox.Name = "highBoundsCheckBox";
            this.highBoundsCheckBox.Size = new System.Drawing.Size(140, 17);
            this.highBoundsCheckBox.TabIndex = 13;
            this.highBoundsCheckBox.Text = "Enforce Maximum Value";
            this.toolTip1.SetToolTip(this.highBoundsCheckBox, "Allows for a limit to be placed on offsets, preventing them from going above this" +
        " value.");
            this.highBoundsCheckBox.UseVisualStyleBackColor = true;
            this.highBoundsCheckBox.CheckedChanged += new System.EventHandler(this.highBoundsCheckBox_CheckedChanged);
            // 
            // CorruptionOffsetSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 141);
            this.Controls.Add(this.highBoundsNumeric);
            this.Controls.Add(this.highBoundsCheckBox);
            this.Controls.Add(this.lowBoundsNumeric);
            this.Controls.Add(this.lowBoundsCheckBox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.corruptionHighOffsetLabel);
            this.Controls.Add(this.corruptionHighOffsetNumeric);
            this.Controls.Add(this.corruptionLowOffsetLabel);
            this.Controls.Add(this.corruptionLowOffsetNumeric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CorruptionOffsetSettings";
            this.ShowInTaskbar = false;
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.Load += new System.EventHandler(this.CorruptionOffsetSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.corruptionHighOffsetNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionLowOffsetNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowBoundsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highBoundsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label corruptionHighOffsetLabel;
        private System.Windows.Forms.NumericUpDown corruptionHighOffsetNumeric;
        private System.Windows.Forms.Label corruptionLowOffsetLabel;
        private System.Windows.Forms.NumericUpDown corruptionLowOffsetNumeric;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox lowBoundsCheckBox;
        private System.Windows.Forms.NumericUpDown lowBoundsNumeric;
        private System.Windows.Forms.NumericUpDown highBoundsNumeric;
        private System.Windows.Forms.CheckBox highBoundsCheckBox;
    }
}