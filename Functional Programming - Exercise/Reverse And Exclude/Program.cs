using System;
using System.Linq;

namespace Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(num => int.Parse(num)).ToArray();

            Action<int[]> reverse = numbers => ReverseAction(input);

            reverse(input);

            Func<int,int, bool> isDivisible = (number,divideNumber) => number % divideNumber != 0;

            int numberToDivide = int.Parse(Console.ReadLine());

            input = input.Where(num => isDivisible(num, numberToDivide)).ToArray();

            Action<int[]> print = number => Console.WriteLine(string.Join(" ", number));

            print(input);
        }

        static void ReverseAction(int[] input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                int current = input[i];
                int currentLast = input[input.Length - 1 - i];
                input[i] = currentLast;
                input[input.Length - 1 - i] = current;
            }
        }
    }
}
