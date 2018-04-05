using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCArcade.VCBreakout;
using VCArcade.VCDice;
using VCArcade.VCTicTacToe;

namespace VCArcade
{
    public partial class frmHub : Form
    {
        public frmHub()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (Application.OpenForms.Count == 1)
                Application.Exit();
            else
                Application.Exit();
        }
        private void DiceButton_Click(object sender, EventArgs e)
        {
            Hide();
            Form Dice = new frmDice();
            Dice.ShowDialog();
            Dice.Dispose();
        }

        private void TIC_Click(object sender, EventArgs e)
        {
            Hide();
            Form TicTacToe = new frmTicTacToe();
            TicTacToe.ShowDialog();
            TicTacToe.Dispose();
        }

        private void btnLoadBreakout_Click(object sender, EventArgs e)
        {
            Hide();
            Form Breakout = new frmBreakout();
            Breakout.ShowDialog();
            Breakout.Dispose();
        }
    }
}
