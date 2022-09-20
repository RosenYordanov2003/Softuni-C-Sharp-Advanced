using System;
using System.Collections.Generic;
using System.Linq;

namespace Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(number))
                {
                    dictionary[number] = 0;
                }
                dictionary[number]++;
            }
            foreach (KeyValuePair<int,int> item in dictionary)
            {
                if (item.Value%2==0)
                {
                    Console.WriteLine(item.Key);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
