using System;
using System.Collections.Generic;
using System.Linq;
namespace Stacks_and_Queues___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameeters = Console.ReadLine().Split(' ').Select(param => int.Parse(param)).ToArray();
            int countNumbersToPush = parameeters[0];
            int countElementsToPop = parameeters[1];
            int numberToCheck = parameeters[2];
            int[] numbers = Console.ReadLine().Split(' ').Select(param => int.Parse(param)).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            for (int i = 0; i < countElementsToPop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count!=0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
