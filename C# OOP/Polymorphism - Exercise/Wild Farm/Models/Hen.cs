using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Models
{
    public class Hen : Bird
    {
        private const double CALORIES = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }
        public override void Eat(Food food)
        {
            Weight += food.Quantity * CALORIES;
            FoodEaten += food.Quantity;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
