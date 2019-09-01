using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AssetManager
{
    partial class ManageParametersWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageParametersWindow));
            this.materialParameterList = new System.Windows.Forms.ListBox();
            this.AddParameterButton = new System.Windows.Forms.Button();
            this.RemoveParameterButton = new System.Windows.Forms.Button();
            this.materialTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.materialParameterName = new System.Windows.Forms.TextBox();
            this.materialParameter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.materialParameterValue = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorSliderGroup = new System.Windows.Forms.GroupBox();
            this.colorPreview = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.proxyPropertiesGroup = new System.Windows.Forms.GroupBox();
            this.removeProxyButton = new System.Windows.Forms.Button();
            this.addProxyButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.multipleChoiceFormButton = new System.Windows.Forms.Button();
            this.colorCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.colorSliderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            this.proxyPropertiesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialParameterList
            // 
            this.materialParameterList.FormattingEnabled = true;
            this.materialParameterList.Location = new System.Drawing.Point(12, 12);
            this.materialParameterList.Name = "materialParameterList";
            this.materialParameterList.Size = new System.Drawing.Size(148, 394);
            this.materialParameterList.TabIndex = 0;
            this.materialParameterList.SelectedIndexChanged += new System.EventHandler(this.MaterialParameterList_SelectedIndexChanged);
            // 
            // AddParameterButton
            // 
            this.AddParameterButton.Location = new System.Drawing.Point(12, 412);
            this.AddParameterButton.Name = "AddParameterButton";
            this.AddParameterButton.Size = new System.Drawing.Size(64, 23);
            this.AddParameterButton.TabIndex = 16;
            this.AddParameterButton.Text = "Add";
            this.AddParameterButton.UseVisualStyleBackColor = true;
            this.AddParameterButton.Click += new System.EventHandler(this.AddParameterButton_Click);
            // 
            // RemoveParameterButton
            // 
            this.RemoveParameterButton.Location = new System.Drawing.Point(93, 412);
            this.RemoveParameterButton.Name = "RemoveParameterButton";
            this.RemoveParameterButton.Size = new System.Drawing.Size(67, 23);
            this.RemoveParameterButton.TabIndex = 17;
            this.RemoveParameterButton.Text = "Remove";
            this.RemoveParameterButton.UseVisualStyleBackColor = true;
            this.RemoveParameterButton.Click += new System.EventHandler(this.RemoveParameterButton_Click);
            // 
            // materialTypeComboBox
            // 
            this.materialTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialTypeComboBox.FormattingEnabled = true;
            this.materialTypeComboBox.Items.AddRange(new object[] {
            "",
            "vector3-int",
            "vector3-color",
            "vector3-float",
            "integer",
            "string",
            "bool",
            "proxy",
            "Random Choice Array"});
            this.materialTypeComboBox.Location = new System.Drawing.Point(451, 28);
            this.materialTypeComboBox.Name = "materialTypeComboBox";
            this.materialTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.materialTypeComboBox.TabIndex = 3;
            this.materialTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.MaterialTypeComboBox_SelectedIndexChanged);
            this.materialTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.MaterialTypeComboBox_SelectedChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parameter Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parameter Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Parameter";
            // 
            // materialParameterName
            // 
            this.materialParameterName.Location = new System.Drawing.Point(181, 28);
            this.materialParameterName.Name = "materialParameterName";
            this.materialParameterName.Size = new System.Drawing.Size(100, 20);
            this.materialParameterName.TabIndex = 1;
            this.materialParameterName.TextChanged += new System.EventHandler(this.MaterialParameterName_TextChanged);
            // 
            // materialParameter
            // 
            this.materialParameter.Location = new System.Drawing.Point(321, 28);
            this.materialParameter.Name = "materialParameter";
            this.materialParameter.Size = new System.Drawing.Size(100, 20);
            this.materialParameter.TabIndex = 2;
            this.materialParameter.TextChanged += new System.EventHandler(this.MaterialParameter_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Value";
            // 
            // materialParameterValue
            // 
            this.materialParameterValue.Location = new System.Drawing.Point(181, 77);
            this.materialParameterValue.Name = "materialParameterValue";
            this.materialParameterValue.Size = new System.Drawing.Size(391, 20);
            this.materialParameterValue.TabIndex = 4;
            this.materialParameterValue.TextChanged += new System.EventHandler(this.MaterialParameterValue_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(593, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // colorSliderGroup
            // 
            this.colorSliderGroup.Controls.Add(this.colorPreview);
            this.colorSliderGroup.Controls.Add(this.label8);
            this.colorSliderGroup.Controls.Add(this.blueLabel);
            this.colorSliderGroup.Controls.Add(this.blueTrackBar);
            this.colorSliderGroup.Controls.Add(this.label5);
            this.colorSliderGroup.Controls.Add(this.greenLabel);
            this.colorSliderGroup.Controls.Add(this.greenTrackBar);
            this.colorSliderGroup.Controls.Add(this.label6);
            this.colorSliderGroup.Controls.Add(this.redLabel);
            this.colorSliderGroup.Controls.Add(this.redTrackBar);
            this.colorSliderGroup.Location = new System.Drawing.Point(181, 103);
            this.colorSliderGroup.Name = "colorSliderGroup";
            this.colorSliderGroup.Size = new System.Drawing.Size(391, 107);
            this.colorSliderGroup.TabIndex = 12;
            this.colorSliderGroup.TabStop = false;
            this.colorSliderGroup.Text = "Color Sliders";
            // 
            // colorPreview
            // 
            this.colorPreview.BackColor = System.Drawing.SystemColors.Control;
            this.colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorPreview.Location = new System.Drawing.Point(361, 22);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(21, 69);
            this.colorPreview.TabIndex = 9;
            this.colorPreview.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Blue";
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(332, 78);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(13, 13);
            this.blueLabel.TabIndex = 7;
            this.blueLabel.Text = "0";
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.AutoSize = false;
            this.blueTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.blueTrackBar.Location = new System.Drawing.Point(43, 75);
            this.blueTrackBar.Maximum = 255;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(292, 24);
            this.blueTrackBar.TabIndex = 7;
            this.blueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.blueTrackBar.Scroll += new System.EventHandler(this.BlueTrackBar_Scroll);
            this.blueTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScrollBarsChanged);
            this.blueTrackBar.MouseCaptureChanged += new System.EventHandler(this.ScrollBarsChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Green";
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(332, 50);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(13, 13);
            this.greenLabel.TabIndex = 4;
            this.greenLabel.Text = "0";
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.AutoSize = false;
            this.greenTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.greenTrackBar.Location = new System.Drawing.Point(43, 47);
            this.greenTrackBar.Maximum = 255;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(292, 28);
            this.greenTrackBar.TabIndex = 6;
            this.greenTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.greenTrackBar.Scroll += new System.EventHandler(this.GreenTrackBar_Scroll);
            this.greenTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScrollBarsChanged);
            this.greenTrackBar.MouseCaptureChanged += new System.EventHandler(this.ScrollBarsChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Red";
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(332, 22);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(13, 13);
            this.redLabel.TabIndex = 1;
            this.redLabel.Text = "0";
            // 
            // redTrackBar
            // 
            this.redTrackBar.AutoSize = false;
            this.redTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.redTrackBar.Location = new System.Drawing.Point(43, 19);
            this.redTrackBar.Maximum = 255;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(292, 28);
            this.redTrackBar.TabIndex = 5;
            this.redTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.redTrackBar.Scroll += new System.EventHandler(this.RedTrackBar_Scroll);
            this.redTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScrollBarsChanged);
            this.redTrackBar.MouseCaptureChanged += new System.EventHandler(this.ScrollBarsChanged);
            // 
            // proxyPropertiesGroup
            // 
            this.proxyPropertiesGroup.Controls.Add(this.removeProxyButton);
            this.proxyPropertiesGroup.Controls.Add(this.addProxyButton);
            this.proxyPropertiesGroup.Controls.Add(this.label9);
            this.proxyPropertiesGroup.Controls.Add(this.label7);
            this.proxyPropertiesGroup.Location = new System.Drawing.Point(181, 216);
            this.proxyPropertiesGroup.Name = "proxyPropertiesGroup";
            this.proxyPropertiesGroup.Size = new System.Drawing.Size(391, 219);
            this.proxyPropertiesGroup.TabIndex = 13;
            this.proxyPropertiesGroup.TabStop = false;
            this.proxyPropertiesGroup.Text = "Proxy Properties";
            this.proxyPropertiesGroup.Visible = false;
            // 
            // removeProxyButton
            // 
            this.removeProxyButton.Location = new System.Drawing.Point(207, 32);
            this.removeProxyButton.Name = "removeProxyButton";
            this.removeProxyButton.Size = new System.Drawing.Size(61, 23);
            this.removeProxyButton.TabIndex = 17;
            this.removeProxyButton.Text = "Remove";
            this.removeProxyButton.UseVisualStyleBackColor = true;
            this.removeProxyButton.Click += new System.EventHandler(this.RemoveProxyButton_Click);
            // 
            // addProxyButton
            // 
            this.addProxyButton.Location = new System.Drawing.Point(140, 32);
            this.addProxyButton.Name = "addProxyButton";
            this.addProxyButton.Size = new System.Drawing.Size(61, 23);
            this.addProxyButton.TabIndex = 16;
            this.addProxyButton.Text = "Add";
            this.addProxyButton.UseVisualStyleBackColor = true;
            this.addProxyButton.Click += new System.EventHandler(this.AddProxyButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Parameter\'s Value/Variable";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Proxy Parameter";
            // 
            // multipleChoiceFormButton
            // 
            this.multipleChoiceFormButton.Location = new System.Drawing.Point(181, 77);
            this.multipleChoiceFormButton.Name = "multipleChoiceFormButton";
            this.multipleChoiceFormButton.Size = new System.Drawing.Size(391, 20);
            this.multipleChoiceFormButton.TabIndex = 18;
            this.multipleChoiceFormButton.Text = "Enter Values...";
            this.multipleChoiceFormButton.UseVisualStyleBackColor = true;
            this.multipleChoiceFormButton.Visible = false;
            this.multipleChoiceFormButton.Click += new System.EventHandler(this.MultipleChoiceFormButton_Click);
            // 
            // colorCheckBox
            // 
            this.colorCheckBox.AutoSize = true;
            this.colorCheckBox.Location = new System.Drawing.Point(451, 55);
            this.colorCheckBox.Name = "colorCheckBox";
            this.colorCheckBox.Size = new System.Drawing.Size(121, 17);
            this.colorCheckBox.TabIndex = 19;
            this.colorCheckBox.Text = "Display Color Sliders";
            this.colorCheckBox.UseVisualStyleBackColor = true;
            this.colorCheckBox.Visible = false;
            this.colorCheckBox.CheckedChanged += new System.EventHandler(this.ColorCheckBox_CheckedChanged);
            this.colorCheckBox.VisibleChanged += new System.EventHandler(this.ColorCheckBox_VisibleChanged);
            // 
            // ManageParametersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 471);
            this.Controls.Add(this.colorCheckBox);
            this.Controls.Add(this.multipleChoiceFormButton);
            this.Controls.Add(this.materialParameterValue);
            this.Controls.Add(this.proxyPropertiesGroup);
            this.Controls.Add(this.colorSliderGroup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.materialParameter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.materialParameterName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.materialTypeComboBox);
            this.Controls.Add(this.RemoveParameterButton);
            this.Controls.Add(this.AddParameterButton);
            this.Controls.Add(this.materialParameterList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageParametersWindow";
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.colorSliderGroup.ResumeLayout(false);
            this.colorSliderGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            this.proxyPropertiesGroup.ResumeLayout(false);
            this.proxyPropertiesGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox materialParameterList;
        private System.Windows.Forms.Button AddParameterButton;
        private System.Windows.Forms.Button RemoveParameterButton;
        private System.Windows.Forms.ComboBox materialTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox materialParameterName;
        private System.Windows.Forms.TextBox materialParameter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox materialParameterValue;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox colorSliderGroup;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.PictureBox colorPreview;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private GroupBox proxyPropertiesGroup;
        private Label label9;
        private Label label7;
        private Button addProxyButton;
        private Button removeProxyButton;
        private Button multipleChoiceFormButton;
        private CheckBox colorCheckBox;
    }
}