using System;
using System.Linq;
using System.Collections.Generic;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }
            int sum = 0;
            int number = 0;
            int d = 0;
            char symbol = '0';
            int counter = 0;
            while (stack.Count != 0)
            {
                string result = stack.Pop();
                bool succsec = int.TryParse(result, out d);
                if (succsec)
                {
                    number=int.Parse(result);
                    if (counter==0)
                    {
                        sum += number;
                        continue;
                    }
                    if (symbol=='+')
                    {
                        sum += number;
                    }
                    else
                    {
                        sum -= number;
                    }
                }
                else
                {
                    counter++;
                    if (result=="+")
                    {
                        symbol = '+';
                    }
                    else if (result == "-")
                    {
                        symbol= '-';
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
