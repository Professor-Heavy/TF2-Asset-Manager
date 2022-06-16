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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.corruptionHighOffsetNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionLowOffsetNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // corruptionHighOffsetLabel
            // 
            this.corruptionHighOffsetLabel.AutoSize = true;
            this.corruptionHighOffsetLabel.Location = new System.Drawing.Point(12, 32);
            this.corruptionHighOffsetLabel.Name = "corruptionHighOffsetLabel";
            this.corruptionHighOffsetLabel.Size = new System.Drawing.Size(116, 13);
            this.corruptionHighOffsetLabel.TabIndex = 7;
            this.corruptionHighOffsetLabel.Text = "Highest Random Value";
            // 
            // corruptionHighOffsetNumeric
            // 
            this.corruptionHighOffsetNumeric.Location = new System.Drawing.Point(132, 30);
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
            this.corruptionLowOffsetLabel.Location = new System.Drawing.Point(12, 9);
            this.corruptionLowOffsetLabel.Name = "corruptionLowOffsetLabel";
            this.corruptionLowOffsetLabel.Size = new System.Drawing.Size(114, 13);
            this.corruptionLowOffsetLabel.TabIndex = 5;
            this.corruptionLowOffsetLabel.Text = "Lowest Random Value";
            // 
            // corruptionLowOffsetNumeric
            // 
            this.corruptionLowOffsetNumeric.Location = new System.Drawing.Point(132, 7);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(84, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(203, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Allow Parameter To Exceed Negative";
            this.toolTip1.SetToolTip(this.checkBox1, "If checked, parameters can exceed negative values if they are offset below 0.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(177, 79);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(152, 23);
            this.confirmButton.TabIndex = 10;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 79);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(159, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CorruptionOffsetSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 110);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.checkBox1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label corruptionHighOffsetLabel;
        private System.Windows.Forms.NumericUpDown corruptionHighOffsetNumeric;
        private System.Windows.Forms.Label corruptionLowOffsetLabel;
        private System.Windows.Forms.NumericUpDown corruptionLowOffsetNumeric;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}