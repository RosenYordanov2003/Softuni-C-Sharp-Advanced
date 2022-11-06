
namespace Wild_Farm.Models
{
    using System;
    using System.Collections.Generic;
    using Wild_Farm.Exception_Messages;

    public class Cat : Feline
    {
        private Dictionary<string,double>catFood = new Dictionary<string, double>
        {
            {"Meat",0.30 },
            {"Vegetable",0.30 }
        };
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override void Eat(Food food)
        {
            if (!catFood.ContainsKey(food.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_FOOD,(this.GetType().Name, food.GetType().Name)));
            }
            else
            {
                Weight += catFood[food.GetType().Name]*food.Quantity;
                FoodEaten += food.Quantity;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
