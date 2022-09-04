using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yedijas.mathpuzzle.main.forms
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            SettingLabel();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SettingLabel()
        {
            LblMain.Text = @"Made with curiousity.
© Aditya Situmeang 2022";
            LblMain.Left = (this.ClientSize.Width - LblMain.Width) / 2;
        }

        private void LabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(LabelGitHub.Text);

        }
    }
}
