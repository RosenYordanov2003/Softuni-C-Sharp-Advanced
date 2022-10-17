using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                Person currentPerson = new Person(name, age, town);
                people.Add(currentPerson);
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[index];
            int countEquals = 0;
            int countNotEqual = 0;
            for (int i = 0; i < people.Count; i++)
            {
                Person currentPerson = people[i];
                int result = currentPerson.CompareTo(personToCompare);
                if (result == 0)
                {
                    countEquals++;
                    continue;
                }
                countNotEqual++;
            }
            if (countEquals<=1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countEquals} {countNotEqual} {people.Count}");
            }
        }
    }
}
