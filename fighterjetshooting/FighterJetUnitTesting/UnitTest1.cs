using Microsoft.VisualStudio.TestTools.UnitTesting;
using fighterjetshooting;
using System.IO;
using System;
using System.Linq;

namespace FighterJetUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PlayerInitializationTest()
        {
            Player playertest = new Player();
            Assert.AreEqual(playertest.Score, 0);
            Assert.AreEqual(playertest.PlayerHealth, 3);
            Assert.AreEqual(playertest.PlayerSpeed, 20);
            Assert.AreEqual(playertest.BulletSpeed, 0);
            Assert.AreEqual(playertest.Username, "Player1");
            playertest.Score = 100;
            playertest.Username = "John Wick";
            Assert.AreEqual(playertest.Score, 100);
            Assert.AreEqual(playertest.Username, "John Wick");
        }

        [TestMethod]
        public void EnemyInitializationTest()
        {
            Enemy enemytest = new Enemy(1000, 6, "Rocket", 6);
            Assert.AreEqual(enemytest.EnemyHealth, 1000);
            Assert.AreEqual(enemytest.EnemySpeed, 6);
            Assert.AreEqual(enemytest.BulletType, "Rocket");
            Assert.AreEqual(enemytest.BulletSpeed, 6);
            enemytest.EnemyHealth -= 1000;
            Assert.AreEqual(enemytest.EnemyHealth, 0);
        }

        [TestMethod]
        public void PowerUpTest()
        {
            PowerUp powerup1 = new PowerUp("atom");
            PowerUp powerup2 = new PowerUp("heal");
            PowerUp powerup3 = new PowerUp("freeze");
            PowerUp powerup4 = new PowerUp("shield");
            PowerUp powerup5 = new PowerUp("minion_jet");
            PowerUp powerup6 = new PowerUp("turret");
            Player plyr = new Player();
            plyr.Eat(powerup1);
            Assert.AreEqual(plyr.PowerUps, "atom");
            plyr.Eat(powerup2);
            Assert.AreEqual(plyr.PlayerHealth, 4);
            plyr.Eat(powerup3);
            Assert.AreEqual(plyr.PowerUps, "freeze");
            plyr.Eat(powerup4);
            Assert.AreEqual(plyr.PowerUps, "shield");
            plyr.Eat(powerup5);
            Assert.AreEqual(plyr.PowerUps, "minion_jet");
            plyr.Eat(powerup6);
            Assert.AreEqual(plyr.PowerUps, "turret");
        }

        [TestMethod]
        public void BossFightTest()
        {
            Enemy boss = new Enemy(100, 6, "rocket", 3);
            Player plyr = new Player();
            boss.DeductHealth(boss, plyr);
            Assert.AreEqual(boss.EnemyHealth, 0);
        }

        [TestMethod]
        public void ScoreBoardTest()
        {
            Scoreboard score = new Scoreboard();
            string[] arr = new string[6];
            string[] temp = new string[6];
            score.SetScore(0,100);
            score.SetScore(1, 150);
            score.SetScore(2, 200);
            arr[0] = "Alan";
            arr[1] = Convert.ToString(score.GetScore(0));
            arr[2] = "Alvin";
            arr[3] = Convert.ToString(score.GetScore(1));
            arr[4] = "Jibril";
            arr[5] = Convert.ToString(score.GetScore(2));
            temp = score.BubbleSort(arr);
            Assert.AreEqual(temp[1], "200");

        }
         
    }
}
