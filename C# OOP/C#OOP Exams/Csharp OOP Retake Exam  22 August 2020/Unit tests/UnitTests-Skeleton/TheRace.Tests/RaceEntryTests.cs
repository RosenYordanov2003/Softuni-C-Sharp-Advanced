using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar _unitCar;
        private UnitDriver _unitDriver;
        private RaceEntry _raceEntry;

        [SetUp]
        public void Setup()
        {
            _unitCar = new UnitCar("BMW X6", 400, 10);
            _unitDriver = new UnitDriver("Gosho", _unitCar);
            _raceEntry = new RaceEntry();
        }

        [Test]
        public void Test_UnitCar_Constructor()
        {
            Assert.AreEqual("BMW X6", _unitCar.Model);
            Assert.AreEqual(400, _unitCar.HorsePower);
            Assert.AreEqual(10, _unitCar.CubicCentimeters);
        }

        [Test]
        public void Test_UnitDriverConstructor()
        {
            Assert.AreEqual("Gosho", _unitDriver.Name);
            Assert.AreSame(_unitCar, _unitDriver.Car);
        }

        [Test]
        public void Test_UnitDriverConstructor_WithInvalidName()
        {
            Assert.Throws<ArgumentNullException>(() => _unitDriver = new UnitDriver(null, _unitCar));
        }

        [Test]
        public void Test_RaceEntryConstructor()
        {
            Assert.AreEqual(0, _raceEntry.Counter);
        }

        [Test]
        public void Test_RaceEntry_AddMethod_WithAttempt_ToAddNull_AsADriver()
        {
            Assert.Throws<InvalidOperationException>(() => _raceEntry.AddDriver(null));
        }

        [Test]
        public void Test_RaceEntry_AddMethod_WithAlreadyExistingDriver()
        {
            _raceEntry.AddDriver(_unitDriver);
            Assert.Throws<InvalidOperationException>(() => _raceEntry.AddDriver(_unitDriver));
        }

        [Test]
        public void Test_RaceEntry_AddMethod_ShouldWork()
        {
            string actualResult = _raceEntry.AddDriver(_unitDriver);
            string expectedResult = string.Format("Driver {0} added in race.", _unitDriver.Name);
            Assert.AreEqual(1, _raceEntry.Counter);
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void Test_RaceEntry_CalculateAverageHorsePowerMethod_WithSmaller_DriverMinimumCount()
        {
            _raceEntry.AddDriver(_unitDriver);
            Assert.Throws<InvalidOperationException>(() => _raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void Test_RaceEntry_CalculateAverageHorsePowerMethod_WithSmaller_DriverMinimumCount2()
        {
            Assert.Throws<InvalidOperationException>(() => _raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void Test_RaceEntry_CalculateAverageHorsePowerMethod_ShouldWork()
        {
            _raceEntry.AddDriver(_unitDriver);
            _raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("BMW M5", 500, 20)));
            double expectedAverageHorsePower = 450;
            Assert.AreEqual(expectedAverageHorsePower,_raceEntry.CalculateAverageHorsePower());
        }
    }
}