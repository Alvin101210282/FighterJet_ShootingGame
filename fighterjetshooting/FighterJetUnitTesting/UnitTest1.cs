using Microsoft.VisualStudio.TestTools.UnitTesting;
using fighterjetshooting;

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

      
    }
}
