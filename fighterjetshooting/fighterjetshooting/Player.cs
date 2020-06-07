using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighterjetshooting
{
    public class Player
    {
        private int score;
        private int playerHealth;
        private int playerSpeed;
        private int bulletSpeed;
        private string username;

        public Player()
        {
            score = 0;
            playerHealth = 3;
            playerSpeed = 20;
            bulletSpeed = 0;
            username = "Player1";

        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int PlayerHealth
        {
            get { return playerHealth; }
            set { playerHealth = value; }
        }

        public int PlayerSpeed
        {
            get { return playerSpeed; }
            set { playerSpeed = value; }
        }

        public int BulletSpeed
        {
            get { return bulletSpeed; }
            set { bulletSpeed = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public void Eat(PowerUp pow)
        {
            if(pow.PowerType == "heal")
            {
                playerHealth += 1;
            }
        }
    }
}
