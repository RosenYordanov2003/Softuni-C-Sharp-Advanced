namespace ChristmasPastryShop.Models.Delicacies
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Delicacy : IDelicacy
    {
        private string name;

        private double price;

        protected Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
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

        public double Price
        {
            get => price;
            private set => price = value;
        }

        public override string ToString()
        {
            return $"{Name} - {Price:f2} lv";
        }
    }
}
