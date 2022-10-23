using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(' ').ToList();
            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Double")
                {
                    string criteria = tokens[1];
                    string textToSearch = tokens[2];
                    List<string> namesToDouble = guests.FindAll(GetPredictae(criteria, textToSearch));
                    if (namesToDouble.Any())
                    {
                        int index = guests.FindIndex(GetPredictae(criteria, textToSearch));
                        guests.InsertRange(index, namesToDouble);
                    }
                }
                else
                {
                    string criteria = tokens[1];
                    string textToSearch = tokens[2];
                    guests.RemoveAll(GetPredictae(criteria,textToSearch));
                }
            }
            if (guests.Any())
            {
                Console.WriteLine($"{string.Join(", ",guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredictae(string criteria, string textToSearch)
        {
            if (criteria == "StartsWith")
            {
                return name => name.StartsWith(textToSearch);
            }
            else if (criteria == "EndsWith")
            {
                return name => name.EndsWith(textToSearch);
            }
            else
            {
                int length = int.Parse(textToSearch);
                return name => name.Length == length;
            }
        }
    }
}
