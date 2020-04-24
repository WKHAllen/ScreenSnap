namespace ScreenSnapUI
{
    partial class MainForm
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
            this.SaveFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveFolderButton = new System.Windows.Forms.Button();
            this.SaveFolderLabel = new System.Windows.Forms.Label();
            this.SaveFolderBox = new System.Windows.Forms.TextBox();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.ClearFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveFolderDialog
            // 
            this.SaveFolderDialog.Description = "Select save folder";
            // 
            // SaveFolderButton
            // 
            this.SaveFolderButton.Location = new System.Drawing.Point(12, 41);
            this.SaveFolderButton.Name = "SaveFolderButton";
            this.SaveFolderButton.Size = new System.Drawing.Size(100, 25);
            this.SaveFolderButton.TabIndex = 0;
            this.SaveFolderButton.Text = "Browse";
            this.SaveFolderButton.UseVisualStyleBackColor = true;
            this.SaveFolderButton.Click += new System.EventHandler(this.SaveFolderButton_Click);
            // 
            // SaveFolderLabel
            // 
            this.SaveFolderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveFolderLabel.AutoSize = true;
            this.SaveFolderLabel.Location = new System.Drawing.Point(12, 16);
            this.SaveFolderLabel.Name = "SaveFolderLabel";
            this.SaveFolderLabel.Size = new System.Drawing.Size(84, 17);
            this.SaveFolderLabel.TabIndex = 1;
            this.SaveFolderLabel.Text = "Save folder:";
            // 
            // SaveFolderBox
            // 
            this.SaveFolderBox.Location = new System.Drawing.Point(118, 13);
            this.SaveFolderBox.Name = "SaveFolderBox";
            this.SaveFolderBox.Size = new System.Drawing.Size(206, 22);
            this.SaveFolderBox.TabIndex = 2;
            this.SaveFolderBox.TextChanged += new System.EventHandler(this.SaveFolderBox_Changed);
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Location = new System.Drawing.Point(118, 41);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(100, 25);
            this.OpenFolderButton.TabIndex = 3;
            this.OpenFolderButton.Text = "Open folder";
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // ClearFolderButton
            // 
            this.ClearFolderButton.Location = new System.Drawing.Point(224, 41);
            this.ClearFolderButton.Name = "ClearFolderButton";
            this.ClearFolderButton.Size = new System.Drawing.Size(100, 25);
            this.ClearFolderButton.TabIndex = 4;
            this.ClearFolderButton.Text = "Clear folder";
            this.ClearFolderButton.UseVisualStyleBackColor = true;
            this.ClearFolderButton.Click += new System.EventHandler(this.ClearFolderButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 78);
            this.Controls.Add(this.ClearFolderButton);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.SaveFolderBox);
            this.Controls.Add(this.SaveFolderLabel);
            this.Controls.Add(this.SaveFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ScreenSnap";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog SaveFolderDialog;
        private System.Windows.Forms.Button SaveFolderButton;
        private System.Windows.Forms.Label SaveFolderLabel;
        private System.Windows.Forms.TextBox SaveFolderBox;
        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.Button ClearFolderButton;
    }
}
