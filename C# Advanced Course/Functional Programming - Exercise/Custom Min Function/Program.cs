using System;
using System.Linq;

namespace Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(num => int.Parse(num)).ToArray();

            Func<int[], int> minFunction = numbers => GetMinNumber(numbers);

            int result = minFunction(numbers);

            Console.WriteLine(result);
        }

        static int GetMinNumber(int[] numbers)
        {
            int min = int.MaxValue;
            foreach (int number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }
            return min;
        }
    }
}
