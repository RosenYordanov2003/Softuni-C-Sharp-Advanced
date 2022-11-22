using System;
using System.Collections.Generic;
using System.Linq;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void Test_Constructor()
        {
            arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Test_EnrollMethod_WithSameNames_Should_NotWork()
        {
            Warrior warrior = new Warrior("Gosho", 50, 50);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Gosho",60,70));
            });
        }
        [Test]
        public void Test_EnrollMethod_ShouldWork()
        {
            int expectedCount = 2;
            arena.Enroll(new Warrior("Gosho", 50, 50));
            arena.Enroll(new Warrior("Vesko", 50, 60));
            Assert.AreEqual(expectedCount,arena.Count);
        }
        [Test]
        public void Test_EnrollMethod_ShouldWork2()
        {
            arena.Enroll(new Warrior("Gosho", 50, 50));
            arena.Enroll(new Warrior("Vesko", 50, 60));
            List<Warrior> warriorList = new List<Warrior>();
            foreach (Warrior warrior in arena.Warriors)
            {
                warriorList.Add(warrior);
            }
            CollectionAssert.AreEqual(arena.Warriors, warriorList);
        }

        [Test]
        public void Test_FightMethod_ShouldWork()
        {
            arena.Enroll(new Warrior("Gosho",50,50));
            arena.Enroll(new Warrior("Vesko",50,55));
            arena.Fight("Gosho","Vesko");
            int expectedAttackWarriorHp = 0;
            int expectedDefendWarriorHP = 5;
            Warrior attackWarrior = arena.Warriors.First(w => w.Name == "Gosho");
            Warrior defendWarrior = arena.Warriors.First(w => w.Name == "Vesko");
            Assert.AreEqual(expectedAttackWarriorHp,attackWarrior.HP);
            Assert.AreEqual(expectedDefendWarriorHP,defendWarrior.HP);
        }

        [Test]
        public void Test_FightMethod_WithInvalid_Attacker()
        {
            arena.Enroll(new Warrior("Gosho",50,50));
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho","Gosho");
            });
        }
        [Test]
        public void Test_FightMethod_WithInvalid_Defender()
        {
            arena.Enroll(new Warrior("Gosho", 50, 50));
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Gosho", "Pesho");
            });
        }
    }
}
