using System;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock.Tests
{
    using INStock;
    using NUnit.Framework;

    public class ProductStockTests
    {
        private ProductStock _stock;
        private Product _product;

        [SetUp]
        public void SetUp()
        {
            _stock = new ProductStock();
            _product = new Product("BBA", 70.99M, 2);
        }

        [Test]
        public void Test_AddMethod()
        {
            _stock.Add(_product);
            Assert.AreEqual(1, _stock.Count);
        }

        [Test]
        public void Test_ContainsMethod_ShouldReturn_True()
        {
            _stock.Add(_product);
            Assert.IsTrue(_stock.Contains(_product));
        }
        [Test]
        public void Test_ContainsMethod_ShouldReturn_False()
        {
            _stock.Add(new Product("MMM", 12, 1));
            Assert.IsFalse(_stock.Contains(_product));
        }
        [Test]
        public void Test_FindMethod_Should_Work()
        {
            _stock.Add(_product);
            IProduct product = _stock.Find(0);
            Assert.AreSame(_product, product);
        }
        [Test]
        public void Test_FindMethod_Should_NotWork()
        {
            _stock.Add(_product);
            Assert.Throws<IndexOutOfRangeException>(() => _stock.Find(1));
        }

        [Test]
        public void Test_FindByLabelMethod_Should_Work()
        {
            _stock.Add(_product);
            IProduct product = _stock.FindByLabel("BBA");
            Assert.AreSame(_product, product);
        }
        [Test]
        public void Test_FindByLabelMethod_Should_NotWork()
        {
            _stock.Add(_product);
            Assert.Throws<ArgumentException>(() => _stock.FindByLabel("ZZZ"));
        }

        [Test]
        public void Test_FindAllInPriceRange_ShouldReturn_NoEmpty_Collection()
        {
            _stock.Add(_product);
            IProduct firstProduct = new Product("MM", 72.22M, 2);
            IProduct secondProduct = new Product("MMI", 78.22M, 3);
            IProduct thirdProduct = new Product("MMI", 81.22M, 3);
            _stock.Add(firstProduct);
            _stock.Add(secondProduct);
            _stock.Add(thirdProduct);
            List<IProduct> products = new List<IProduct>()
            {
                _product,
              firstProduct,
              secondProduct,
              thirdProduct
            };
            products = products.OrderByDescending(p => p.Price).ToList();

            CollectionAssert.AreEqual(products, _stock.FindAllInRange(70, 82));
        }

        [Test]
        public void Test_FindAllInPriceRange_ShouldReturn_Empty_Collection()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 2);
            IProduct secondProduct = new Product("MMI", 78.22M, 3);
            IProduct thirdProduct = new Product("MMI", 81.22M, 3);
            _stock.Add(firstProduct);
            _stock.Add(secondProduct);
            _stock.Add(thirdProduct);
            List<IProduct> products = new List<IProduct>();
            CollectionAssert.AreEqual(products, _stock.FindAllInRange(100, 200));
        }

        [Test]
        public void Test_FindAllByPrice_Method_ShouldReturn_NoEmpty_Collection()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 2);
            IProduct secondProduct = new Product("MMI", 72.22M, 3);
            IProduct thirdProduct = new Product("MMI", 72.22M, 3);
            _stock.Add(firstProduct);
            _stock.Add(secondProduct);
            _stock.Add(thirdProduct);
            List<IProduct> products = new List<IProduct>()
            {
                firstProduct,
                secondProduct,
                thirdProduct
            };
            CollectionAssert.AreEqual(products, _stock.FindAllByPrice(72.22M));
        }
        [Test]
        public void Test_FindAllByPrice_Method_ShouldReturn_Empty_Collection()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 2);
            IProduct secondProduct = new Product("MMI", 78.22M, 3);
            IProduct thirdProduct = new Product("MMI", 81.22M, 3);
            _stock.Add(firstProduct);
            _stock.Add(secondProduct);
            _stock.Add(thirdProduct);
            List<IProduct> products = new List<IProduct>();
            CollectionAssert.AreEqual(products, _stock.FindAllByPrice(100));
        }
        [Test]
        public void Test_Most_ExpensiveProduct_Method()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 2);
            IProduct secondProduct = new Product("MMI", 78.22M, 3);
            IProduct thirdProduct = new Product("MMI", 81.22M, 3);
            _stock.Add(firstProduct);
            _stock.Add(secondProduct);
            _stock.Add(thirdProduct);
            Assert.AreSame(thirdProduct, _stock.FindMostExpensiveProduct());
        }

        [Test]
        public void Test_FindAllByQuantityMethod_ShouldReturn_NoEmptyCollection()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 3);
            IProduct secondProduct = new Product("MMI", 78.22M, 3);
            IProduct thirdProduct = new Product("MMI", 81.22M, 3);
            _stock.Add(firstProduct);
            _stock.Add(secondProduct);
            _stock.Add(thirdProduct);
            List<IProduct> products = new List<IProduct>()
            {
                firstProduct,
                secondProduct,
                thirdProduct
            };
            CollectionAssert.AreEqual(products, _stock.FindAllByQuantity(3));
        }
        [Test]
        public void Test_FindAllByQuantityMethod_ShouldReturn_EmptyCollection()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 3);
            IProduct secondProduct = new Product("MMI", 78.22M, 3);
            IProduct thirdProduct = new Product("MMI", 81.22M, 3);
            _stock.Add(firstProduct);
            _stock.Add(secondProduct);
            _stock.Add(thirdProduct);
            List<IProduct> products = new List<IProduct>();

            CollectionAssert.AreEqual(products, _stock.FindAllByQuantity(5));
        }
        [Test]
        public void Test_GetEnumeratorMethod()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 3);
            IProduct secondProduct = new Product("MMI", 78.22M, 3);
            IProduct thirdProduct = new Product("MMI", 81.22M, 3);
            _stock.Add(firstProduct);
            _stock.Add(secondProduct);
            _stock.Add(thirdProduct);
            var products = _stock.GetEnumerator();
        }

        [Test]
        public void Test_Indexer()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 3);
            _stock.Add(firstProduct);
            IProduct product = _stock[0];
            Assert.AreSame(firstProduct,product);
        }

        [Test]
        public void Test_RemoveMethod_ShouldReturn_True()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 3);
            _stock.Add(firstProduct);
            Assert.IsTrue(_stock.Remove(firstProduct));
        }
        [Test]
        public void Test_RemoveMethod_ShouldReturn_False()
        {
            IProduct firstProduct = new Product("MM", 72.22M, 3);
            _stock.Add(firstProduct);
            Assert.IsFalse(_stock.Remove(new Product("BZA",70,2)));
        }
    }
}
