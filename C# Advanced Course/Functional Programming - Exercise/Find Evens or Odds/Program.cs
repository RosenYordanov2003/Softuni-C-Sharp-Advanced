using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int[]input =Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int start = input[0];
            int end = input[1];
            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }
            string type = Console.ReadLine();
            if (type == "even")
            {
                Func<int, bool> evenFunction = number => number % 2 == 0;
                numbers = numbers.Where(number => evenFunction(number)).ToList();
            }
            else
            {
                Func<int, bool> oddFunction = number => number % 2 != 0;
                numbers = numbers.Where(number => oddFunction(number)).ToList();
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
