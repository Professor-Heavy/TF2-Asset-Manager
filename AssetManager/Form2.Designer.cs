namespace AssetManager
{
    partial class Form2
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
            this.materialParameterList = new System.Windows.Forms.ListBox();
            this.AddParameterButton = new System.Windows.Forms.Button();
            this.RemoveParameterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // materialParameterList
            // 
            this.materialParameterList.FormattingEnabled = true;
            this.materialParameterList.Location = new System.Drawing.Point(12, 12);
            this.materialParameterList.Name = "materialParameterList";
            this.materialParameterList.Size = new System.Drawing.Size(148, 160);
            this.materialParameterList.TabIndex = 0;
            // 
            // AddParameterButton
            // 
            this.AddParameterButton.Location = new System.Drawing.Point(12, 178);
            this.AddParameterButton.Name = "AddParameterButton";
            this.AddParameterButton.Size = new System.Drawing.Size(75, 23);
            this.AddParameterButton.TabIndex = 1;
            this.AddParameterButton.Text = "Add";
            this.AddParameterButton.UseVisualStyleBackColor = true;
            this.AddParameterButton.Click += new System.EventHandler(this.AddParameterButton_Click);
            // 
            // RemoveParameterButton
            // 
            this.RemoveParameterButton.Location = new System.Drawing.Point(83, 178);
            this.RemoveParameterButton.Name = "RemoveParameterButton";
            this.RemoveParameterButton.Size = new System.Drawing.Size(77, 23);
            this.RemoveParameterButton.TabIndex = 2;
            this.RemoveParameterButton.Text = "Remove";
            this.RemoveParameterButton.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 209);
            this.Controls.Add(this.RemoveParameterButton);
            this.Controls.Add(this.AddParameterButton);
            this.Controls.Add(this.materialParameterList);
            this.Name = "Form2";
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox materialParameterList;
        private System.Windows.Forms.Button AddParameterButton;
        private System.Windows.Forms.Button RemoveParameterButton;
    }
}