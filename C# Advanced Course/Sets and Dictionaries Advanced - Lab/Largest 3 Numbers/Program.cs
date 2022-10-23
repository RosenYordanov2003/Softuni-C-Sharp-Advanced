using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            list = list.OrderByDescending(x => x).ToList();
            if (list.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{list[i]} ");
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write($"{list[i]} ");
                }
            }
        }
    }
}
