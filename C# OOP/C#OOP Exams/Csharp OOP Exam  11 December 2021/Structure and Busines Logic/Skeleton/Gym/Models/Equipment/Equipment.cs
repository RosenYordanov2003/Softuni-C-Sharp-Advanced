namespace Gym.Models.Equipment
{
    using Contracts;
    public class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        protected Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }
        public double Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }
    }
}
