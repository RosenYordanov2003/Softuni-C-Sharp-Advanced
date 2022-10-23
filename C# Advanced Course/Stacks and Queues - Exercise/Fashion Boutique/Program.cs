using System;
using System.Linq;
using System.Collections.Generic;
namespace Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ').Select(c => int.Parse(c)).ToArray();
            Stack<int> stack = new Stack<int>(clothes);
            int capacity = int.Parse(Console.ReadLine());
            int numberOfRacks = 1;
            int currentCapacity = 0;
            while (stack.Count != 0)
            {
                int currentClothesValue = stack.Peek();
                if (currentClothesValue + currentCapacity <=capacity)
                {
                    currentCapacity += currentClothesValue;
                    stack.Pop();
                }
                else
                {
                    currentCapacity = 0;
                    numberOfRacks++;
                    currentCapacity += currentClothesValue;
                    stack.Pop();
                }
            }
            Console.WriteLine(numberOfRacks);
        }
    }
}
