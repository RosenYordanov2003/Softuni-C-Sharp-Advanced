using System;
using System.Linq;
using System.Collections.Generic;
namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(number => int.Parse(number)).ToArray();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i <numbers.Length; i++)
            {
                int currentNumber=numbers[i];
                if (currentNumber%2!=0)
                {
                    continue;
                }
                else
                {
                    queue.Enqueue(currentNumber);
                }
            }
            Console.WriteLine(String.Join(", ",queue));
        }
    }
}
