using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<Person> personHashSet = new HashSet<Person>();
            SortedSet<Person> personSortedSet = new SortedSet<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] toknes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = toknes[0];
                int age = int.Parse(toknes[1]);
                Person currentPerson = new Person(name, age);
                personSortedSet.Add(currentPerson);
                personHashSet.Add(currentPerson);
            }
            Console.WriteLine(personSortedSet.Count);
            Console.WriteLine(personHashSet.Count);
        }
    }
}
