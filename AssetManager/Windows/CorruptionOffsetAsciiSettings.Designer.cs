namespace AssetManager
{
    partial class CorruptionOffsetAsciiSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorruptionOffsetAsciiSettings));
            this.highBoundsNumeric = new System.Windows.Forms.NumericUpDown();
            this.highBoundsCheckBox = new System.Windows.Forms.CheckBox();
            this.lowBoundsNumeric = new System.Windows.Forms.NumericUpDown();
            this.lowBoundsCheckBox = new System.Windows.Forms.CheckBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.corruptionHighOffsetLabel = new System.Windows.Forms.Label();
            this.corruptionHighOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            this.corruptionLowOffsetLabel = new System.Windows.Forms.Label();
            this.corruptionLowOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outOfRangeResolveComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.offsetPreviewTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.simulateExampleButton = new System.Windows.Forms.Button();
            this.simulateCorruptionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.offsetExampleNumeric = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.corruptionOffsetWarningStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.highBoundsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowBoundsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionHighOffsetNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionLowOffsetNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetExampleNumeric)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // highBoundsNumeric
            // 
            this.highBoundsNumeric.Location = new System.Drawing.Point(155, 92);
            this.highBoundsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.highBoundsNumeric.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.highBoundsNumeric.Name = "highBoundsNumeric";
            this.highBoundsNumeric.Size = new System.Drawing.Size(76, 20);
            this.highBoundsNumeric.TabIndex = 24;
            this.highBoundsNumeric.ValueChanged += new System.EventHandler(this.highBoundsNumeric_ValueChanged);
            // 
            // highBoundsCheckBox
            // 
            this.highBoundsCheckBox.AutoSize = true;
            this.highBoundsCheckBox.Location = new System.Drawing.Point(9, 92);
            this.highBoundsCheckBox.Name = "highBoundsCheckBox";
            this.highBoundsCheckBox.Size = new System.Drawing.Size(140, 17);
            this.highBoundsCheckBox.TabIndex = 23;
            this.highBoundsCheckBox.Text = "Enforce Maximum Value";
            this.highBoundsCheckBox.UseVisualStyleBackColor = true;
            this.highBoundsCheckBox.CheckedChanged += new System.EventHandler(this.highBoundsCheckBox_CheckedChanged);
            // 
            // lowBoundsNumeric
            // 
            this.lowBoundsNumeric.Location = new System.Drawing.Point(155, 68);
            this.lowBoundsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lowBoundsNumeric.Name = "lowBoundsNumeric";
            this.lowBoundsNumeric.Size = new System.Drawing.Size(76, 20);
            this.lowBoundsNumeric.TabIndex = 22;
            this.lowBoundsNumeric.ValueChanged += new System.EventHandler(this.lowBoundsNumeric_ValueChanged);
            // 
            // lowBoundsCheckBox
            // 
            this.lowBoundsCheckBox.AutoSize = true;
            this.lowBoundsCheckBox.Location = new System.Drawing.Point(9, 69);
            this.lowBoundsCheckBox.Name = "lowBoundsCheckBox";
            this.lowBoundsCheckBox.Size = new System.Drawing.Size(137, 17);
            this.lowBoundsCheckBox.TabIndex = 21;
            this.lowBoundsCheckBox.Text = "Enforce Minimum Value";
            this.lowBoundsCheckBox.UseVisualStyleBackColor = true;
            this.lowBoundsCheckBox.CheckedChanged += new System.EventHandler(this.lowBoundsCheckBox_CheckedChanged);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(260, 506);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(223, 23);
            this.confirmButton.TabIndex = 20;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 506);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(242, 23);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // corruptionHighOffsetLabel
            // 
            this.corruptionHighOffsetLabel.AutoSize = true;
            this.corruptionHighOffsetLabel.Location = new System.Drawing.Point(6, 44);
            this.corruptionHighOffsetLabel.Name = "corruptionHighOffsetLabel";
            this.corruptionHighOffsetLabel.Size = new System.Drawing.Size(116, 13);
            this.corruptionHighOffsetLabel.TabIndex = 18;
            this.corruptionHighOffsetLabel.Text = "Highest Random Value";
            // 
            // corruptionHighOffsetNumeric
            // 
            this.corruptionHighOffsetNumeric.Location = new System.Drawing.Point(155, 42);
            this.corruptionHighOffsetNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.corruptionHighOffsetNumeric.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.corruptionHighOffsetNumeric.Name = "corruptionHighOffsetNumeric";
            this.corruptionHighOffsetNumeric.Size = new System.Drawing.Size(76, 20);
            this.corruptionHighOffsetNumeric.TabIndex = 17;
            this.corruptionHighOffsetNumeric.ValueChanged += new System.EventHandler(this.corruptionHighOffsetNumeric_ValueChanged);
            // 
            // corruptionLowOffsetLabel
            // 
            this.corruptionLowOffsetLabel.AutoSize = true;
            this.corruptionLowOffsetLabel.Location = new System.Drawing.Point(6, 21);
            this.corruptionLowOffsetLabel.Name = "corruptionLowOffsetLabel";
            this.corruptionLowOffsetLabel.Size = new System.Drawing.Size(114, 13);
            this.corruptionLowOffsetLabel.TabIndex = 16;
            this.corruptionLowOffsetLabel.Text = "Lowest Random Value";
            // 
            // corruptionLowOffsetNumeric
            // 
            this.corruptionLowOffsetNumeric.Location = new System.Drawing.Point(155, 19);
            this.corruptionLowOffsetNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.corruptionLowOffsetNumeric.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.corruptionLowOffsetNumeric.Name = "corruptionLowOffsetNumeric";
            this.corruptionLowOffsetNumeric.Size = new System.Drawing.Size(76, 20);
            this.corruptionLowOffsetNumeric.TabIndex = 15;
            this.corruptionLowOffsetNumeric.ValueChanged += new System.EventHandler(this.corruptionLowOffsetNumeric_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outOfRangeResolveComboBox);
            this.groupBox1.Controls.Add(this.corruptionLowOffsetLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.highBoundsNumeric);
            this.groupBox1.Controls.Add(this.corruptionLowOffsetNumeric);
            this.groupBox1.Controls.Add(this.highBoundsCheckBox);
            this.groupBox1.Controls.Add(this.corruptionHighOffsetNumeric);
            this.groupBox1.Controls.Add(this.lowBoundsNumeric);
            this.groupBox1.Controls.Add(this.corruptionHighOffsetLabel);
            this.groupBox1.Controls.Add(this.lowBoundsCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 156);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Corruption Settings";
            // 
            // outOfRangeResolveComboBox
            // 
            this.outOfRangeResolveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outOfRangeResolveComboBox.FormattingEnabled = true;
            this.outOfRangeResolveComboBox.Items.AddRange(new object[] {
            "Strict Enforce",
            "Round to Limit",
            "Bounce through Range"});
            this.outOfRangeResolveComboBox.Location = new System.Drawing.Point(134, 118);
            this.outOfRangeResolveComboBox.Name = "outOfRangeResolveComboBox";
            this.outOfRangeResolveComboBox.Size = new System.Drawing.Size(151, 21);
            this.outOfRangeResolveComboBox.TabIndex = 26;
            this.outOfRangeResolveComboBox.SelectedIndexChanged += new System.EventHandler(this.outOfRangeResolveComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Out of Range Behaviour";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.offsetPreviewTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 326);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Example";
            // 
            // offsetPreviewTextBox
            // 
            this.offsetPreviewTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offsetPreviewTextBox.Location = new System.Drawing.Point(9, 19);
            this.offsetPreviewTextBox.Name = "offsetPreviewTextBox";
            this.offsetPreviewTextBox.ReadOnly = true;
            this.offsetPreviewTextBox.Size = new System.Drawing.Size(456, 301);
            this.offsetPreviewTextBox.TabIndex = 33;
            this.offsetPreviewTextBox.Text = resources.GetString("offsetPreviewTextBox.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.simulateExampleButton);
            this.groupBox3.Controls.Add(this.simulateCorruptionButton);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.offsetExampleNumeric);
            this.groupBox3.Location = new System.Drawing.Point(309, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 156);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Example Settings";
            // 
            // simulateExampleButton
            // 
            this.simulateExampleButton.Location = new System.Drawing.Point(9, 45);
            this.simulateExampleButton.Name = "simulateExampleButton";
            this.simulateExampleButton.Size = new System.Drawing.Size(159, 23);
            this.simulateExampleButton.TabIndex = 27;
            this.simulateExampleButton.Text = "Simulate Example Settings";
            this.simulateExampleButton.UseVisualStyleBackColor = true;
            this.simulateExampleButton.Click += new System.EventHandler(this.simulateExampleButton_Click);
            // 
            // simulateCorruptionButton
            // 
            this.simulateCorruptionButton.Location = new System.Drawing.Point(9, 74);
            this.simulateCorruptionButton.Name = "simulateCorruptionButton";
            this.simulateCorruptionButton.Size = new System.Drawing.Size(159, 23);
            this.simulateCorruptionButton.TabIndex = 26;
            this.simulateCorruptionButton.Text = "Simulate Corruption Settings";
            this.simulateCorruptionButton.UseVisualStyleBackColor = true;
            this.simulateCorruptionButton.Click += new System.EventHandler(this.simulateCorruptionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Offset Value";
            // 
            // offsetExampleNumeric
            // 
            this.offsetExampleNumeric.Location = new System.Drawing.Point(92, 19);
            this.offsetExampleNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.offsetExampleNumeric.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.offsetExampleNumeric.Name = "offsetExampleNumeric";
            this.offsetExampleNumeric.Size = new System.Drawing.Size(76, 20);
            this.offsetExampleNumeric.TabIndex = 25;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.corruptionOffsetWarningStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(495, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // corruptionOffsetWarningStatusLabel
            // 
            this.corruptionOffsetWarningStatusLabel.Name = "corruptionOffsetWarningStatusLabel";
            this.corruptionOffsetWarningStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // CorruptionOffsetAsciiSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 557);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.Name = "CorruptionOffsetAsciiSettings";
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.Load += new System.EventHandler(this.CorruptionOffsetAsciiSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.highBoundsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowBoundsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionHighOffsetNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionLowOffsetNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetExampleNumeric)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown highBoundsNumeric;
        private System.Windows.Forms.CheckBox highBoundsCheckBox;
        private System.Windows.Forms.NumericUpDown lowBoundsNumeric;
        private System.Windows.Forms.CheckBox lowBoundsCheckBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label corruptionHighOffsetLabel;
        private System.Windows.Forms.NumericUpDown corruptionHighOffsetNumeric;
        private System.Windows.Forms.Label corruptionLowOffsetLabel;
        private System.Windows.Forms.NumericUpDown corruptionLowOffsetNumeric;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown offsetExampleNumeric;
        private System.Windows.Forms.RichTextBox offsetPreviewTextBox;
        private System.Windows.Forms.Button simulateCorruptionButton;
        private System.Windows.Forms.Button simulateExampleButton;
        private System.Windows.Forms.ComboBox outOfRangeResolveComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel corruptionOffsetWarningStatusLabel;
    }
}