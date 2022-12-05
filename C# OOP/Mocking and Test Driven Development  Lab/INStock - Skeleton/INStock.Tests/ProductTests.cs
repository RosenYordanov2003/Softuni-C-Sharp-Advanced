using System;

namespace INStock.Tests
{
    using NUnit.Framework;

    public class ProductTests
    {
        private Product _product;

        [SetUp]
        public void SetUp()
        {
            _product = new Product("BBA", 70.99M, 1);
        }

        [Test]
        public void Test_ProductConstructor()
        {
            Assert.AreEqual("BBA", _product.Label);
            Assert.AreEqual(70.99M, _product.Price);
            Assert.AreEqual(1, _product.Quantity);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Test_Product_With_InvalidLabel(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _product = new Product(value, 10, 1);
            });
        }
        [TestCase(-1)]
        [TestCase(-0)]
        [TestCase(-99)]
        public void Test_Product_With_InvalidPrice(decimal value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _product = new Product("BBA", value, 1);
            });
        }

     
    }
}