using System;

namespace AssetManager
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.parameterSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.randomizerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.deviationSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.deviationSettingsParam3Label = new System.Windows.Forms.Label();
            this.randomizerOffsetNumeric3 = new System.Windows.Forms.NumericUpDown();
            this.deviationSettingsParam2Label = new System.Windows.Forms.Label();
            this.randomizerOffsetNumeric2 = new System.Windows.Forms.NumericUpDown();
            this.deviationSettingsParam1Label = new System.Windows.Forms.Label();
            this.randomizerOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.randomizerChanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.vpkDirectoryListing = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.materialParameterList = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.exportLocationValidLabel = new System.Windows.Forms.Label();
            this.gameLocationValidLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.gameLocationText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBox = new System.Windows.Forms.TextBox();
            this.saveFileLocationButton = new System.Windows.Forms.Button();
            this.saveFileLocationText = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.parameterSettingsGroupBox.SuspendLayout();
            this.randomizerSettingsGroupBox.SuspendLayout();
            this.deviationSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerChanceNumeric)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 561);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.parameterSettingsGroupBox);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.materialParameterList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Materials";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // parameterSettingsGroupBox
            // 
            this.parameterSettingsGroupBox.Controls.Add(this.randomizerSettingsGroupBox);
            this.parameterSettingsGroupBox.Controls.Add(this.vpkDirectoryListing);
            this.parameterSettingsGroupBox.Controls.Add(this.label2);
            this.parameterSettingsGroupBox.Location = new System.Drawing.Point(175, 6);
            this.parameterSettingsGroupBox.Name = "parameterSettingsGroupBox";
            this.parameterSettingsGroupBox.Size = new System.Drawing.Size(546, 494);
            this.parameterSettingsGroupBox.TabIndex = 8;
            this.parameterSettingsGroupBox.TabStop = false;
            this.parameterSettingsGroupBox.Text = "Parameter Settings";
            this.parameterSettingsGroupBox.Visible = false;
            // 
            // randomizerSettingsGroupBox
            // 
            this.randomizerSettingsGroupBox.Controls.Add(this.deviationSettingsGroupBox);
            this.randomizerSettingsGroupBox.Controls.Add(this.label5);
            this.randomizerSettingsGroupBox.Controls.Add(this.randomizerChanceNumeric);
            this.randomizerSettingsGroupBox.Location = new System.Drawing.Point(208, 19);
            this.randomizerSettingsGroupBox.Name = "randomizerSettingsGroupBox";
            this.randomizerSettingsGroupBox.Size = new System.Drawing.Size(332, 469);
            this.randomizerSettingsGroupBox.TabIndex = 11;
            this.randomizerSettingsGroupBox.TabStop = false;
            this.randomizerSettingsGroupBox.Text = "Randomizer Settings";
            // 
            // deviationSettingsGroupBox
            // 
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam3Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric3);
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam2Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric2);
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam1Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric);
            this.deviationSettingsGroupBox.Location = new System.Drawing.Point(10, 49);
            this.deviationSettingsGroupBox.Name = "deviationSettingsGroupBox";
            this.deviationSettingsGroupBox.Size = new System.Drawing.Size(313, 109);
            this.deviationSettingsGroupBox.TabIndex = 2;
            this.deviationSettingsGroupBox.TabStop = false;
            this.deviationSettingsGroupBox.Text = "Parameter Value Randomization Settings";
            // 
            // deviationSettingsParam3Label
            // 
            this.deviationSettingsParam3Label.AutoSize = true;
            this.deviationSettingsParam3Label.Location = new System.Drawing.Point(6, 72);
            this.deviationSettingsParam3Label.Name = "deviationSettingsParam3Label";
            this.deviationSettingsParam3Label.Size = new System.Drawing.Size(158, 13);
            this.deviationSettingsParam3Label.TabIndex = 5;
            this.deviationSettingsParam3Label.Text = "Parameter 3 Random Deviation:";
            this.toolTip1.SetToolTip(this.deviationSettingsParam3Label, "How much the parameter can deviate from its original value.");
            // 
            // randomizerOffsetNumeric3
            // 
            this.randomizerOffsetNumeric3.DecimalPlaces = 7;
            this.randomizerOffsetNumeric3.Location = new System.Drawing.Point(187, 70);
            this.randomizerOffsetNumeric3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.randomizerOffsetNumeric3.Name = "randomizerOffsetNumeric3";
            this.randomizerOffsetNumeric3.Size = new System.Drawing.Size(120, 20);
            this.randomizerOffsetNumeric3.TabIndex = 4;
            // 
            // deviationSettingsParam2Label
            // 
            this.deviationSettingsParam2Label.AutoSize = true;
            this.deviationSettingsParam2Label.Location = new System.Drawing.Point(6, 49);
            this.deviationSettingsParam2Label.Name = "deviationSettingsParam2Label";
            this.deviationSettingsParam2Label.Size = new System.Drawing.Size(158, 13);
            this.deviationSettingsParam2Label.TabIndex = 3;
            this.deviationSettingsParam2Label.Text = "Parameter 2 Random Deviation:";
            this.toolTip1.SetToolTip(this.deviationSettingsParam2Label, "How much the parameter can deviate from its original value.");
            // 
            // randomizerOffsetNumeric2
            // 
            this.randomizerOffsetNumeric2.DecimalPlaces = 7;
            this.randomizerOffsetNumeric2.Location = new System.Drawing.Point(187, 47);
            this.randomizerOffsetNumeric2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.randomizerOffsetNumeric2.Name = "randomizerOffsetNumeric2";
            this.randomizerOffsetNumeric2.Size = new System.Drawing.Size(120, 20);
            this.randomizerOffsetNumeric2.TabIndex = 2;
            // 
            // deviationSettingsParam1Label
            // 
            this.deviationSettingsParam1Label.AutoSize = true;
            this.deviationSettingsParam1Label.Location = new System.Drawing.Point(6, 26);
            this.deviationSettingsParam1Label.Name = "deviationSettingsParam1Label";
            this.deviationSettingsParam1Label.Size = new System.Drawing.Size(149, 13);
            this.deviationSettingsParam1Label.TabIndex = 1;
            this.deviationSettingsParam1Label.Text = "Parameter Random Deviation:";
            this.toolTip1.SetToolTip(this.deviationSettingsParam1Label, "How much the parameter can deviate from its original value.");
            // 
            // randomizerOffsetNumeric
            // 
            this.randomizerOffsetNumeric.DecimalPlaces = 7;
            this.randomizerOffsetNumeric.Location = new System.Drawing.Point(187, 24);
            this.randomizerOffsetNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.randomizerOffsetNumeric.Name = "randomizerOffsetNumeric";
            this.randomizerOffsetNumeric.Size = new System.Drawing.Size(120, 20);
            this.randomizerOffsetNumeric.TabIndex = 0;
            this.randomizerOffsetNumeric.ValueChanged += new System.EventHandler(this.RandomizerDeviationNumeric_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Probability Of Appearance (out of 100):";
            this.toolTip1.SetToolTip(this.label5, "The chance of this parameter being used in the selected files.");
            // 
            // randomizerChanceNumeric
            // 
            this.randomizerChanceNumeric.Location = new System.Drawing.Point(203, 23);
            this.randomizerChanceNumeric.Name = "randomizerChanceNumeric";
            this.randomizerChanceNumeric.Size = new System.Drawing.Size(120, 20);
            this.randomizerChanceNumeric.TabIndex = 0;
            this.randomizerChanceNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.randomizerChanceNumeric.ValueChanged += new System.EventHandler(this.RandomizerChanceNumeric_ValueChanged);
            // 
            // vpkDirectoryListing
            // 
            this.vpkDirectoryListing.CheckBoxes = true;
            this.vpkDirectoryListing.Location = new System.Drawing.Point(6, 32);
            this.vpkDirectoryListing.Name = "vpkDirectoryListing";
            this.vpkDirectoryListing.Size = new System.Drawing.Size(183, 456);
            this.vpkDirectoryListing.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Files To Affect";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 507);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 22);
            this.button2.TabIndex = 5;
            this.button2.Text = "Manage Parameters";
            this.toolTip1.SetToolTip(this.button2, "Add, remove, and edit material parameters.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parameters";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // materialParameterList
            // 
            this.materialParameterList.CheckOnClick = true;
            this.materialParameterList.FormattingEnabled = true;
            this.materialParameterList.HorizontalScrollbar = true;
            this.materialParameterList.Location = new System.Drawing.Point(6, 16);
            this.materialParameterList.Name = "materialParameterList";
            this.materialParameterList.Size = new System.Drawing.Size(163, 484);
            this.materialParameterList.TabIndex = 0;
            this.materialParameterList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.MaterialParameterList_ItemCheck);
            this.materialParameterList.SelectedIndexChanged += new System.EventHandler(this.MaterialParameterList_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sounds";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.exportLocationValidLabel);
            this.tabPage3.Controls.Add(this.gameLocationValidLabel);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.gameLocationText);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.progressBox);
            this.tabPage3.Controls.Add(this.saveFileLocationButton);
            this.tabPage3.Controls.Add(this.saveFileLocationText);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(732, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Export";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // exportLocationValidLabel
            // 
            this.exportLocationValidLabel.AutoSize = true;
            this.exportLocationValidLabel.Location = new System.Drawing.Point(622, 276);
            this.exportLocationValidLabel.Name = "exportLocationValidLabel";
            this.exportLocationValidLabel.Size = new System.Drawing.Size(76, 13);
            this.exportLocationValidLabel.TabIndex = 17;
            this.exportLocationValidLabel.Text = "Location valid.";
            // 
            // gameLocationValidLabel
            // 
            this.gameLocationValidLabel.AutoSize = true;
            this.gameLocationValidLabel.Location = new System.Drawing.Point(622, 254);
            this.gameLocationValidLabel.Name = "gameLocationValidLabel";
            this.gameLocationValidLabel.Size = new System.Drawing.Size(97, 13);
            this.gameLocationValidLabel.TabIndex = 16;
            this.gameLocationValidLabel.Text = "gameinfo.txt found.";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(463, 251);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 20);
            this.button3.TabIndex = 15;
            this.button3.Text = "Set Game Location...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // gameLocationText
            // 
            this.gameLocationText.Location = new System.Drawing.Point(91, 251);
            this.gameLocationText.Name = "gameLocationText";
            this.gameLocationText.Size = new System.Drawing.Size(366, 20);
            this.gameLocationText.TabIndex = 14;
            this.gameLocationText.LostFocus += new System.EventHandler(this.GameLocationText_LostFocus);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Export Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Game Location:";
            this.toolTip1.SetToolTip(this.label3, "The location of hl2.exe for Team Fortress 2.");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(725, 44);
            this.button1.TabIndex = 11;
            this.button1.Text = "Begin Packaging";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // progressBox
            // 
            this.progressBox.Location = new System.Drawing.Point(4, 349);
            this.progressBox.Multiline = true;
            this.progressBox.Name = "progressBox";
            this.progressBox.ReadOnly = true;
            this.progressBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.progressBox.Size = new System.Drawing.Size(725, 183);
            this.progressBox.TabIndex = 10;
            // 
            // saveFileLocationButton
            // 
            this.saveFileLocationButton.Location = new System.Drawing.Point(463, 273);
            this.saveFileLocationButton.Name = "saveFileLocationButton";
            this.saveFileLocationButton.Size = new System.Drawing.Size(158, 20);
            this.saveFileLocationButton.TabIndex = 9;
            this.saveFileLocationButton.Text = "Set VPK Export Location...";
            this.saveFileLocationButton.UseVisualStyleBackColor = true;
            this.saveFileLocationButton.Click += new System.EventHandler(this.SaveFileLocationButton_Click);
            // 
            // saveFileLocationText
            // 
            this.saveFileLocationText.Location = new System.Drawing.Point(91, 273);
            this.saveFileLocationText.Name = "saveFileLocationText";
            this.saveFileLocationText.Size = new System.Drawing.Size(366, 20);
            this.saveFileLocationText.TabIndex = 8;
            this.saveFileLocationText.Leave += new System.EventHandler(this.SaveFileLocationText_Leave);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "vpk";
            this.saveFileDialog1.Filter = "Valve Pak|*.vpk";
            this.saveFileDialog1.Title = "Please specify a location for the output VPK.";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 559);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Ready.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Half Life 2 Executable|hl2.exe";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 581);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.parameterSettingsGroupBox.ResumeLayout(false);
            this.parameterSettingsGroupBox.PerformLayout();
            this.randomizerSettingsGroupBox.ResumeLayout(false);
            this.randomizerSettingsGroupBox.PerformLayout();
            this.deviationSettingsGroupBox.ResumeLayout(false);
            this.deviationSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerChanceNumeric)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox materialParameterList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox parameterSettingsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView vpkDirectoryListing;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox progressBox;
        private System.Windows.Forms.Button saveFileLocationButton;
        private System.Windows.Forms.TextBox saveFileLocationText;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox gameLocationText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label exportLocationValidLabel;
        private System.Windows.Forms.Label gameLocationValidLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox randomizerSettingsGroupBox;
        private System.Windows.Forms.GroupBox deviationSettingsGroupBox;
        private System.Windows.Forms.Label deviationSettingsParam1Label;
        private System.Windows.Forms.NumericUpDown randomizerOffsetNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown randomizerChanceNumeric;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label deviationSettingsParam3Label;
        private System.Windows.Forms.NumericUpDown randomizerOffsetNumeric3;
        private System.Windows.Forms.Label deviationSettingsParam2Label;
        private System.Windows.Forms.NumericUpDown randomizerOffsetNumeric2;
    }
}

