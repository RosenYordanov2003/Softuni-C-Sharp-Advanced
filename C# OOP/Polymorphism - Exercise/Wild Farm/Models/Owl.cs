
namespace Wild_Farm.Models
{
    using System;
    using System.Collections.Generic;
    using Exception_Messages;
    public class Owl : Bird
    {
        private Dictionary<string,double>dictionary = new Dictionary<string, double>
        {
            {"Meat",0.25 }
        };
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
        public override void Eat(Food food)
        {
            if (!dictionary.ContainsKey(food.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_FOOD, this.GetType().Name, food.GetType().Name));
            }
            else
            {
                Weight += dictionary[food.GetType().Name] * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
