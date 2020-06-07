using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace fighterjetshooting
{
    public partial class Form1 : Form
    {
        public static string dataPath = Path.Combine(Directory.GetCurrentDirectory(), "userData.txt"); // Directory of data file
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        bool goLeft, goRight, shooting;
        Player plyr = new Player();
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();
        Enemy enemy3 = new Enemy();
        PowerUp powerup1 = new PowerUp("atomicbomb");
        System.Windows.Forms.PictureBox[] healthBar = new System.Windows.Forms.PictureBox[3];
        int indexVar = 0;
        Random rnd = new Random();

        public Form1()
        {
            form2.ShowDialog();
            
            if (Form2.Startgame == true)
            {
                form3.ShowDialog();
                InitializeComponent();
                resetGame();
            }
            else
            {
                this.Close();
            }
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            plyr.Username = Form3.username;
            txtScore.Text = plyr.Score.ToString();

            enemyOne.Top += enemy1.EnemySpeed;
            enemyTwo.Top += enemy2.EnemySpeed;
            enemyThree.Top += enemy3.EnemySpeed;

            if (plyr.PlayerHealth > 0)
            {
                checkEnemyPlane();
            }
            else
            {
                gameOver();
                this.KeyPreview = true;
            }

            //PLAYER MOVEMENT
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= plyr.PlayerSpeed;
            }
            if (goRight == true && player.Left < 543)
            {
                player.Left += plyr.PlayerSpeed;
            }

            //PLAYER SHOOTING
            if (shooting == true)
            {
                plyr.BulletSpeed = 40;
                Bullet.Top -= plyr.BulletSpeed;
            }
            else
            {
                Bullet.Left = -300;
                plyr.BulletSpeed = 0;
            }

            if (Bullet.Top < -30)
            {
                shooting = false;
            }

            //FIX OVERLAP
            if(enemyOne.Bounds.IntersectsWith(enemyTwo.Bounds) || enemyOne.Bounds.IntersectsWith(enemyThree.Bounds))
            {
                enemyOne.Top = -450;
                enemyOne.Left = rnd.Next(20, 600);
            }

            if (enemyTwo.Bounds.IntersectsWith(enemyOne.Bounds) || enemyTwo.Bounds.IntersectsWith(enemyThree.Bounds))
            {
                enemyTwo.Top = -650;
                enemyTwo.Left = rnd.Next(20, 600);
            }

            if (enemyThree.Bounds.IntersectsWith(enemyOne.Bounds) || enemyThree.Bounds.IntersectsWith(enemyTwo.Bounds))
            {
                enemyThree.Top = -750;
                enemyThree.Left = rnd.Next(20, 600);
            }
            //ENEMY SPEED
            if (Bullet.Bounds.IntersectsWith(enemyOne.Bounds))
            {
                plyr.Score += 1;
                if (plyr.Score % 5 == 0 && plyr.Score != 0)
                {
                    enemy1.EnemySpeed += 1;
                }
                enemyOne.Top = -450;
                enemyOne.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if (Bullet.Bounds.IntersectsWith(enemyTwo.Bounds))
            {
                plyr.Score += 1;
                if (plyr.Score % 5 == 0 && plyr.Score != 0)
                {
                    enemy2.EnemySpeed += 1;
                }
                enemyTwo.Top = -650;
                enemyTwo.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if (Bullet.Bounds.IntersectsWith(enemyThree.Bounds))
            {
                plyr.Score += 1;
                if (plyr.Score % 5 == 0 && plyr.Score != 0)
                {
                    enemy3.EnemySpeed += 1;
                }
                enemyThree.Top = -750;
                enemyThree.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if (enemy1.EnemySpeed > 14 && enemy2.EnemySpeed > 14 && enemy3.EnemySpeed > 14)
            {
                enemy1.EnemySpeed = 14;
                enemy2.EnemySpeed = 14;
                enemy3.EnemySpeed = 14;
            }
        }

        //HEALTH BAR IMPLEMENTATION
        private void checkEnemyPlane()
        {
            if (enemyOne.Top > 674)
            {
                plyr.PlayerHealth -= 1;
                healthBar[indexVar].Visible = false;
                indexVar += 1;
                enemyOne.Top = -450;
                enemyOne.Left = rnd.Next(20, 600);

            }
            else if (enemyTwo.Top > 674)
            {
                plyr.PlayerHealth -= 1;
                healthBar[indexVar].Visible = false;
                indexVar += 1;
                enemyTwo.Top = -650;
                enemyTwo.Left = rnd.Next(20, 600);
            }
            else if (enemyThree.Top > 674)
            {
                plyr.PlayerHealth -= 1;
                healthBar[indexVar].Visible = false;
                indexVar += 1;
                enemyThree.Top = -750;
                enemyThree.Left = rnd.Next(20, 600);
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void enemyOne_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void txtScore_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Replay_button(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            return_menu.Visible = false;
            GameOverText.Visible = false;
            ReplayButton.Visible = false;
            ExitButton.Visible = false;
            resetGame();
        }

        private void Exit_button(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if(e.KeyCode == Keys.Z && shooting == false)
            {
                shooting = true;
                Bullet.Top = player.Top + 30;
                Bullet.Left = player.Left + (player.Width / 2);
            }
        }

        public void resetGame()
        { 
            gameTimer.Start();
            enemy1.EnemySpeed = 6;
            enemy2.EnemySpeed = 6;
            enemy3.EnemySpeed = 6;
            enemyOne.Left = rnd.Next(20, 543);
            enemyTwo.Left = rnd.Next(20, 543);
            enemyThree.Left = rnd.Next(20, 543);

            enemyOne.Top = rnd.Next(0, 200) * -1;
            enemyTwo.Top = rnd.Next(0, 500) * -1;
            enemyThree.Top = rnd.Next(0, 900) * -1;

            plyr.Score = 0;
            plyr.PlayerHealth = 3;
            plyr.BulletSpeed = 0;
            Bullet.Left = -300;

            indexVar = 0;
            healthBar[0] = Heart1;
            healthBar[1] = Heart2;
            healthBar[2] = Heart3;

            for (int i =0;i<3;i++)
            {
                healthBar[i].Visible = true;
            }

            txtScore.Text = plyr.Score.ToString();
        }

        private void return_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        //GAME OVER 
        private void gameOver()
        {
            gameTimer.Stop();
            return_menu.Visible = true;
            GameOverText.Visible = true;
            ReplayButton.Visible = true;
            ExitButton.Visible = true;
            CollectScore();
        }

        private void CollectScore()
        {
            if (File.Exists(dataPath))
            {
                StreamWriter score = File.AppendText(dataPath);
                score.WriteLine(plyr.Username);
                score.WriteLine(plyr.Score);
                score.Close();
            }
            else
            {
                StreamWriter score = File.CreateText(dataPath);
                score.WriteLine(plyr.Username);
                score.WriteLine(plyr.Score);
                score.Close();
            }
        }

    }
}
