using System;
using System.Linq;
using System.Collections.Generic;
namespace Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(' ').Select(param => int.Parse(param)).ToArray();
            int countNumbersToAdd = parameters[0];
            int countNumbersToRemove = parameters[1];
            int numbersToCheck = parameters[2];
            int[] numbers = Console.ReadLine().Split(' ').Select(param => int.Parse(param)).ToArray();
           
            Queue<int>queue=new Queue<int>(numbers);
            for (int i = 0; i < countNumbersToRemove; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(numbersToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count!=0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }

        }
    }
}
