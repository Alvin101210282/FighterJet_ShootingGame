﻿using System;
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
    public partial class Form1 : Form
    {

        bool goLeft, goRight, shooting, isGameOver;
        int score;
        int playerSpeed = 12;
        int enemySpeed;
        int bulletSpeed;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = score.ToString();

            enemyOne.Top += enemySpeed;
            enemyTwo.Top += enemySpeed;
            enemyThree.Top += enemySpeed;

            if(enemyOne.Top > 674 || enemyTwo.Top > 674 || enemyThree.Top > 674)
            {
                gameOver();
            }
            //Player Movement
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true && player.Left < 543)
            {
                player.Left += playerSpeed;
            }

            if(shooting == true)
            {
                bulletSpeed = 20;
                Bullet.Top -= bulletSpeed;
            }
            else
            {
                Bullet.Left = -300;
                bulletSpeed = 0;
            }

            if(Bullet.Top < -30)
            {
                shooting = false;
            }

            if (Bullet.Bounds.IntersectsWith(enemyOne.Bounds))
            {
                score += 1;
                enemyOne.Top = -450;
                enemyOne.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if (Bullet.Bounds.IntersectsWith(enemyTwo.Bounds))
            {
                score += 1;
                enemyTwo.Top = -650;
                enemyTwo.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if (Bullet.Bounds.IntersectsWith(enemyThree.Bounds))
            {
                score += 1;
                enemyThree.Top = -750;
                enemyThree.Left = rnd.Next(20, 600);
                shooting = false;

            }

            if(score == 5)
            {
                enemySpeed = 10;
            }
            if(score == 10)
            {
                enemySpeed = 15;
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
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {

            }
        }

        private void resetGame()
        {
            gameTimer.Start();
            enemySpeed = 6;

            enemyOne.Left = rnd.Next(20, 543);
            enemyTwo.Left = rnd.Next(20, 543);
            enemyThree.Left = rnd.Next(20, 543);

            enemyOne.Top = rnd.Next(0, 200) * -1;
            enemyTwo.Top = rnd.Next(0, 500) * -1;
            enemyThree.Top = rnd.Next(0, 900) * -1;

            score = 0;
            bulletSpeed = 0;
            Bullet.Left = -300;

            txtScore.Text = score.ToString();
        }

        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text += Environment.NewLine + "Game Over!!" + Environment.NewLine + "Press Enter to try again.";
        }
    }
}