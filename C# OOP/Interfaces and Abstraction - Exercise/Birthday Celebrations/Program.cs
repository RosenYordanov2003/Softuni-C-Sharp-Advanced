using Birthday_Celebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday_Celebrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBirthdable> list = new List<IBirthdable>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Pet")
                {
                    string name = tokens[1];
                    string birthday = tokens[2];
                    Pet pet = new Pet(name, birthday);
                    list.Add(pet);
                }
                else if (action == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthday = tokens[4];
                    Person person = new Person(name, age, id, birthday);
                    list.Add(person);
                }
            }
            string birthdayYear = Console.ReadLine();
            list = list.Where(x => x.Birthday.EndsWith(birthdayYear)).ToList();
            list.ForEach(x => Console.WriteLine(x.Birthday));
        }
    }
}
