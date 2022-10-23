using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            foreach (char character in text)
            {
                if (!dictionary.ContainsKey(character))
                {
                    dictionary[character] = 0;
                }
                dictionary[character]++;
            }
            PrintResult(dictionary);
        }

        static void PrintResult(SortedDictionary<char, int> dictionary)
        {
            foreach (KeyValuePair<char,int> item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
