using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Models.Contracts
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }
        string ProduceSound();
        void Eat(Food food);
    }
}
