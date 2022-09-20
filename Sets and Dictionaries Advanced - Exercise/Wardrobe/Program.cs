using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[]secondInput=input[1].Split(",",StringSplitOptions.RemoveEmptyEntries);
                for (int clothes = 0; clothes < secondInput.Length; clothes++)
                {
                    string currentClothes = secondInput[clothes];
           
                    if (!dictionary.ContainsKey(color))
                    {
                        dictionary[color] = new Dictionary<string, int>();
                        dictionary[color].Add(currentClothes, 0);
                    }
                    else if (!dictionary[color].ContainsKey(currentClothes))
                    {
                        dictionary[color][currentClothes] = 0;
                    }
                    dictionary[color][currentClothes]++;
                }

            }
            string[] clothesToFind = Console.ReadLine().Split();
            string colorToFind = clothesToFind[0];
            string clothing = clothesToFind[1];
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dictionary)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (KeyValuePair<string, int> clothes in item.Value)
                {
                    if (item.Key == colorToFind && clothes.Key == clothing)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
