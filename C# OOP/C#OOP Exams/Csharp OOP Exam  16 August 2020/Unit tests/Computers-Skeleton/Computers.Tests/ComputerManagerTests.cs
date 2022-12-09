using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer _computer;

        private ComputerManager _computerManager;

        [SetUp]
        public void Setup()
        {
            _computer = new Computer("Apple", "Mac", 2000);
            _computerManager = new ComputerManager();
        }

        [Test]
        public void Test_ComputerConstructor()
        {
            Assert.AreEqual("Apple", _computer.Manufacturer);
            Assert.AreEqual("Mac", _computer.Model);
            Assert.AreEqual(2000, _computer.Price);
        }

        [Test]
        public void Test_ComputerManagerConstructor()
        {
            Assert.AreEqual(0, _computerManager.Count);
            Assert.IsNotNull(_computerManager.Computers);
        }

        [Test]
        public void Test_ComputerManager_AddComputerMethod_WithNull()
        {
            Assert.Throws<ArgumentNullException>(() => _computerManager.AddComputer(null));
        }

        [Test]
        public void Test_ComputerManager_AddComputerMethod_WithAlreadyExisting_Computer()
        {
            _computerManager.AddComputer(_computer);
            Assert.Throws<ArgumentException>(() => _computerManager.AddComputer(_computer));
        }

        [Test]
        public void Test_ComputerManager_AddComputerMethod_ShouldWork()
        {
            _computerManager.AddComputer(_computer);
            _computerManager.AddComputer(new Computer("Lenovo", "Legion", 2200));
            Assert.AreEqual(2, _computerManager.Count);
        }

        [Test]
        public void Test_ComputerManager_RemoveMethod_ShouldWork()
        {
            _computerManager.AddComputer(_computer);
            Computer expectedComputer = _computerManager.RemoveComputer("Apple", "Mac");
            Assert.AreSame(expectedComputer, _computer);
            Assert.AreEqual(0, _computerManager.Count);
        }
        [Test]
        public void Test_ComputerManager_RemoveMethod_ShouldReturnNull()
        {
            _computerManager.AddComputer(_computer);
            Assert.Throws<ArgumentException>(() => _computerManager.RemoveComputer("Lenovo", "Legion"));
        }

        [Test]
        public void Test_ComputerManager_GetComputerMethod_ShouldNotWork()
        {
            Assert.Throws<ArgumentNullException>(() => _computerManager.GetComputer(null, "Legion"));
        }
        [Test]
        public void Test_ComputerManager_GetComputerMethod_ShouldNotWork2()
        {
            Assert.Throws<ArgumentNullException>(() => _computerManager.GetComputer("Apple", null));
        }
        [Test]
        public void Test_ComputerManager_GetComputerMethod_ShouldNotWork_WithNoExistingComputer()
        {
            Assert.Throws<ArgumentException>(() => _computerManager.GetComputer("Lenovo", "Legion"));
        }
        [Test]
        public void Test_ComputerManager_GetComputerMethod_ShouldWork()
        {
            _computerManager.AddComputer(_computer);
            Computer expectedComputer = _computerManager.GetComputer("Apple", "Mac");
            Assert.AreSame(expectedComputer, _computer);
        }

        [Test]
        public void Test_ComputerManager_GetComputersByManufacturerMethod_WithNull_AsManufactureParam()
        {
            Assert.Throws<ArgumentNullException>(() => _computerManager.GetComputersByManufacturer(null));
        }
        [Test]
        public void Test_ComputerManager_GetComputersByManufacturerMethod_ShouldReturn_NoEmptyCollection()
        {
            _computerManager.AddComputer(_computer);
            Computer computer1 = new Computer("Apple", "Mac Air", 3000);
            _computerManager.AddComputer(computer1);
            Computer computer2 = new Computer("Apple", "Mac Air M1", 3000);
            _computerManager.AddComputer(computer2);
            List<Computer> expectedCollection = new List<Computer>()
            {
                _computer,
                computer1,
                computer2
            };
            CollectionAssert.AreEqual(expectedCollection, _computerManager.GetComputersByManufacturer("Apple"));
        }

        [Test]
        public void Test_ComputerManager_GetComputersByManufacturerMethod_ShouldReturn_EmptyCollection()
        {
            _computerManager.AddComputer(_computer);
            List<Computer> expectedCollection = new List<Computer>();
            CollectionAssert.AreEqual(expectedCollection, _computerManager.GetComputersByManufacturer("Lenovo"));
        }
    }
}