using System;
using INStock.Contracts;

namespace INStock
{
    public class Product : IProduct
    {
        private string _label;

        private decimal _price;
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }
        public int CompareTo(IProduct other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public string Label
        {
            get => _label;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                _label = value;
            }
        }

        public decimal Price
        {
            get => _price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                _price = value;
            }
        }
        public int Quantity { get; private set; }

        public override string ToString()
        {
            return $"Labe: {Label}, Price: {Price}, Quantity: {Quantity}";
        }
    }
}
