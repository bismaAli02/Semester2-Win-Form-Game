using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Forms
{
    public partial class ViewScoreForm : Form
    {
        public ViewScoreForm()
        {
            InitializeComponent();
        }

        private void ViewScoreForm_Load(object sender, EventArgs e)
        {
            ViewScoreGV.DataSource = PlayerDL.Players;
            ViewScoreGV.Refresh();
        }

        private void MenuBtn_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            this.Hide();
            menu.ShowDialog();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ViewScoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
