using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using yedijas.mathpuzzle.logic;

namespace yedijas.mathpuzzle.main.forms
{
    public partial class MainForm : Form
    {
        private Problem firstprob;
        private Problem secondprob;
        private Problem thirdprob;
        private Difficulty currentDiff;

        public Problem Firstprob { get => firstprob; set => firstprob = value; }
        public Problem Secondprob { get => secondprob; set => secondprob = value; }
        public Problem Thirdprob { get => thirdprob; set => thirdprob = value; }

        public MainForm()
        {
            InitializeComponent();
            Firstprob = new Problem();
            Secondprob = new Problem();
            Thirdprob = new Problem();
            currentDiff = Difficulty.EASY;
            NewGame(currentDiff);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutDialog abt = new AboutDialog())
            {
                abt.ShowDialog();
            }
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HowToPlayDialog htpd = new HowToPlayDialog())
            {
                htpd.ShowDialog();
            }
        }

        private void DisableAllBox()
        {
            TB1.Enabled = false;
            TB2.Enabled = false;
            TB3.Enabled = false;
            TB4.Enabled = false;
            TB5.Enabled = false;
            TB6.Enabled = false;
            TB7.Enabled = false;
            TB8.Enabled = false;
            TB9.Enabled = false;
            TB10.Enabled = false;
            TB11.Enabled = false;
            TB12.Enabled = false;
        }

        private void HideRandomBox()
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            switch (rng.Next(1, 5))
            {
                case 1:
                    TB1.Enabled = true;
                    TB1.Text = "";
                    break;
                case 2:
                    TB2.Enabled = true;
                    TB2.Text = "";
                    break;
                case 3:
                    TB3.Enabled = true;
                    TB3.Text = "";
                    break;
                case 4:
                    TB4.Enabled = true;
                    TB4.Text = "";
                    break;
                default:
                    break;
            }
            switch (rng.Next(5, 9))
            {
                case 5:
                    TB5.Enabled = true;
                    TB5.Text = "";
                    break;
                case 6:
                    TB6.Enabled = true;
                    TB6.Text = "";
                    break;
                case 7:
                    TB7.Enabled = true;
                    TB7.Text = "";
                    break;
                case 8:
                    TB8.Enabled = true;
                    TB8.Text = "";
                    break;
                default:
                    break;
            }
            switch (rng.Next(9, 13))
            {
                case 9:
                    TB9.Enabled = true;
                    TB9.Text = "";
                    break;
                case 10:
                    TB10.Enabled = true;
                    TB10.Text = "";
                    break;
                case 11:
                    TB11.Enabled = true;
                    TB11.Text = "";
                    break;
                case 12:
                    TB12.Enabled = true;
                    TB12.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void NewGame(Difficulty _diff)
        {
            currentDiff = _diff;
            DisableAllBox();
            Firstprob.CreateProblem(_diff);
            Secondprob.CreateProblem(_diff);
            Thirdprob.CreateProblem(_diff);

            TB1.Text = Firstprob.FirstNumber.ToString();
            TB2.Text = Firstprob.Operand;
            TB3.Text = Firstprob.SecondNumber.ToString();
            TB4.Text = Firstprob.Result.ToString();

            TB5.Text = Secondprob.FirstNumber.ToString();
            TB6.Text = Secondprob.Operand;
            TB7.Text = Secondprob.SecondNumber.ToString();
            TB8.Text = Secondprob.Result.ToString();

            TB9.Text = Thirdprob.FirstNumber.ToString();
            TB10.Text = Thirdprob.Operand;
            TB11.Text = Thirdprob.SecondNumber.ToString();
            TB12.Text = Thirdprob.Result.ToString();
            HideRandomBox();
            Console.WriteLine(Firstprob);
            Console.WriteLine(Secondprob);
            Console.WriteLine(Thirdprob);
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(Difficulty.EASY);
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(Difficulty.MEDIUM);
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(Difficulty.HARD);
        }

        private void extremeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(Difficulty.EXTREME);
        }

        private bool CheckProblem()
        {
            return Firstprob.CheckCorrectness(TB1.Text.Trim(), TB2.Text.Trim(), TB3.Text.Trim(), TB4.Text.Trim())

            && Secondprob.CheckCorrectness(TB5.Text.Trim(), TB6.Text.Trim(), TB7.Text.Trim(), TB8.Text.Trim())

            && Thirdprob.CheckCorrectness(TB9.Text.Trim(), TB10.Text.Trim(), TB11.Text.Trim(), TB12.Text.Trim());
        }

        private bool ValidateInput()
        {
            Regex rex = new Regex(@"(mod)|([\+\-x/])|(ln)|(sin)|(cos)|(tan)");
            return double.TryParse(TB1.Text, out _)
            && double.TryParse(TB3.Text, out _)
            && double.TryParse(TB4.Text, out _)
            && double.TryParse(TB5.Text, out _)
            && double.TryParse(TB7.Text, out _)
            && double.TryParse(TB8.Text, out _)
            && double.TryParse(TB9.Text, out _)
            && double.TryParse(TB11.Text, out _)
            && double.TryParse(TB12.Text, out _)
            && rex.Match(TB2.Text).Success
            && rex.Match(TB6.Text).Success
            && rex.Match(TB10.Text).Success;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show(this, "Please only input the numbers and agreed operands. Pelase consult the help page."
                    , "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CheckProblem())
                {
                    if (MessageBox.Show(this, "You are smart!\nWant a new game?", "Congratulations!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        NewGame(currentDiff);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Check on the answers again", "Too Bad!", MessageBoxButtons.OK);
                }
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("a");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                using (HowToPlayDialog htpd = new HowToPlayDialog())
                {
                    htpd.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                NewGame(currentDiff);
            }
        }
    }
}
