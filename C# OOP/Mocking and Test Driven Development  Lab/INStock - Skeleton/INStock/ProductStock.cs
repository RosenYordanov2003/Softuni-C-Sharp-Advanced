using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }
        public IEnumerator<IProduct> GetEnumerator()
        {
            return new ProductIterator(products);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => products.Count;

        public IProduct this[int index]
        {
            get => products[index];
            set => products[index] = value;
        }

        public bool Contains(IProduct product)
        {
            return products.Any(p => p.Label == product.Label);
        }

        public void Add(IProduct product)
        {
            products.Add(product);
        }

        public bool Remove(IProduct product)
        {
            IProduct productToRemove = products.FirstOrDefault(p => p.Label == product.Label);
            return products.Remove(productToRemove);
        }

        public IProduct Find(int index)
        {
            if (index >= products.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return products[index];
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = products.FirstOrDefault(p => p.Label == label);
            if (product == null)
            {
                throw new ArgumentException();
            }

            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            IProduct product = products.OrderByDescending(p => p.Price).First();
            return product;
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            List<IProduct> orderProducts = products.Where(p => p.Price >= lo && p.Price <= hi)
                .OrderByDescending(p => p.Price).ToList();
            return orderProducts;
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            List<IProduct> products = this.products.FindAll(p => p.Price == price);
            return products;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            List<IProduct> products = this.products.FindAll(p => p.Quantity == quantity);
            return products;
        }

        private class ProductIterator : IEnumerator<IProduct>
        {
            private List<IProduct> products;

            private int index;
            public ProductIterator(List<IProduct> products)
            {
                this.Reset();
                this.products = products;
            }

            public bool MoveNext()
            {
                return ++index < products.Count;
            }

            public void Reset()
            {
                index = -1;
            }

            public IProduct Current => products[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }
        }
    }
}
