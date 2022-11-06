namespace Wild_Farm.Models
{
    using System;
    using System.Collections.Generic;
    using Exception_Messages;
    public class Tiger : Feline
    {
        private Dictionary<string, double> tigerFood = new Dictionary<string, double>
        {
            {"Meat",1.00}
        };
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
        public override void Eat(Food food)
        {
            if (!tigerFood.ContainsKey(food.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_FOOD, this.GetType().Name, food.GetType().Name));
            }
            else
            {
                Weight += tigerFood[food.GetType().Name] * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
