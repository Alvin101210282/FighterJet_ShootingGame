using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fighterjetshooting
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        bool goLeft, goRight, shooting, isGameOver;
        Player plyr = new Player();
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();
        Enemy enemy3 = new Enemy();
        PowerUp powerup1 = new PowerUp("atom");
        PowerUp powerup2 = new PowerUp("heal");
        PowerUp powerup3 = new PowerUp("freeze");
        PowerUp powerup4 = new PowerUp("shield");

        bool atom_active = false;
        System.Windows.Forms.PictureBox[] powerUps = new System.Windows.Forms.PictureBox[4];
        System.Windows.Forms.PictureBox[] powerUps_icon = new System.Windows.Forms.PictureBox[3];
        int icon_index = 0;
        PowerUp[] powerObj = new PowerUp[4]; 
        System.Windows.Forms.PictureBox[] healthBar = new System.Windows.Forms.PictureBox[3];
        int indexVar = 0;
        int time = 0;

        int rnd_plane;
        int rnd_pow = 0;
        Random rnd = new Random();

        bool pow_app = false;
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

            if(plyr.PlayerHealth > 0)
            {
                checkEnemyPlane();
            }
            else
            {
                gameOver();
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
            if(shooting == true)
            {
                plyr.BulletSpeed = 40;
                Bullet.Top -= plyr.BulletSpeed;
            }
            else
            {
                Bullet.Left = -300;
                plyr.BulletSpeed = 0;
            }

            if(Bullet.Top < -30)
            {
                shooting = false;
            }

            //ENEMY SPEED
            if (Bullet.Bounds.IntersectsWith(enemyOne.Bounds))
            {
                if(pow_app && rnd_plane == 0)
                {
                    pow_timer.Start();
                    powerUps[rnd_pow].Visible = true;
                    powerUps[rnd_pow].Top = enemyOne.Top - 10;
                    powerUps[rnd_pow].Left = enemyOne.Left;
                    pow_app = false;
                }
                plyr.Score += 1;
                if (plyr.Score % 10 == 0 && plyr.Score != 0 && pow_app == false)
                {
                    enemy1.EnemySpeed += 1;
                    //rnd_pow = rnd.Next(0, 3);
                    pow_app = true;
                }
                
                enemyOne.Top = -450;
                enemyOne.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if (Bullet.Bounds.IntersectsWith(enemyTwo.Bounds))
            {
                if (pow_app && rnd_plane == 1)
                {
                    pow_timer.Start();
                    powerUps[rnd_pow].Visible = true;
                    powerUps[rnd_pow].Top = enemyTwo.Top - 10;
                    powerUps[rnd_pow].Left = enemyTwo.Left;
                    pow_app = false;
                }
                plyr.Score += 1;
                if (plyr.Score % 10 == 0 && plyr.Score != 0 && pow_app == false)
                {
                    enemy2.EnemySpeed += 1;
                    //rnd_pow = rnd.Next(0, 3);
                    pow_app = true;
                }
                enemyTwo.Top = -650;
                enemyTwo.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if (Bullet.Bounds.IntersectsWith(enemyThree.Bounds))
            {
                if (pow_app && rnd_plane == 2)
                {
                    pow_timer.Start();
                    powerUps[rnd_pow].Visible = true;
                    powerUps[rnd_pow].Top = enemyThree.Top - 10;
                    powerUps[rnd_pow].Left = enemyThree.Left;
                    pow_app = false;
                }
                plyr.Score += 1;
                if (plyr.Score % 10 == 0 && plyr.Score != 0 && pow_app == false)
                {
                    enemy3.EnemySpeed += 1;
                    //rnd_pow = rnd.Next(0, 3);
                    pow_app = true;
                }
                enemyThree.Top = -750;
                enemyThree.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if (time >= 50)
            {
                pow_timer.Stop();
                rnd_plane = rnd.Next(0, 3);
                powerUps[rnd_pow].Left = -1000;
                pow_app = false;
                time = 0;
            }

            if (Bullet.Bounds.IntersectsWith(atom.Bounds))
            {
                pow_timer.Stop();
                pow_app = false;
                rnd_plane = rnd.Next(0, 3);
                powerUps[rnd_pow].Left = -1000;
                shooting = false;
                plyr.Eat(powerup1);
                if(powerup1.PowerType == "atom")
                {
                    if(atom_active != true)
                    {
                        atom_active = true;
                        powerUps_icon[icon_index] = atom_pow;
                        icon_index++;
                    }
                }

            }

            //Power up buff icon
            if (icon_index == 1)
            {
                powerUps_icon[0].Visible = true;
                powerUps_icon[0].Top = order1.Top;
                powerUps_icon[0].Left = order1.Left;
                if (icon_index == 2)
                {
                    powerUps_icon[1].Visible = true;
                    powerUps_icon[1].Top = order2.Top;
                    powerUps_icon[1].Left = order2.Left;
                }
                if (icon_index == 3)
                {
                    powerUps_icon[2].Visible = true;
                    powerUps_icon[2].Top = order3.Top;
                    powerUps_icon[2].Left = order3.Left;
                }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            if(e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = true;
                Bullet.Top = player.Top + 30;
                Bullet.Left = player.Left + (player.Width / 2);
            }
            if(e.KeyCode == Keys.A && isGameOver == false)
            {
                if (atom_active)
                {
                    if (enemyOne.Top >= 0)
                    {
                        plyr.Score += 1;
                        enemyOne.Left = rnd.Next(20, 543);
                        enemyOne.Top = rnd.Next(0, 200) * -1;
                    }

                    if (enemyTwo.Top >= 0)
                    {
                        plyr.Score += 1;
                        enemyTwo.Left = rnd.Next(20, 543);
                        enemyTwo.Top = rnd.Next(0, 200) * -1;
                    }

                    if (enemyThree.Top >= 0)
                    {
                        plyr.Score += 1;
                        enemyThree.Left = rnd.Next(20, 543);
                        enemyThree.Top = rnd.Next(0, 200) * -1;
                    }

                    atom_active = false;
                    for (int i = 0; i < 3; i++)
                    {
                        if (powerUps_icon[i] == atom_pow)
                        {
                            powerUps_icon[i].Visible = false;
                            powerUps_icon[i] = null;
                            icon_index = 0;
                        }
                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void appear_time(object sender, EventArgs e)
        {
            time += 1;
        }

        private void powerUp_Click(object sender, EventArgs e)
        {
            
        }

        private void resetGame()
        {
            gameTimer.Start();
            powerUps[0] = atom;
            powerUps[1] = heal;
            powerUps[2] = freeze;
            powerUps[3] = shield;

            powerObj[0] = powerup1;
            powerObj[1] = powerup2;
            powerObj[2] = powerup3;
            powerObj[3] = powerup4;
            enemyOne.Left = rnd.Next(20, 543);
            enemyTwo.Left = rnd.Next(20, 543);
            enemyThree.Left = rnd.Next(20, 543);

            enemyOne.Top = rnd.Next(0, 200) * -1;
            enemyTwo.Top = rnd.Next(0, 500) * -1;
            enemyThree.Top = rnd.Next(0, 900) * -1;

            plyr.Score = 0;
            plyr.BulletSpeed = 0;
            Bullet.Left = -300;

            healthBar[0] = Heart1;
            healthBar[1] = Heart2;
            healthBar[2] = Heart3;

            txtScore.Text = plyr.Score.ToString();
        }

        public void reset()
        {
           
        }

        //GAME OVER 
        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            GameOverText.Visible = true;
        }
    }
}
