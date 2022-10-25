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
            while ((typeAnimal = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                if (typeAnimal=="Cat")
                {
                    try
                    {
                        Cat cat = new Cat(name, age, tokens[2]);
                        Console.WriteLine(typeAnimal);
                        Console.WriteLine($"{cat.Name} {cat.Age} {cat.Gender}");
                        Console.WriteLine(cat.ProduceSound());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (typeAnimal=="Dog")
                {
                    try
                    {
                        Dog dog = new Dog(name, age, tokens[2]);
                        Console.WriteLine(typeAnimal);
                        Console.WriteLine($"{dog.Name} {dog.Age} {dog.Gender}");
                        Console.WriteLine(dog.ProduceSound());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (typeAnimal=="Frog")
                {
                    try
                    {
                        Frog frog = new Frog(name, age, tokens[2]);
                        Console.WriteLine(typeAnimal);
                        Console.WriteLine($"{frog.Name} {frog.Age} {frog.Gender}");
                        Console.WriteLine(frog.ProduceSound());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (typeAnimal=="Kitten")
                {
                    try
                    {
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(typeAnimal);
                        Console.WriteLine($"{kitten.Name} {kitten.Age}");
                        Console.WriteLine(kitten.ProduceSound());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (typeAnimal=="TomCat")
                {
                    try
                    {
                        Tomcat tomCat = new Tomcat(name, age);
                        Console.WriteLine(typeAnimal);
                        Console.WriteLine($"{tomCat.Name} {tomCat.Age}");
                        Console.WriteLine(tomCat.ProduceSound());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }
    }
}
