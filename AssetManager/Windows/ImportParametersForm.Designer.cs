namespace AssetManager
{
    partial class ImportParametersForm
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
            this.importedParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.importedParameterList = new System.Windows.Forms.TreeView();
            this.importedParametersLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.importedParametersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // importedParametersGroupBox
            // 
            this.importedParametersGroupBox.Controls.Add(this.importedParameterList);
            this.importedParametersGroupBox.Controls.Add(this.importedParametersLabel);
            this.importedParametersGroupBox.Location = new System.Drawing.Point(12, 12);
            this.importedParametersGroupBox.Name = "importedParametersGroupBox";
            this.importedParametersGroupBox.Size = new System.Drawing.Size(294, 403);
            this.importedParametersGroupBox.TabIndex = 5;
            this.importedParametersGroupBox.TabStop = false;
            this.importedParametersGroupBox.Text = "Imported Parameters";
            // 
            // importedParameterList
            // 
            this.importedParameterList.CheckBoxes = true;
            this.importedParameterList.Location = new System.Drawing.Point(6, 54);
            this.importedParameterList.Name = "importedParameterList";
            this.importedParameterList.Size = new System.Drawing.Size(282, 343);
            this.importedParameterList.TabIndex = 4;
            this.importedParameterList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.importedParameterList_AfterCheck);
            // 
            // importedParametersLabel
            // 
            this.importedParametersLabel.Location = new System.Drawing.Point(6, 16);
            this.importedParametersLabel.Name = "importedParametersLabel";
            this.importedParametersLabel.Size = new System.Drawing.Size(282, 35);
            this.importedParametersLabel.TabIndex = 3;
            this.importedParametersLabel.Text = "The following parameters were found in the imported file. Please confirm which on" +
    "es you wish to add.\r\n";
            this.importedParametersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(161, 421);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(145, 23);
            this.confirmButton.TabIndex = 12;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 421);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(143, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ImportParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 450);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.importedParametersGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportParametersForm";
            this.ShowInTaskbar = false;
            this.Text = "Import Parameters";
            this.Load += new System.EventHandler(this.ImportParametersForm_Load);
            this.importedParametersGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox importedParametersGroupBox;
        private System.Windows.Forms.Label importedParametersLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TreeView importedParameterList;
    }
}