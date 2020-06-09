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
        PowerUp powerup5 = new PowerUp("minion_jet");
        PowerUp powerup6 = new PowerUp("turret");
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

        //minion jet
        int minion_tgscore = 100;
        bool minion_jet_event = false;

        //Boss Fight
        int boss_tgscore = 120;
        Enemy Boss = new Enemy(100, 0, "rocket", 5);
        int rocket_time = 0;
        bool boss_shooting = false;
        bool boss_app = false;
        //Turret
        int turret_tgscore = 110;
        bool turrent_event = false;
        int turret_bullet_time = 0;
        bool turret_shooting;

        //Atomic Bomb Explosion
        int ex_time = 0;

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
                if(Boss.EnemyHealth == 0)
                {
                    gameOver();
                    this.KeyPreview = true;
                }
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
                minionjet1.Left -= plyr.PlayerSpeed;
                minionjet2.Left -= plyr.PlayerSpeed;
            }
            if (goRight == true && player.Left < 543)
            {
                player.Left += plyr.PlayerSpeed;
                minionjet1.Left += plyr.PlayerSpeed;
                minionjet2.Left += plyr.PlayerSpeed;
            }

            //PLAYER SHOOTING
            if (shooting == true)
            {
                plyr.BulletSpeed = 40;
                Bullet.Top -= plyr.BulletSpeed;
                Bullet2.Top -= plyr.BulletSpeed;
                Bullet3.Top -= plyr.BulletSpeed;
            }
            else
            {
                Bullet.Left = -300;
                Bullet2.Left = -300;
                Bullet3.Left = -300;
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
                pow_timer.Stop();
                rnd_plane = rnd.Next(0, 3);
                powerUps[rnd_pow].Left = -1000;
                pow_app = false;
                time = 0;

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

            //Explosion
            if(ex_time >= 5)
            {
                explode1.Visible = false;
                explode2.Visible = false;
                explode3.Visible = false;
                ex_time = 0;
                explosion_timer.Stop();
            }
            //Boss Shooting
            if(rocket_time >= 50)
            {
                boss_shooting = true;
                rocket1.Top = rocket_order1.Top;
                rocket1.Left = rocket_order1.Left;

                rocket2.Top = rocket_order2.Top;
                rocket2.Left = rocket_order2.Left;

                rocket3.Top = rocket_order3.Top;
                rocket3.Left = rocket_order3.Left;

                rocket4.Top = rocket_order4.Top;
                rocket4.Left = rocket_order4.Left;

                rocket_time = 0;
                rocket_timer.Stop();

            }

            if (boss_shooting)
            {
                rocket1.Top += Boss.BulletSpeed;
                rocket2.Top += Boss.BulletSpeed;
                rocket3.Top += Boss.BulletSpeed;
                rocket4.Top += Boss.BulletSpeed;
            }

            if(rocket1.Bounds.IntersectsWith(player.Bounds) || rocket2.Bounds.IntersectsWith(player.Bounds) || rocket3.Bounds.IntersectsWith(player.Bounds) || rocket4.Bounds.IntersectsWith(player.Bounds))
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

                rocket1.Left = -300;
                rocket2.Left = -300;
                rocket3.Left = -300;
                rocket4.Left = -300;

                boss_shooting = false;
                rocket_timer.Start();
            }

            if(rocket1.Top > 674 || rocket2.Top > 674 || rocket3.Top > 674 || rocket4.Top > 674)
            {
                boss_shooting = false;
                rocket1.Left = -300;
                rocket2.Left = -300;
                rocket3.Left = -300;
                rocket4.Left = -300;
                rocket_timer.Start();
            }

            if (boss_app)
            {
                if (Boss.EnemyHealth <= 20)
                {
                    health_label2.Visible = false;
                    health_label1.Visible = true;
                }
                else if (Boss.EnemyHealth <= 40)
                {
                    health_label3.Visible = false;
                    health_label2.Visible = true;
                }
                else if (Boss.EnemyHealth <= 60)
                {
                    health_label4.Visible = false;
                    health_label3.Visible = true;
                }
                else if (Boss.EnemyHealth <= 80)
                {
                    health_label5.Visible = false;
                    health_label4.Visible = true;
                }
                else if (Boss.EnemyHealth <= 90)
                {
                    health_label6.Visible = false;
                    health_label5.Visible = true;
                }
            }
            //Turret Events
            if (turret_bullet_time >= 50)
            {
                turret_shooting = true;
                turret_bullet.Top = turret.Top + 30;
                turret_bullet.Left = turret.Left + (turret.Width / 2);
                turret_bullet_time = 0;
                turret_timer.Stop();
            }

            if(turret_shooting)
            {
                turret_bullet.Top -= 40;
            }

            if(turret_bullet.Bounds.IntersectsWith(enemyOne.Bounds))
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
                if (plyr.Score == boss_tgscore)
                {
                    boss1.Left = -14;
                    rocket_timer.Start();
                    boss1.Visible = true;
                    boss_icon.Visible = true;
                    health_label6.Visible = true;
                    boss_app = true;
                }
                else if (plyr.Score == minion_tgscore)
                {
                    enemy1.EnemySpeed += 1;
                    minion_jet_pow.Visible = true;
                    minion_jet_pow.Left = enemyOne.Left;
                    minion_jet_pow.Top = enemyOne.Top - 20;
                }
                else if (plyr.Score % 10 == 0 && plyr.Score != 0)
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

                turret_bullet.Left = -300;
                turret_shooting = false;
                turret_timer.Start();
            }else if(turret_bullet.Bounds.IntersectsWith(enemyTwo.Bounds))
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
                if (plyr.Score == boss_tgscore)
                {
                    enemy2.EnemySpeed += 1;
                    rocket_timer.Start();
                    boss1.Visible = true;
                    boss1.Left = -14;
                    boss_icon.Visible = true;
                    health_label6.Visible = true;
                    boss_app = true;
                }
                else if (plyr.Score == minion_tgscore)
                {
                    minion_jet_pow.Visible = true;
                    minion_jet_pow.Left = enemyTwo.Left - 20;
                    minion_jet_pow.Top = enemyTwo.Top - 20;

                }
                else if (plyr.Score % 10 == 0 && plyr.Score != 0)
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

                turret_bullet.Left = -300;
                turret_shooting = false;
                turret_timer.Start();
            }
            else if(turret_bullet.Bounds.IntersectsWith(enemyThree.Bounds))
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
                if (plyr.Score == boss_tgscore)
                {
                    rocket_timer.Start();
                    boss1.Left = -14;
                    boss1.Visible = true;
                    boss_icon.Visible = true;
                    boss_app = true;
                }
                else if (plyr.Score == minion_tgscore)
                {
                    enemy3.EnemySpeed += 1;
                    minion_jet_pow.Visible = true;
                    minion_jet_pow.Left = enemyThree.Left - 20;
                    minion_jet_pow.Top = enemyThree.Top - 20;
                }
                else if (plyr.Score % 10 == 0 && plyr.Score != 0)
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

                turret_bullet.Left = -300;
                turret_shooting = false;
                turret_timer.Start();
            }

            if(turret_bullet.Top < -30)
            {
                turret_shooting = false;
                turret_bullet.Left = -300;
                turret_timer.Start();
            }
            //ENEMY SPEED
            if (Bullet.Bounds.IntersectsWith(enemyOne.Bounds) || Bullet2.Bounds.IntersectsWith(enemyOne.Bounds) || Bullet3.Bounds.IntersectsWith(enemyOne.Bounds))
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
                if(plyr.Score == turret_tgscore)
                {
                    enemy1.EnemySpeed += 1;
                    turret_pow.Visible = true;
                    turret_pow.Left = enemyOne.Left;
                    turret_pow.Top = enemyOne.Top - 20;

                }
                else if(plyr.Score == boss_tgscore)
                {
                    enemy1.EnemySpeed += 1;
                    rocket_timer.Start();
                    boss1.Visible = true;
                    boss1.Left = -14;
                    boss_icon.Visible = true;
                    health_label6.Visible = true;
                    boss_app = true;
                }
                else if (plyr.Score == minion_tgscore)
                {
                    enemy1.EnemySpeed += 1;
                    minion_jet_pow.Visible = true;
                    minion_jet_pow.Left = enemyOne.Left;
                    minion_jet_pow.Top = enemyOne.Top - 20;
                }
                else if (plyr.Score % 10 == 0 && plyr.Score != 0)
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

            if (Bullet.Bounds.IntersectsWith(enemyTwo.Bounds) || Bullet2.Bounds.IntersectsWith(enemyTwo.Bounds) || Bullet3.Bounds.IntersectsWith(enemyTwo.Bounds))
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
                if (plyr.Score == turret_tgscore)
                {
                    enemy2.EnemySpeed += 1;
                    turret_pow.Visible = true;
                    turret_pow.Left = enemyTwo.Left;
                    turret_pow.Top = enemyTwo.Top - 20;

                }
                else if (plyr.Score == boss_tgscore)
                {
                    rocket_timer.Start();
                    boss1.Visible = true;
                    boss1.Left = -14;
                    boss_icon.Visible = true;
                    health_label6.Visible = true;
                    boss_app = true;
                }
                else if (plyr.Score == minion_tgscore)
                {
                    enemy2.EnemySpeed += 1;
                    minion_jet_pow.Visible = true;
                    minion_jet_pow.Left = enemyTwo.Left - 20;
                    minion_jet_pow.Top = enemyTwo.Top - 20;

                }
                else if (plyr.Score % 10 == 0 && plyr.Score != 0)
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

            if (Bullet.Bounds.IntersectsWith(enemyThree.Bounds) || Bullet2.Bounds.IntersectsWith(enemyThree.Bounds) || Bullet3.Bounds.IntersectsWith(enemyThree.Bounds))
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
                if (plyr.Score == turret_tgscore)
                {
                    enemy3.EnemySpeed += 1;
                    turret_pow.Visible = true;
                    turret_pow.Left = enemyThree.Left;
                    turret_pow.Top = enemyThree.Top - 20;

                }
                else if (plyr.Score == boss_tgscore)
                {
                    rocket_timer.Start();
                    boss1.Visible = true;
                    boss1.Left = -14;
                    boss_icon.Visible = true;
                    health_label6.Visible = true;
                    boss_app = true;
                }
                else if (plyr.Score == minion_tgscore)
                {
                    enemy3.EnemySpeed += 1;
                    minion_jet_pow.Visible = true;
                    minion_jet_pow.Left = enemyThree.Left - 20;
                    minion_jet_pow.Top = enemyThree.Top - 20;
                }
                else if (plyr.Score % 10 == 0 && plyr.Score != 0)
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
            //Fight Boss
            if (Bullet.Bounds.IntersectsWith(boss1.Bounds) || Bullet2.Bounds.IntersectsWith(boss1.Bounds) || Bullet3.Bounds.IntersectsWith(boss1.Bounds))
            {
                Boss.EnemyHealth -= 1;

                shooting = false;
            }

            if(turret_bullet.Bounds.IntersectsWith(boss1.Bounds))
            {
                Boss.EnemyHealth -= 1;
                turret_shooting = false;
                turret_bullet.Left = -300;
                turret_timer.Start();
            }
            //when the bullet shoot on the buff
            if (Bullet.Bounds.IntersectsWith(atom.Bounds) || Bullet.Bounds.IntersectsWith(freeze.Bounds) || Bullet.Bounds.IntersectsWith(shield.Bounds) || Bullet.Bounds.IntersectsWith(heal.Bounds) || Bullet2.Bounds.IntersectsWith(atom.Bounds) || Bullet2.Bounds.IntersectsWith(freeze.Bounds) || Bullet2.Bounds.IntersectsWith(shield.Bounds) || Bullet2.Bounds.IntersectsWith(heal.Bounds) || Bullet3.Bounds.IntersectsWith(heal.Bounds) || Bullet3.Bounds.IntersectsWith(atom.Bounds) || Bullet3.Bounds.IntersectsWith(freeze.Bounds) || Bullet3.Bounds.IntersectsWith(shield.Bounds))
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

            if (Bullet.Bounds.IntersectsWith(minion_jet_pow.Bounds))
            {
                minion_jet_event = true;
                minion_jet_pow.Left = -1000;
                minionjet1.Visible = true;
                minionjet1.Left = player.Left - 65;
                minionjet2.Visible = true;
                minionjet2.Left = player.Left + 90;
            }

            if (Bullet.Bounds.IntersectsWith(turret_pow.Bounds) || Bullet2.Bounds.IntersectsWith(turret_pow.Bounds) || Bullet3.Bounds.IntersectsWith(turret_pow.Bounds))
            {
                turrent_event = true;
                turret_pow.Left = -1000;
                turret.Visible = true;
                turret.Left = rnd.Next(0, 543);
                turret_timer.Start();
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

            if(plyr.Score >= 120)
            {
                enemy1.EnemySpeed = 6;
                enemy2.EnemySpeed = 6;
                enemy3.EnemySpeed = 6;
            }
            else if (enemy1.EnemySpeed > 14 && enemy2.EnemySpeed > 14 && enemy3.EnemySpeed > 14)
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
                if (minion_jet_event)
                {
                    Bullet2.Top = minionjet1.Top + 30;
                    Bullet2.Left = minionjet1.Left + (minionjet1.Width / 2);

                    Bullet3.Top = minionjet2.Top + 30;
                    Bullet3.Left = minionjet2.Left + (minionjet2.Width / 2);
                }
            }
            if (e.KeyCode == Keys.A)
            {
                if (atom_active)
                {
                    if (enemyOne.Top >= 0)
                    {
                        plyr.Score += 1;
                        explode1.Visible = true;
                        explode1.Left = enemyOne.Left;
                        explode1.Top = enemyOne.Top;
                        enemyOne.Left = rnd.Next(20, 543);
                        enemyOne.Top = rnd.Next(0, 200) * -1;
                    }

                    if (enemyTwo.Top >= 0)
                    {
                        plyr.Score += 1;
                        explode2.Visible = true;
                        explode2.Left = enemyTwo.Left;
                        explode2.Top = enemyTwo.Top;
                        enemyTwo.Left = rnd.Next(20, 543);
                        enemyTwo.Top = rnd.Next(0, 200) * -1;
                    }

                    if (enemyThree.Top >= 0)
                    {
                        plyr.Score += 1;
                        explode3.Visible = true;
                        explode3.Left = enemyThree.Left;
                        explode3.Top = enemyThree.Top;
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
                    explosion_timer.Start();
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
            Bullet2.Left = -300;
            Bullet3.Left = -300;
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

            pow_app = false;
            minion_jet_event = false;
            minion_jet_pow.Left = -1000;
            minionjet1.Visible = false;
            minionjet2.Visible = false;

            turret_pow.Left = -1000;
            //Boss Initialization
            rocket1.Left = -300;
            rocket2.Left = -300;
            rocket3.Left = -300;
            rocket4.Left = -300;

            //Turret
            turret_bullet.Left = -300;
            turret.Visible = false;
            turret_timer.Stop();
            turret_bullet_time = 0;

            //Boss
            Boss.EnemyHealth = 100;
            boss_icon.Visible = false;
            health_label0.Visible = false;
            health_label1.Visible = false;
            health_label2.Visible = false;
            health_label3.Visible = false;
            health_label4.Visible = false;
            health_label5.Visible = false;
            health_label6.Visible = false;
            boss1.Left = -1000;
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

        private void rocket_timing(object sender, EventArgs e)
        {
            rocket_time += 1;
        }

        private void turret_shooting_timing(object sender, EventArgs e)
        {
            turret_bullet_time += 1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void health_label4_Click(object sender, EventArgs e)
        {

        }

        private void explode_time(object sender, EventArgs e)
        {
            ex_time += 1;
        }

        //GAME OVER 
        private void gameOver()
        {
            health_label1.Visible = false;
            health_label0.Visible = true;
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
