using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string typeAnimal;
            List<Animal> animals = new List<Animal>();
            while ((typeAnimal = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                try
                {
                    if (typeAnimal == "Cat")
                    {
                        Cat cat = new Cat(name, age, tokens[2]);
                        animals.Add(cat);
                    }
                    else if (typeAnimal == "Dog")
                    {
                        Dog dog = new Dog(name, age, tokens[2]);
                        animals.Add(dog);
                    }
                    else if (typeAnimal == "Frog")
                    {
                        Frog frog = new Frog(name, age, tokens[2]);
                        animals.Add(frog);
                    }
                    else if (typeAnimal == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                    else if (typeAnimal == "TomCat")
                    {
                        Tomcat tomCat = new Tomcat(name, age);
                        animals.Add(tomCat);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
