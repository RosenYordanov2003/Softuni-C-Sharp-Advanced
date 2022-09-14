using System;
using System.Linq;
using System.Collections.Generic;
namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(num => int.Parse(num)).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split(' ');
                string action = tokens[0];
                if (action == "add")
                {
                    int firstNumber = int.Parse(tokens[1]);
                    int secondNumber = int.Parse(tokens[2]);
                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (action =="remove")
                {
                    int countToRemove = int.Parse(tokens[1]);
                    if (countToRemove > stack.Count)
                    {
                        continue;
                    }
                    else
                    {
                        while (countToRemove > 0)
                        {
                            stack.Pop();
                            countToRemove--;
                        }
                    }
                }
            }
            int sum = FindSum(stack);
            Console.WriteLine($"Sum: {sum}");
        }

        static int FindSum(Stack<int> stack)
        {
            int sum= 0;
            if (stack.Count!=0)
            {
                while (stack.Count > 0)
                {
                    sum+=stack.Pop();
                }
                return sum;
            }
            else
            {
                return 0;
            }
        }
    }
}
