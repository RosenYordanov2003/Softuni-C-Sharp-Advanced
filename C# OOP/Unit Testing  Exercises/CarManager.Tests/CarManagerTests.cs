namespace CarManager.Tests
{
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using System;
    

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("Bmw", "X6", 4.5, 100.1);
        }

        [TestCase("Bmw", "X6", 4.5, 100.1)]

        public void Test_Valid_Constructor(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("BMW")]
        [TestCase("Mercedes")]
        [TestCase("Audi")]
        public void Test_Valid_MakeProperty(string value)
        {
            car = new Car(value, "X6", 4.5, 100.1);
            Assert.AreEqual(value,car.Make);
        }

        [Test]
        [TestCase("X6")]
        [TestCase("X5")]
        [TestCase("X4")]
        [TestCase("M5")]
        [TestCase("X1")]
        public void Test_Valid_ModelProperty(string model)
        {
            car = new Car("Bmw", model, 4.5, 100.1);
            Assert.AreEqual(model, car.Model);
        }
        [Test]
        [TestCase(10.25)]
        [TestCase(5.5)]
        [TestCase(5.9)]
        public void Test_Valid_FuelConsumption(double fuel)
        {
            car = new Car("Bmw", "X6", fuel, 100.1);
            Assert.AreEqual(fuel, car.FuelConsumption);
        }
        [Test]
        [TestCase(100.1)]
        [TestCase(50)]
        [TestCase(61.22)]
        public void Test_Valid_Capacity(double capacity)
        {
            car = new Car("Bmw", "X6", 4.5, capacity);
            Assert.AreEqual(capacity, car.FuelCapacity);
        }


        [TestCase(null)]
        [TestCase("")]
        public void Invalid_Make_With_EmptyString_Property(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, "X6", 4.5, 100.1);
            }, "Make cannot be null or empty!");
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Invalid_Model_Property(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Bmw", model, 4.5, 100.1);
            }, "Model cannot be null or empty!");
        }

        [TestCase("Bmw", "X6", -4.5, 100.1)]
        [TestCase("Bmw", "X6", 0, 100.1)]
        public void Invalid_FuelConsumption_Property(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }
        [TestCase("Bmw", "X6", 4.5, -100.1)]
        [TestCase("Bmw", "X6", 4.5, 0)]
        public void Invalid_FuelCapacity_Property(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase(-22)]
        [TestCase(double.MinValue)]
        [TestCase(0)]
        public void Refuel_With_Negative_Fuel(double value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(value);
            });
        }


        [TestCase(25.2)]
        [TestCase(45.67)]
        [TestCase(1)]
        public void Refuel_With_ValidFuel(double value)
        {

            car.Refuel(value);
            Assert.AreEqual(value, car.FuelAmount);
        }
        [TestCase(200)]
        [TestCase(100.2)]
        public void RefuelCar_With_Fuel_Bigger_ThanCapacity(double value)
        {
            car.Refuel(value);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }


        [Test]
        public void DriveMethod_ShouldWork()
        {
            car.Refuel(60);
            car.Drive(35);
            Assert.AreEqual(58.425, car.FuelAmount);
        }
        [Test]
        public void DriveMethod_ShouldWork_WithEqual_FuelAmount_AndDistance()
        {
            car.Refuel(50.625);
            car.Drive(1125);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void DriveMethod_ShouldNotWork()
        {
            car.Refuel(50.625);
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(1127);
            });
        }
    }
}