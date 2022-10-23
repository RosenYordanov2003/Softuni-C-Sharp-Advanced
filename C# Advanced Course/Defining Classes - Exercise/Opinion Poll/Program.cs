using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            int countPerson = int.Parse(Console.ReadLine());
            for (int i = 0; i < countPerson; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }
            persons = persons.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            PrintResult(persons);
        }

        private static void PrintResult(List<Person> persons)
        {
            foreach (Person people in persons)
            {
                Console.WriteLine($"{people.Name} - {people.Age}");
            }
        }
    }
}
