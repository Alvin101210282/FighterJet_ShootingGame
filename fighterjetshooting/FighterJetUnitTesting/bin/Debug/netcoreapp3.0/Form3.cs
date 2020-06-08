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
    public partial class Form3 : Form
    {
        public static string username;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Enter_Button(object sender, EventArgs e)
        {
            username = UsernameBox.Text;
            this.Hide();
            Form2.Startgame = true;
        }

        
        private void Username_Input(object sender, EventArgs e)
        {
           
        }

        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                username = UsernameBox.Text;
                this.Hide();
                Form2.Startgame = true;
            }
        }
    }
}
