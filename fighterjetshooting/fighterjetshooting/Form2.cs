using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fighterjetshooting
{
    public partial class Form2 : Form
    {
        public static bool Startgame = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Main_menu(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Play(object sender, EventArgs e)
        {
            this.Hide();
            Startgame = true;
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
