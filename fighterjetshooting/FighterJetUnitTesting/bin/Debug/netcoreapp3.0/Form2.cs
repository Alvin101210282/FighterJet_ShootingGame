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
        int keyvalue = 0;

        public Form2()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Startgame = false;
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Main_menu(object sender, EventArgs e)
        {   
            if (keyvalue == 0)
            {
                Play_button.BackColor = System.Drawing.Color.ForestGreen;
                Exit_button.BackColor = System.Drawing.Color.Black;
                scoredisplay.BackColor = System.Drawing.Color.Black;
                howToPlay_button.BackColor = System.Drawing.Color.Black;
            }
            else if(keyvalue == 1)
            {
                Play_button.BackColor = System.Drawing.Color.Black;
                Exit_button.BackColor = System.Drawing.Color.Black;
                scoredisplay.BackColor = System.Drawing.Color.Black;
                howToPlay_button.BackColor = System.Drawing.Color.ForestGreen;
            }
            else if (keyvalue == 2)
            {
                Play_button.BackColor = System.Drawing.Color.Black;
                Exit_button.BackColor = System.Drawing.Color.Black;
                scoredisplay.BackColor = System.Drawing.Color.ForestGreen;
                howToPlay_button.BackColor = System.Drawing.Color.Black;
            }
            else if (keyvalue == 3)
            {
                Play_button.BackColor = System.Drawing.Color.Black;
                Exit_button.BackColor = System.Drawing.Color.ForestGreen;
                scoredisplay.BackColor = System.Drawing.Color.Black;
                howToPlay_button.BackColor = System.Drawing.Color.Black;
            }


        }

        private void Play(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            Startgame = true;
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PlayButton(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                if (keyvalue == 0)
                {
                    keyvalue = 3;
                }
                else
                {
                    keyvalue -= 1;
                }
            }
            else if(e.KeyCode == Keys.Down)
            {
                if (keyvalue == 3)
                {
                    keyvalue = 0;
                }
                else
                {
                    keyvalue += 1;
                }
            }
        }

        private void ScoreBoard(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void howtoplayButton(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
