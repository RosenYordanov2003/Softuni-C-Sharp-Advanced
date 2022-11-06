namespace Wild_Farm.Models
{
    using System;
    using System.Collections.Generic;
    using Exception_Messages;
    public class Dog : Mammal
    {
       private Dictionary<string, double> dogFood = new Dictionary<string, double>
        {
            {"Meat",0.40}
        };
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override void Eat(Food food)
        {
            if (!dogFood.ContainsKey(food.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_FOOD, this.GetType().Name, food.GetType().Name));
            }
            else
            {
                Weight += dogFood[food.GetType().Name] * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
