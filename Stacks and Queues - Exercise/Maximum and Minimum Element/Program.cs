using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(token => int.Parse(token)).ToArray();
                int action = tokens[0];
                if (action == 1)
                {
                    int elementToPush = tokens[1];
                    stack.Push(elementToPush);
                }
                else if (action == 2)
                {
                    if (stack.Count>0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (action==3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine(String.Join(", ",stack));
        }
    }
}
