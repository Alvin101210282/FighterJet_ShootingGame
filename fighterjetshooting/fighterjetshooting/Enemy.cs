using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighterjetshooting
{
    public class Enemy
    {
        private int enemyHealth;
        private int bulletSpeed;
        private string bulletType;
        private int enemySpeed;

        public Enemy()
        {
            enemySpeed = 6;
        }

        public Enemy(int health, int enemyspeed, string bullettype, int bulletspeed)
        {
            enemyHealth = health;
            enemySpeed = enemyspeed;
            bulletType = bullettype;
            BulletSpeed = bulletspeed;

        }

        public int EnemySpeed
        {
            get { return enemySpeed; }
            set { enemySpeed = value; }
        }

        public int EnemyHealth
        {
            get { return enemyHealth; }
            set { enemyHealth = value; }
        }

        public int BulletSpeed
        {
            get { return bulletSpeed; }
            set { bulletSpeed = value; }
        }

        public string BulletType
        {
            get { return bulletType; }
            set { bulletType = value; }
        }

        public int DeductHealth(Enemy enemy, Player player)
        {
            while (enemy.EnemyHealth != 0)
            {
                enemy.EnemyHealth -= player.Attack;
            }
            return enemy.EnemyHealth;
        }
    }
}
