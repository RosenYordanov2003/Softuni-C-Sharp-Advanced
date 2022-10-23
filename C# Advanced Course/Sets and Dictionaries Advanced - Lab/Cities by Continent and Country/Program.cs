using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> dictionary = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if (!dictionary.ContainsKey(continent))
                {
                    dictionary[continent] = new Dictionary<string, List<string>>();
                    dictionary[continent][country] = new List<string>();
                }
                else if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent][country] = new List<string>();
                }
                dictionary[continent][country].Add(city);
            }
            PrintResult(dictionary);
        }

        static void PrintResult(Dictionary<string, Dictionary<string, List<string>>> dictionary)
        {
            foreach (KeyValuePair<string,Dictionary<string,List<string>>> item in dictionary)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (KeyValuePair<string,List<string>> z in item.Value)
                {
                    Console.WriteLine($"{z.Key} -> {string.Join(", ",z.Value)}");
                }
            }
        }
    }
}
