using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighterjetshooting
{
    class Enemy
    {
        private int enemyHealth;
        private int enemySpeed;

        public Enemy()
        {
            enemySpeed = 6;
        }

        public Enemy(int health, int speed)
        {
            enemyHealth = health;
            enemySpeed = speed;
        }

        public int EnemySpeed
        {
            get { return enemySpeed; }
            set { enemySpeed = value; }
        }
    }
}
