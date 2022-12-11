using System;
using System.Numerics;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer footballPlayer;
        private FootballTeam footballTeam;
        [SetUp]
        public void Setup()
        {
            footballPlayer = new FootballPlayer("Messi", 10, "Forward");
            footballTeam = new FootballTeam("MUFC", 16);
        }

        [Test]
        public void Test_FootballPlayerConstructor()
        {
            Assert.AreEqual("Messi", footballPlayer.Name);
            Assert.AreEqual(10, footballPlayer.PlayerNumber);
            Assert.AreEqual("Forward", footballPlayer.Position);
            Assert.AreEqual(0, footballPlayer.ScoredGoals);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_FootballPlayer_WithInvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() => footballPlayer = new FootballPlayer(name, 10, "Forward"));
        }

        [TestCase(-1)]
        [TestCase(22)]
        [TestCase(23)]
        public void Test_FootballPlayer_WithInvalidNumber(int number)
        {
            Assert.Throws<ArgumentException>(() => footballPlayer = new FootballPlayer("Messi", number, "Forward"));
        }
        [TestCase("Watcher")]
        [TestCase("Winger")]
        [TestCase("Back")]
        public void Test_FootballPlayer_WithInvalidPosition(string position)
        {
            Assert.Throws<ArgumentException>(() => footballPlayer = new FootballPlayer("Messi", 10, position));
        }
        [Test]
        public void Test_ValidPositions()
        {
            footballPlayer = new FootballPlayer("Messi", 10, "Midfielder");
            Assert.AreEqual("Messi", footballPlayer.Name);
            Assert.AreEqual(10, footballPlayer.PlayerNumber);
            Assert.AreEqual("Midfielder", footballPlayer.Position);
            Assert.AreEqual(0, footballPlayer.ScoredGoals);
        }

        [Test]
        public void Test_ValidPositions2()
        {
            footballPlayer = new FootballPlayer("Messi", 10, "Goalkeeper");
            Assert.AreEqual("Messi", footballPlayer.Name);
            Assert.AreEqual(10, footballPlayer.PlayerNumber);
            Assert.AreEqual("Goalkeeper", footballPlayer.Position);
            Assert.AreEqual(0, footballPlayer.ScoredGoals);
        }

        [Test]
        public void Test_FootballPlayer_ScoreGoalsMethod()
        {
            footballPlayer.Score();
            Assert.AreEqual(1, footballPlayer.ScoredGoals);
        }

        [Test]
        public void Test_FootballTeam_Constructor()
        {
            Assert.AreEqual("MUFC", footballTeam.Name);
            Assert.AreEqual(16, footballTeam.Capacity);
            Assert.IsNotNull(footballTeam.Players);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_FootballTeam_WithInvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() => footballTeam = new FootballTeam(name, 20));
        }

        [TestCase(13)]
        [TestCase(14)]
        [TestCase(-1)]
        public void Test_FootballTeam_WithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => footballTeam = new FootballTeam("MUFC", capacity));
        }

        [Test]
        public void Test_FootballTeam_AddMethod_WithFullCapacity()
        {
            for (int i = 1; i <= 16; i++)
            {
                string name = string.Format($"Messi{i}");
                footballTeam.AddNewPlayer(new FootballPlayer(name, 10, "Forward"));
            }

            string expectedMessage = "No more positions available!";
            Assert.AreEqual(expectedMessage, footballTeam.AddNewPlayer(footballPlayer));
        }

        [Test]
        public void Test_FootballTeam_AddPlayer_method_ShouldWorkProperly()
        {
            string expectedMessage = string.Format($"Added player {footballPlayer.Name} in position {footballPlayer.Position} with number {footballPlayer.PlayerNumber}");
            Assert.AreEqual(expectedMessage, footballTeam.AddNewPlayer(footballPlayer));
        }

        [Test]
        public void Test_FootballTeam_PlayerScoreMethod()
        {
            footballTeam.AddNewPlayer(footballPlayer);
            string expectedMessage =
                string.Format($"{footballPlayer.Name} scored and now has {footballPlayer.ScoredGoals + 1} for this season!");
            Assert.AreEqual(expectedMessage, footballTeam.PlayerScore(10));
        }

        [Test]
        public void Test_FootballTeam_PickUpPlayer()
        {
            footballTeam.AddNewPlayer(footballPlayer);
            FootballPlayer expectedPlayer = footballTeam.PickPlayer("Messi");
            Assert.AreSame(expectedPlayer, footballPlayer);
        }

        [Test]
        public void Test_FootballTeam_PickUpPlayerWithNull()
        {
            footballTeam.AddNewPlayer(footballPlayer);
            Assert.AreEqual(null, footballTeam.PickPlayer("Gosho"));
        }
    }
}