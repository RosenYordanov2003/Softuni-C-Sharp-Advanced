using System;
using System.Linq;

namespace Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(x => int.Parse(x)).ToArray();
         
            Console.WriteLine(numbers.Length);

            Console.WriteLine(numbers.Sum());
        }
    }
}
