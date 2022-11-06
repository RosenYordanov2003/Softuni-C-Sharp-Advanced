namespace Wild_Farm.Core.Engines
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Factories;
    using Models.Contracts;
    using Wild_Farm.Models;

    public class Engine : IEngine
    {
        private readonly ICollection<IAnimal> animals;
        private readonly Factory factory;
        public Engine()
        {
            animals = new List<IAnimal>();
            factory = new Factory();
        }
        public void Run()
        {
            string command = string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                string[]animalTokens = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                IAnimal animal = factory.CreateAnimal(animalTokens);
                animals.Add(animal);
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Food food = factory.CreateFood(tokens);
                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
