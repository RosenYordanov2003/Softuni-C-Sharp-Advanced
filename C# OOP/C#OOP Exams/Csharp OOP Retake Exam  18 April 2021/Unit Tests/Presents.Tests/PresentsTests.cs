namespace Presents.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Present _present;
        private Bag _bag;

        [SetUp]
        public void SetUp()
        {
            _present = new Present("Gosho", 130);
            _bag = new Bag();
        }

        [Test]
        public void Test_Present_Constructor()
        {
            Assert.AreEqual("Gosho", _present.Name);
            Assert.AreEqual(130, _present.Magic);
        }

        [Test]
        public void Test_Bag_Constructor()
        {
            Assert.IsNotNull(_bag.GetPresents());
        }

        [Test]
        public void Test_Bag_CreateMethod_With_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _bag.Create(null);
            });
        }
        [Test]
        public void Test_Bag_CreateMethod_With_Same_Present()
        {
            _bag.Create(_present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                _bag.Create(_present);
            });
        }
        [Test]
        public void Test_Bag_CreateMethod_With_Same_Valid_Present()
        {
            string expectedMessage = string.Format($"Successfully added present {_present.Name}.");
            Assert.AreEqual(expectedMessage, _bag.Create(_present));
        }

        [Test]
        public void Test_Bag_Remove_Method_Should_Return_True()
        {
            _bag.Create(_present);
            Assert.IsTrue(_bag.Remove(_present));
        }
        [Test]
        public void Test_Bag_Remove_Method_Should_Return_False()
        {
            Assert.IsFalse(_bag.Remove(_present));
        }

        [Test]
        public void Test_Bag_GetPresentWithLeastMagic_Method()
        {
            Present present2 = new Present("PS5", 129);
            Present present3 = new Present("IPhone", 200);
            Present present4 = new Present("AirPods", 80);
            _bag.Create(_present);
            _bag.Create(present3);
            _bag.Create(present2);
            _bag.Create(present4);
            Assert.AreSame(present4, _bag.GetPresentWithLeastMagic());
        }
        [Test]
        public void Test_Bag_GetPresentWithLeastMagic_Method2()
        {
            Present present2 = new Present("PS5", 1292);
            Present present3 = new Present("IPhone", 200);
            Present present4 = new Present("AirPods", 807);
            _bag.Create(_present);
            _bag.Create(present3);
            _bag.Create(present2);
            _bag.Create(present4);
            Assert.AreSame(_present, _bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void Test_Bag_GetPresent_Method_With_Null()
        {
            Assert.AreEqual(null, _bag.GetPresent("IPhone 14"));
        }
        [Test]
        public void Test_Bag_GetPresent_Method_With_ValidPresent()
        {
            _bag.Create(_present);
            Assert.AreSame(_present, _bag.GetPresent("Gosho"));
        }

        [Test]
        public void Test_Bag_GetPresents_CollectionCount()
        {
            Present present2 = new Present("PS5", 1292);
            Present present3 = new Present("IPhone", 200);
            Present present4 = new Present("AirPods", 807);
            _bag.Create(_present);
            _bag.Create(present3);
            _bag.Create(present2);
            _bag.Create(present4);
            Assert.AreEqual(4, _bag.GetPresents().Count);
        }

        [Test]
        public void Test_Bag_GetPresents_Collection_Items()
        {
            Present present2 = new Present("PS5", 1292);
            Present present3 = new Present("IPhone", 200);
            Present present4 = new Present("AirPods", 807);
            _bag.Create(_present);
            _bag.Create(present3);
            _bag.Create(present2);
            _bag.Create(present4);
            List<Present> presents = new List<Present>();
            presents.Add(_present);
            presents.Add(present3);
            presents.Add(present2);
            presents.Add(present4);
            CollectionAssert.AreEqual(presents, _bag.GetPresents());
        }
    }
}
