using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartPhone;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            smartPhone = new Smartphone("IPhone 13 Pro Max", 22);
            shop = new Shop(20);
        }

        [Test]
        public void Test_Constructor()
        {
            string expectedModelName = "IPhone 13 Pro Max";
            int expectedBatteryCharge = 22;
            Assert.AreEqual(expectedModelName, smartPhone.ModelName);
            Assert.AreEqual(expectedBatteryCharge, smartPhone.MaximumBatteryCharge);
            Assert.AreEqual(expectedBatteryCharge, smartPhone.CurrentBateryCharge);
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(int.MaxValue)]
        public void Test_Capacity_WithValid_Values(int capacity)
        {
            shop = new Shop(capacity);
            Assert.AreEqual(capacity,shop.Capacity);
        }

        [Test]
        public void Test_Shop_Constructor()
        {
            int expectedCapacity = 20;
            int expectedInitialCount = 0;
            Assert.AreEqual(expectedCapacity, shop.Capacity);
            Assert.AreEqual(expectedInitialCount,shop.Count);
            
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(int.MinValue)]
        public void Test_ConstructorShop_WithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(capacity);
            }, "Invalid capacity.");
        }

        [Test]
        public void TestAddMethod_ShouldWork()
        {
            shop.Add(smartPhone);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, shop.Count);
        }

        [Test]
        public void TestAddMethod_With_SamePhoneModels()
        {
            shop.Add(smartPhone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartPhone);
            }, $"The phone model {smartPhone.ModelName} already exist.");
        }
        [Test]
        public void TestAddMethod_WithInvalidCapacity()
        {
            for (int i = 1; i <= 20; i++)
            {
                string name = string.Format($"IPhone{i}");
                shop.Add(new Smartphone(name, i * 2));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartPhone);
            }, "The shop is full.");
        }
        [Test]
        public void TestAddMethod_WithValidCapacity()
        {
            for (int i = 1; i <= 20; i++)
            {
                string name = string.Format($"IPhone{i}");
                shop.Add(new Smartphone(name, i * 2));
            }

            int expectedCount = 20;
            Assert.AreEqual(expectedCount,shop.Count);
        }

        [Test]
        public void Test_RemoveMethod_WithNoExistingSmartPhone()
        {
            string model = "IPhone XS Max";
            shop.Add(smartPhone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(model);
            }, $"The phone model {model} doesn't exist.");
        }

        [Test]
        public void TestRemoveMethod_With_ValidModel()
        {
            int expectedCount = 0;
            shop.Add(smartPhone);
            shop.Remove("IPhone 13 Pro Max");
            Assert.AreEqual(expectedCount, shop.Count);
        }

        [Test]
        public void Test_TestMethod_WithNoExisting_PhoneModel()
        {
            string modelName = "IPhone 6S";
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, 22);
            }, $"The phone model {modelName} doesn't exist.");
        }
        [Test]
        public void Test_TestMethod_WithBigger_BatteryUsage()
        {
            shop.Add(smartPhone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("IPhone 13 Pro Max", 27);
            },$"The phone model {smartPhone.ModelName} is low on batery.");
        }
        [Test]
        public void Test_TestMethod_WithValid_Params()
        {
            int expectedBattery = 12;
            shop.Add(smartPhone);
            shop.TestPhone("IPhone 13 Pro Max", 10);
            Assert.AreEqual(expectedBattery, smartPhone.CurrentBateryCharge);
        }

        [Test]
        public void Test_ChargePhone_With_No_Existing_SmartPhone()
        {
            shop.Add(smartPhone);
            string modelName = "Samsung A7";
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Samsung A7");
            },$"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void Test_ChargePhoneMethod_ShouldWork()
        {
            shop.Add(smartPhone);
            shop.TestPhone("IPhone 13 Pro Max",17);
            shop.ChargePhone("IPhone 13 Pro Max");
            int expectedBattery = smartPhone.MaximumBatteryCharge;
            Assert.AreEqual(expectedBattery, smartPhone.CurrentBateryCharge);
        }
    }
}