namespace Wild_Farm.Models
{
    using System;
    using System.Collections.Generic;
    using Exception_Messages;
    public class Mouse : Mammal
    {
        private Dictionary<string, double> mouseFood = new Dictionary<string, double>
        {
            {"Fruit",0.10},
            {"Vegetable",0.10}
        };
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }
        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override void Eat(Food food)
        {
            if (!mouseFood.ContainsKey(food.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_FOOD, this.GetType().Name, food.GetType().Name));
            }
            else
            {
                Weight += mouseFood[food.GetType().Name] * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
