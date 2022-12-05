namespace AssetManager
{
    partial class ExportParametersForm
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
            this.exportParameterList = new System.Windows.Forms.TreeView();
            this.importedParametersLabel = new System.Windows.Forms.Label();
            this.exportParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.exportParametersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportParameterList
            // 
            this.exportParameterList.CheckBoxes = true;
            this.exportParameterList.Location = new System.Drawing.Point(6, 40);
            this.exportParameterList.Name = "exportParameterList";
            this.exportParameterList.Size = new System.Drawing.Size(282, 357);
            this.exportParameterList.TabIndex = 4;
            this.exportParameterList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.exportParameterList_AfterCheck);
            // 
            // importedParametersLabel
            // 
            this.importedParametersLabel.Location = new System.Drawing.Point(6, 16);
            this.importedParametersLabel.Name = "importedParametersLabel";
            this.importedParametersLabel.Size = new System.Drawing.Size(282, 21);
            this.importedParametersLabel.TabIndex = 3;
            this.importedParametersLabel.Text = "Please select which parameters to export to a file.";
            this.importedParametersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exportParametersGroupBox
            // 
            this.exportParametersGroupBox.Controls.Add(this.exportParameterList);
            this.exportParametersGroupBox.Controls.Add(this.importedParametersLabel);
            this.exportParametersGroupBox.Location = new System.Drawing.Point(12, 12);
            this.exportParametersGroupBox.Name = "exportParametersGroupBox";
            this.exportParametersGroupBox.Size = new System.Drawing.Size(294, 403);
            this.exportParametersGroupBox.TabIndex = 6;
            this.exportParametersGroupBox.TabStop = false;
            this.exportParametersGroupBox.Text = "Parameters to Export";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(161, 421);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(145, 23);
            this.confirmButton.TabIndex = 14;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 421);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(143, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "XML File|*.xml";
            this.saveFileDialog.Title = "Please specify a location for the exported parameter file.";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // ExportParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 450);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exportParametersGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportParametersForm";
            this.ShowInTaskbar = false;
            this.Text = "Export Parameters";
            this.Load += new System.EventHandler(this.ExportParametersForm_Load);
            this.exportParametersGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView exportParameterList;
        private System.Windows.Forms.Label importedParametersLabel;
        private System.Windows.Forms.GroupBox exportParametersGroupBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}