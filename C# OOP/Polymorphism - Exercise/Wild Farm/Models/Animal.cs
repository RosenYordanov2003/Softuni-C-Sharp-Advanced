namespace Wild_Farm.Models
{
    using System;
    using Contracts;
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public virtual void Eat(Food food)
        {

        }

        public virtual string ProduceSound()
        {
            return "";
        }
    }
}
