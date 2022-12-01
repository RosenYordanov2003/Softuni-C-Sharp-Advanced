using System.Collections.Generic;
using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private Fish _fish;
        private Aquarium _aquarium;

        [SetUp]
        public void SetUp()
        {
            _fish = new Fish("Gosho");
            _aquarium = new Aquarium("Aquarium", 10);
        }

        [Test]
        public void Test_Fish_Constructor()
        {
            Assert.AreEqual("Gosho", _fish.Name);
            Assert.IsTrue(_fish.Available);
        }

        [Test]
        public void Test_AquariumConstructor()
        {
            Assert.AreEqual("Aquarium", _aquarium.Name);
            Assert.AreEqual(10, _aquarium.Capacity);
            Assert.AreEqual(0, _aquarium.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_Aquarium_With_Invalid_Name(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _aquarium = new Aquarium(name, 2);
            });
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-99)]
        [TestCase(int.MinValue)]
        public void Test_Aquarium_WithInvalid_Capacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _aquarium = new Aquarium("Name", capacity);
            });
        }

        [Test]
        public void Test_Aquarium_AddMethod_With_Full_Capacity()
        {
            for (int i = 1; i <= 10; i++)
            {
                _aquarium.Add(new Fish(string.Format($"Fish{i}")));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                _aquarium.Add(_fish);
            });
        }
        [Test]
        public void Test_Aquarium_AddMethod_Should_Work()
        {
            for (int i = 1; i <= 10; i++)
            {
                _aquarium.Add(new Fish(string.Format($"Fish{i}")));
            }
            Assert.AreEqual(10, _aquarium.Count);
        }

        [Test]
        public void Test_Aquarium_RemoveMethod_With_NoExistingFish()
        {
            _aquarium.Add(new Fish("Vasil"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                _aquarium.RemoveFish("Pesho");
            });
        }
        [Test]
        public void Test_Aquarium_RemoveMethod_ShouldWork()
        {
            for (int i = 1; i <= 10; i++)
            {
                _aquarium.Add(new Fish(string.Format($"Fish{i}")));
            }

            for (int i = 1; i <= 4; i++)
            {
                _aquarium.RemoveFish(string.Format($"Fish{i}"));
            }
            Assert.AreEqual(6, _aquarium.Count);
        }

        [Test]
        public void Test_Sell_AquariumMethod_With_NoExistingFish()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _aquarium.SellFish("Nemo");
            });
        }
        [Test]
        public void Test_Sell_AquariumMethod()
        {
            _aquarium.Add(_fish);
            _aquarium.SellFish("Gosho");
            Assert.IsFalse(_fish.Available);
            Assert.AreSame(_fish,_aquarium.SellFish("Gosho"));
        }

        [Test]
        public void Test_Aquarium_ReportMethod()
        {
            List<string> fishNameList = new List<string>();
            for (int i = 1; i <= 5; i++)
            {
                _aquarium.Add(new Fish(string.Format($"Fish{i}")));
                fishNameList.Add($"Fish{i}");
            }
            string expectedResult = string.Format($"Fish available at {_aquarium.Name}: {string.Join(", ",fishNameList)}");
            Assert.AreEqual(expectedResult,_aquarium.Report());
        }
    }
}
