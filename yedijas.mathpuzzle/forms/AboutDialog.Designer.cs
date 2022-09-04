
namespace yedijas.mathpuzzle.main.forms
{
    partial class AboutDialog
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
            this.LabelGitHub = new System.Windows.Forms.LinkLabel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.LblMain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelGitHub
            // 
            this.LabelGitHub.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelGitHub.AutoSize = true;
            this.LabelGitHub.Location = new System.Drawing.Point(165, 92);
            this.LabelGitHub.Name = "LabelGitHub";
            this.LabelGitHub.Size = new System.Drawing.Size(132, 13);
            this.LabelGitHub.TabIndex = 1;
            this.LabelGitHub.TabStop = true;
            this.LabelGitHub.Text = "https://github.com/yedijas";
            this.LabelGitHub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelGitHub_LinkClicked);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(194, 120);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 2;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // LblMain
            // 
            this.LblMain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblMain.AutoSize = true;
            this.LblMain.Location = new System.Drawing.Point(214, 22);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(35, 13);
            this.LblMain.TabIndex = 3;
            this.LblMain.Text = "label1";
            this.LblMain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 156);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.LabelGitHub);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AboutDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LabelGitHub;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label LblMain;
    }
}