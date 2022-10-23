using System;
using System.Linq;
using System.Collections.Generic;

namespace Stacks_and_Queues___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char>stack=new Stack<char>();
            for (int i = 0; i <input.Length ; i++)
            {
                char currentCharacter = input[i];
                stack.Push(currentCharacter);
            }
            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
