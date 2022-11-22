using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Vesko", 50, 50);
        }

        [Test]
        public void Test_Valid_Constructor()
        {
            Assert.AreEqual("Vesko", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(50, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_With_InvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 50, 50);
            });
        }

        [TestCase(0)]
        [TestCase(-50)]
        [TestCase(-1)]
        public void Test_WarriorDamage_With_Invalid_Values(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Vesko", damage, 50);
            });
        }

        [TestCase(-1)]
        [TestCase(-20)]
        public void Test_Warrior_With_InvalidHp_Points(int hpPoints)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Vesko", 50, hpPoints);
            });
        }

        [TestCase(29)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(30)]
        public void Test_AttackMethod_With_InvalidHp_Points(int hpPoints)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior = new Warrior("Vesko", 50, hpPoints);
                warrior.Attack(new Warrior("Gosho", 20, 60));
            });
        }

        [TestCase(29)]
        [TestCase(30)]
        [TestCase(0)]
        [TestCase(2)]
        public void Test_AttackMethod_With_InvalidValues_On_EnemyWarrior(int enemyWarriorHp)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(new Warrior("Gosho", 50, enemyWarriorHp));
            });
        }

        [TestCase(51)]
        [TestCase(60)]
        [TestCase(70)]
        public void Test_AttackMethod_With_Lower_Hp_Than_EnemyWarrior_AttackDamage(int enemyWarriorAttackDamage)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(new Warrior("Gosho", enemyWarriorAttackDamage, 90));
            });
        }

        [TestCase(40)]
        [TestCase(20)]
        [TestCase(49)]
        public void AttackMethod_ShouldWork_With_NoOneHasDied(int enemyWarriorAttackDamage)
        {
            Warrior enemyWarrior = new Warrior("Gosho", enemyWarriorAttackDamage, 90);
            int expectedWarrior2Hp = enemyWarrior.HP - warrior.Damage;
            int expectedWarrior1Hp = warrior.HP - enemyWarrior.Damage;
            warrior.Attack(enemyWarrior);

            Assert.AreEqual(expectedWarrior1Hp, warrior.HP);
            Assert.AreEqual(expectedWarrior2Hp, enemyWarrior.HP);
        }
        [TestCase(50)]
        [TestCase(51)]
        [TestCase(100)]
        public void AttackMethod_WithFirstWarrior_HasBeenKilled(int enemyWarriorAttackDamage)
        {
            Warrior enemyWarrior = new Warrior("Gosho", enemyWarriorAttackDamage, 90);
            int expectedEnemyWarriorHp = enemyWarrior.HP - warrior.Damage;
            int expectedFirstWarriorHp = 0;
            enemyWarrior.Attack(warrior);
            Assert.AreEqual(expectedEnemyWarriorHp, enemyWarrior.HP);
            Assert.AreEqual(expectedFirstWarriorHp, warrior.HP);
        }
        [TestCase(50)]
        [TestCase(49)]
        [TestCase(31)]
        public void AttackMethod_WithSecondWarriorHasBeenKilled(int enemyWarriorHp)
        {
            Warrior enemyWarrior = new Warrior("Gosho", 40, enemyWarriorHp);
            int expectedEnemyWarriorHp = 0;
            int expectedFirstWarriorHp = warrior.HP - enemyWarrior.Damage;
            warrior.Attack(enemyWarrior);
            Assert.AreEqual(expectedEnemyWarriorHp, enemyWarrior.HP);
            Assert.AreEqual(expectedFirstWarriorHp, warrior.HP);
        }
    }
}