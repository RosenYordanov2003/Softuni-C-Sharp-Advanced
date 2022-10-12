using System;
using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo("Zoo Time", 20);
            Animal animaleOne = new Animal("elephant", "herbivore", 4000, 4);
            Animal animalTwo = new Animal("elephant", "herbivore", 3421.25, 3.7);
            Animal animalThree = new Animal("zebra", "herbivore", 380.52, 1.9);
            Animal animalFour = new Animal("cheetah", "carnivore", 59.52, 1.4);
            Animal animalFive = new Animal("wolf", "carnivore", 65.25, 1.5);
            Console.WriteLine(zoo.AddAnimal(animaleOne));
            Console.WriteLine(zoo.AddAnimal(animalTwo));
            Console.WriteLine(zoo.AddAnimal(animalThree));
            Console.WriteLine(zoo.AddAnimal(animalFour));
            Console.WriteLine(zoo.AddAnimal(animalFive));
            List<Animal> animalByDiet = zoo.GetAnimalsByDiet("herbivore");
            foreach (Animal animal in animalByDiet)
            {
                Console.WriteLine(animal.ToString());
            }
            Animal getAnimalByWeight = zoo.GetAnimalByWeight(4000);
            Console.WriteLine(getAnimalByWeight.ToString());
            Animal animalSix = new Animal("wolf", "carnivore", 80.25, 1.8);
            Animal animalSeven = new Animal("moose", "stake", 250.25, 2.5);
            Console.WriteLine(zoo.AddAnimal(animalSix));
            Console.WriteLine(zoo.AddAnimal(animalSeven));
            Console.WriteLine(zoo.GetAnimalCountByLength(1.4, 3));
            Console.WriteLine($"Animals living in the zoo: {zoo.Animals.Count}.");
            Console.WriteLine(zoo.RemoveAnimals("elephant"));
            Console.WriteLine($"There are {zoo.Animals.Count} animals living in the zoo.");
        }
    }
}
