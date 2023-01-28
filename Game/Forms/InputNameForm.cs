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
    public partial class InputNameForm : Form
    {
        public InputNameForm()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text != "")
            {
                Level1Form playlvl1 = new Level1Form(Nametxt.Text);
                this.Hide();
                playlvl1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void InputNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm menu = new MenuForm();
            this.Hide();
            menu.ShowDialog();
        }
    }
}
