using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(num => int.Parse(num)).ToArray();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    Action<int[]> AddAction = numbers =>
                    {
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i]++;
                        }
                    };
                    AddAction(input);
                }
                else if (command == "multiply")
                {
                    Action<int[]> multiplyAction = numbers =>
                    {
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] *= 2;
                        }
                    };
                    multiplyAction(input);
                }
                else if (command == "subtract")
                {
                    Action<int[]> subtractAction = numbers =>
                       {
                           for (int i = 0; i < numbers.Length; i++)
                           {
                               numbers[i]--;
                           }
                       };
                    subtractAction(input);
                }
                else if (command == "print")
                {
                    Action<int[]> printInput = number => Console.WriteLine(string.Join(" ",number));
                    printInput(input);
                }
            }
        }
    }
}
