namespace Bakery.Models.BakedFoods
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class BakedFood : IBakedFood
    {
        private string _name;

        private int _portion;

        private decimal _price;

        protected BakedFood(string name, int portion, decimal price)
        {
            Name = name;
            Portion = portion;
            Price = price;
        }
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                _name = value;
            }
        }

        public int Portion
        {
            get => _portion;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }
                _portion = value;
            }
        }

        public decimal Price
        {
            get => _price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                _price = value;
            }
        }

        public override string ToString()
        {
            return $"{Name}: {Portion}g - {Price:F2}";
        }
    }
}
