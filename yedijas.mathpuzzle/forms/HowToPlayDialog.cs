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
    public partial class HowToPlayDialog : Form
    {
        public HowToPlayDialog()
        {
            InitializeComponent();
            SettingLabel();
        }

        private void SettingLabel()
        {
            LblMain.Text = @"
~ KNOW MATH!
~ Fill in the numbers needed to make the equation correct.
    a * b = c => a x b = c, NOT *
    a % b = c => a mod b = c, NOT %
    a (ln b) = c => a ln b = c
    a (sin b) = c -> a sin b = c; also cos and tan
~ Once done, click button ""Done"".
~ Have that little satisfaction in you.
";
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
