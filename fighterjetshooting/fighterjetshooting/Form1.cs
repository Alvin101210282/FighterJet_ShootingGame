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
        PowerUp powerup1 = new PowerUp("atom");
        PowerUp powerup2 = new PowerUp("heal");
        PowerUp powerup3 = new PowerUp("freeze");
        PowerUp powerup4 = new PowerUp("shield");

        //buff
        bool atom_active = false;
        bool freeze_active = false;
        bool shield_active = false;

        //temp recorder:
        int temp_atom;
        int temp_shield;
        int temp_freeze;
        int freeze_time = 0;

        int temp_speed1;
        int temp_speed2;
        int temp_speed3;

        System.Windows.Forms.PictureBox[] powerUps = new System.Windows.Forms.PictureBox[4];
        System.Windows.Forms.PictureBox[] powerUps_icon = new System.Windows.Forms.PictureBox[3];
        
        PowerUp[] powerObj = new PowerUp[4];
        System.Windows.Forms.PictureBox[] healthBar = new System.Windows.Forms.PictureBox[3];

        int icon_index = 0;
        int indexVar = 0;
        int time = 0;
        int rnd_plane;
        int rnd_pow;
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

            if (time >= 50)
            {
                time = 0;
                pow_timer.Stop();
                rnd_plane = rnd.Next(0, 3);
                powerUps[rnd_pow].Left = -1000;
                pow_app = false;

            }
            //Freeze events
            if (freeze_time >= 50)
            {
                enemy1.EnemySpeed = temp_speed1;
                enemy2.EnemySpeed = temp_speed2;
                enemy3.EnemySpeed = temp_speed3;
                freeze_active = false;
                freeze_timer.Stop();
                freeze_active = false;
                for (int i = 0; i < 3; i++)
                {
                    if (powerUps_icon[i] == freeze_pow)
                    {
                        powerUps_icon[i].Visible = false;
                        powerUps_icon[i] = null;
                    }
                }
                freeze_time = 0;
                if (icon_index - temp_freeze == 1)
                {
                    icon_index -= 1;
                }

            }

            //ENEMY SPEED
            if (Bullet.Bounds.IntersectsWith(enemyOne.Bounds))
            {
                if (pow_app && rnd_plane == 0)
                {
                    pow_timer.Start();
                    powerUps[rnd_pow].Visible = true;
                    powerUps[rnd_pow].Top = enemyOne.Top - 20;
                    powerUps[rnd_pow].Left = enemyOne.Left;
                    pow_app = false;
                }
                plyr.Score += 1;
                if (plyr.Score % 10 == 0 && plyr.Score != 0)
                {
                    enemy1.EnemySpeed += 1;
                    if (pow_app == false)
                    {
                        rnd_pow = rnd.Next(0, 4);
                        pow_app = true;
                    }
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
                    powerUps[rnd_pow].Top = enemyTwo.Top - 20;
                    powerUps[rnd_pow].Left = enemyTwo.Left;
                    pow_app = false;
                }
                plyr.Score += 1;
                if (plyr.Score % 10 == 0 && plyr.Score != 0)
                {
                    enemy2.EnemySpeed += 1;
                    if (pow_app == false)
                    {
                        rnd_pow = rnd.Next(0, 4);
                        pow_app = true;
                    }
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
                    powerUps[rnd_pow].Top = enemyThree.Top - 20;
                    powerUps[rnd_pow].Left = enemyThree.Left;
                    pow_app = false;
                }
                plyr.Score += 1;
                if (plyr.Score % 10 == 0 && plyr.Score != 0)
                {
                    enemy3.EnemySpeed += 1;
                    if (pow_app == false)
                    {
                        rnd_pow = rnd.Next(0, 4);
                        pow_app = true;
                    }
                }
                enemyThree.Top = -750;
                enemyThree.Left = rnd.Next(20, 600);
                shooting = false;

            }

            //when the bullet shoot on the buff
            if (Bullet.Bounds.IntersectsWith(atom.Bounds) || Bullet.Bounds.IntersectsWith(freeze.Bounds) || Bullet.Bounds.IntersectsWith(shield.Bounds) || Bullet.Bounds.IntersectsWith(heal.Bounds))
            {
                pow_timer.Stop();
                pow_app = false;
                rnd_plane = rnd.Next(0, 3);
                powerUps[rnd_pow].Left = -1000;
                shooting = false;
                if (powerObj[rnd_pow].PowerType == "atom")
                {
                    if (atom_active != true)
                    {
                        atom_active = true;
                        temp_atom = icon_index;
                        powerUps_icon[icon_index] = atom_pow;
                        icon_index++;
                        while (icon_index != 2 && powerUps_icon[icon_index] != null)
                        {
                            icon_index++;
                        }
                    }
                }
                else if (powerObj[rnd_pow].PowerType == "freeze")
                {
                    if (freeze_active != true)
                    {
                        freeze_timer.Start();
                        freeze_active = true;
                        temp_freeze = icon_index;
                        powerUps_icon[icon_index] = freeze_pow;
                        while (icon_index != 2 && powerUps_icon[icon_index] != null)
                        {
                            icon_index++;
                        }
                        temp_speed1 = enemy1.EnemySpeed;
                        temp_speed2 = enemy2.EnemySpeed;
                        temp_speed3 = enemy3.EnemySpeed;

                        enemy1.EnemySpeed = 3;
                        enemy2.EnemySpeed = 3;
                        enemy3.EnemySpeed = 3;
                    }
                }
                else if (powerObj[rnd_pow].PowerType == "shield")
                {
                    if (shield_active != true)
                    {
                        shield_active = true;
                        temp_shield = icon_index;
                        powerUps_icon[icon_index] = shield_pow;
                        icon_index++;
                        while (icon_index != 2 && powerUps_icon[icon_index] != null)
                        {
                            icon_index++;
                        }
                    }
                }
                else if (powerObj[rnd_pow].PowerType == "heal")
                {
                    if (plyr.PlayerHealth < 3)
                    {
                        plyr.Eat(powerObj[rnd_pow]);
                        indexVar -= 1;
                        healthBar[indexVar].Visible = true;
                    }


                }



            }

            //Power up buff icon
            if (powerUps_icon[0] != null)
            {
                powerUps_icon[0].Visible = true;
                powerUps_icon[0].Top = order1.Top;
                powerUps_icon[0].Left = order1.Left;
            }
            if (powerUps_icon[1] != null)
            {
                powerUps_icon[1].Visible = true;
                powerUps_icon[1].Top = order2.Top;
                powerUps_icon[1].Left = order2.Left;
            }
            if (powerUps_icon[2] != null)
            {
                powerUps_icon[2].Visible = true;
                powerUps_icon[2].Top = order3.Top;
                powerUps_icon[2].Left = order3.Left;
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
                if (shield_active)
                {
                    shield_active = false;
                    for (int i = 0; i < 3; i++)
                    {
                        if (powerUps_icon[i] == shield_pow)
                        {
                            powerUps_icon[i].Visible = false;
                            powerUps_icon[i] = null;
                        }
                    }
                    enemyOne.Top = -450;
                    enemyOne.Left = rnd.Next(20, 600);
                    icon_index = temp_shield;
                }
                else
                {
                    plyr.PlayerHealth -= 1;
                    healthBar[indexVar].Visible = false;
                    indexVar += 1;
                    enemyOne.Top = -450;
                    enemyOne.Left = rnd.Next(20, 600);
                }

            }
            else if (enemyTwo.Top > 674)
            {
                if (shield_active)
                {
                    shield_active = false;
                    for (int i = 0; i < 3; i++)
                    {
                        if (powerUps_icon[i] == shield_pow)
                        {
                            powerUps_icon[i].Visible = false;
                            powerUps_icon[i] = null;
                        }
                    }
                    enemyTwo.Top = -650;
                    enemyTwo.Left = rnd.Next(20, 600);
                    icon_index = temp_shield;
                }
                else
                {
                    plyr.PlayerHealth -= 1;
                    healthBar[indexVar].Visible = false;
                    indexVar += 1;
                    enemyTwo.Top = -650;
                    enemyTwo.Left = rnd.Next(20, 600);
                }
            }
            else if (enemyThree.Top > 674)
            {
                if (shield_active)
                {
                    shield_active = false;
                    for (int i = 0; i < 3; i++)
                    {
                        if (powerUps_icon[i] == shield_pow)
                        {
                            powerUps_icon[i].Visible = false;
                            powerUps_icon[i] = null;
                        }
                    }
                    enemyThree.Top = -750;
                    enemyThree.Left = rnd.Next(20, 600);
                    icon_index = temp_shield;
                }
                else
                {
                    plyr.PlayerHealth -= 1;
                    healthBar[indexVar].Visible = false;
                    indexVar += 1;
                    enemyThree.Top = -750;
                    enemyThree.Left = rnd.Next(20, 600);
                }
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
            if (e.KeyCode == Keys.A)
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
                        }
                    }

                    icon_index = temp_atom;
                }
            }
        }

        public void resetGame()
        { 
            gameTimer.Start();
            powerUps[0] = atom;
            powerUps[1] = heal;
            powerUps[2] = freeze;
            powerUps[3] = shield;

            for (int i = 0; i < 4; i++)
            {
                powerUps[i].Left = -1000;
            }

            powerObj[0] = powerup1;
            powerObj[1] = powerup2;
            powerObj[2] = powerup3;
            powerObj[3] = powerup4;


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

            icon_index = 0;
            for(int i = 0;i < 3; i++)
            {
                if (powerUps_icon[i] != null)
                {
                    powerUps_icon[i].Visible = false;
                    powerUps_icon[i] = null;
                }
            }

            atom_active = false;
            freeze_active = false;
            shield_active = false;

            txtScore.Text = plyr.Score.ToString();
        }

        private void return_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void appear_time(object sender, EventArgs e)
        {
            time += 1;
        }

        private void freeze_time_event(object sender, EventArgs e)
        {
            freeze_time += 1;
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
