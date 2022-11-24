using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                car = new Car("BMW X6", 2);
                garage = new Garage("Gosho", 4);
            }

            [Test]
            public void Test_Car_Constructor()
            {
                car = new Car("BMW X6", 2);
                string expectedModel = "BMW X6";
                int expectedNumberOfIssuses = 2;
                Assert.AreEqual(expectedModel, car.CarModel);
                Assert.AreEqual(expectedNumberOfIssuses, car.NumberOfIssues);
            }

            [TestCase(2)]
            [TestCase(1)]
            [TestCase(10)]
            public void Test_IsFixed_Property(int numberOfIssues)
            {
                car = new Car("BMW X6", numberOfIssues);
                bool result = car.IsFixed;
                Assert.IsTrue(!result);
            }
            [Test]
            public void Test_IsFixed_Property2()
            {
                car = new Car("BMW", 0);
                bool result = car.IsFixed;
                Assert.IsTrue(result);
            }

            [Test]
            public void Test_Garage_Constructor()
            {
                Assert.AreEqual("Gosho", garage.Name);
                Assert.AreEqual(4, garage.MechanicsAvailable);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Test_Invalid_GarageName(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    garage = new Garage(name, 4);
                });
            }
            [TestCase("Gosho")]
            [TestCase("Vesko")]
            public void Test_Valid_GarageName(string name)
            {
                garage = new Garage(name, 4);
                Assert.AreEqual(name, garage.Name);
            }
            [Test]
            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-2)]
            public void Test_InvalidMechanicsAvailable(int capacity)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    garage = new Garage("Gosho", capacity);
                });
            }
            [TestCase(100)]
            [TestCase(1)]
            [TestCase(2)]
            public void Test_ValidMechanicsAvailable(int capacity)
            {
                garage = new Garage("Gosho", capacity);
                Assert.AreEqual(capacity, garage.MechanicsAvailable);
            }

            [Test]
            public void Test_AddMethod()
            {
                garage.AddCar(car);
                int expectedCount = 1;
                Assert.AreEqual(expectedCount, garage.CarsInGarage);
            }

            [Test]
            public void Test_AddMethod_ShouldNotWork()
            {
                for (int i = 1; i <= 4; i++)
                {
                    garage.AddCar(new Car(string.Format($"BMW X{i}"), 2));
                }

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car);
                });
            }

            [Test]
            public void Test_FixMethod_ShouldNot_Work()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Mercedes GLE");
                });
            }
            [Test]
            public void Test_FixMethod_Should_Work()
            {
                garage.AddCar(car);
                garage.FixCar("BMW X6");
                int expectedNumberOfIssues = 0;
                Assert.AreEqual(expectedNumberOfIssues, car.NumberOfIssues);
            }

            [Test]
            public void Test_Remove_Method_With_NoCars()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }
            [Test]
            public void Test_Remove_Method_ShouldWork()
            {
                int expectedCount = 0;
                garage.AddCar(new Car("BMW X5", 2));
                garage.AddCar(new Car("BMW X6", 2));
                garage.FixCar("BMW X5");
                garage.FixCar("BMW X6");
                garage.RemoveFixedCar();
                Assert.AreEqual(expectedCount, garage.CarsInGarage);
            }
            [Test]
            public void Test_ReportMethod()
            {
                garage.AddCar(new Car("BMW X5", 2));
                garage.AddCar(new Car("BMW X6", 2));
                List<string> list = new List<string>()
                {
                  "BMW X5",
                  "BMW X6"
                };
                string cars = string.Format(string.Join(", ", list));
                string expectedResult = $"There are {list.Count} which are not fixed: {cars}.";
                Assert.AreEqual(expectedResult,garage.Report());
            }
        }
    }
}