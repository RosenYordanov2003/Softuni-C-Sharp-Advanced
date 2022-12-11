namespace ChristmasPastryShop.Models.Cocktails
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Cocktail : ICocktail
    {
        private string name;

        private string size;

        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size
        {
            get => size;
            private set => size = value;
        }

        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Middle")
                {
                    price = 2.0 / 3.0 * value;
                }
                else if (Size == "Small")
                {
                    price = 1.0 / 3.0 * value;
                }
                else
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }
    }
}
