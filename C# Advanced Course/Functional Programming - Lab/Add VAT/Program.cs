using System;
using System.Collections.Generic;
using System.Linq;

namespace Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> input = Console.ReadLine().Split(",").Select(num => decimal.Parse(num)).ToList();

            Func<decimal, decimal> func = num => num + (num * 20) / 100;

            input=input.Select(func).ToList();

            input.ForEach(number => Console.WriteLine($"{number:f2}"));
           
        }
    }
}
