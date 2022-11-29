using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        private Robot _robot;
        private RobotManager _robotManager;

        [SetUp]
        public void SetUp()
        {
            _robot = new Robot("Gosho", 100);
            _robotManager = new RobotManager(5);
        }
        [Test]
        public void Test_Robot_Constructor()
        {
            Assert.AreEqual("Gosho", this._robot.Name);
            Assert.AreEqual(100, this._robot.Battery);
            Assert.AreEqual(100, this._robot.MaximumBattery);
        }

        [Test]
        public void Test_RobotManager_Constructor()
        {
            Assert.AreEqual(5, _robotManager.Capacity);
            Assert.AreEqual(0, _robotManager.Count);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void Test_Invalid_Capacity(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _robotManager = new RobotManager(value);
            });
        }
        [Test]
        public void Test_AddMethod_With_Existing_Robot()
        {
            _robotManager.Add(_robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                _robotManager.Add(_robot);
            });
        }

        [Test]
        public void Test_Add_Method_With_FullCapacity()
        {
            for (int i = 0; i < 5; i++)
            {
                this._robotManager.Add(new Robot($"Gosho{i}", i + 10));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                _robotManager.Add(new Robot("X22", 200));
            });
        }

        [Test]
        public void Test_Add_Method_Should_Work()
        {
            for (int i = 0; i < 5; i++)
            {
                this._robotManager.Add(new Robot($"Gosho{i}", i + 10));
            }
            Assert.AreEqual(5, _robotManager.Count);
        }

        [Test]
        public void Test_Remove_Method_With_No_Existing_Robot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _robotManager.Remove("Pesho123");
            });
        }

        [Test]
        public void Test_Remove_Method_Should_Work()
        {
            _robotManager.Add(_robot);
            _robotManager.Remove("Gosho");
            Assert.AreEqual(0, _robotManager.Count);
        }
        [Test]
        public void Test_Work_Method_With_No_Existing_Robot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _robotManager.Work("Pesho123", "Cook", 27);
            });
        }
        [TestCase(120)]
        [TestCase(101)]
        [TestCase(999)]
        [TestCase(int.MaxValue)]
        public void Test_Work_Method_With_Lower_Battery(int batteryUsage)
        {
            _robotManager.Add(_robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                _robotManager.Work("Gosho", "Cook", batteryUsage);
            });
        }
        [Test]
        public void Test_Work_Method_Should_Work()
        {
            _robotManager.Add(_robot);
            _robotManager.Work("Gosho", "Cook", 98);
            Assert.AreEqual(2,_robot.Battery);
        }

        [Test]
        public void Test_Charge_Method_With_No_Existing_RobotName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _robotManager.Charge("Pesho");
            });
        }

        [Test]
        public void Test_Charge_Method_Should_Work()
        {
            _robotManager.Add(_robot);
            _robotManager.Work("Gosho", "Cook", 98);
            _robotManager.Charge("Gosho");
            Assert.AreEqual(_robot.MaximumBattery,_robot.Battery);
        }
    }
}
