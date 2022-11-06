namespace Wild_Farm.Factories
{
    using System;
    using Contracts;
    using Models.Contracts;
    using Wild_Farm.Models;

    public class Factory : IFactory
    {
        public IAnimal CreateAnimal(string[] tokens)
        {
            IAnimal animal = null;
            string animalType = tokens[0];
            if (animalType == "Cat")
            {
                animal = new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
            }
            else if (animalType == "Tiger")
            {
                animal = new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
            }
            else if (animalType == "Dog")
            {
                animal = new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
            }
            else if (animalType == "Mouse")
            {
                animal = new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
            }
            else if (animalType == "Hen")
            {
                animal = new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
            }
            else if (animalType == "Owl")
            {
                animal = new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
            }
            return animal;
        }

        public Food CreateFood(string[] tokens)
        {
            string foddType = tokens[0];
            Food food = null;
            if (foddType == "Meat")
            {
                food = new Meat(int.Parse(tokens[1]));
            }
            else if (foddType == "Fruit")
            {
                food = new Fruit(int.Parse(tokens[1]));
            }
            else if (foddType == "Vegetable")
            {
                food = new Vegetable(int.Parse(tokens[1]));
            }
            else if (foddType == "Seeds")
            {
                food = new Seeds(int.Parse(tokens[1]));
            }
            return food;
        }
    }
}
