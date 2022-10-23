using System;
using System.Collections.Generic;
namespace Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(kids);
            int counterToss = int.Parse(Console.ReadLine());
            int currentTossCounter = 1;
            while (queue.Count != 1)
            {
                string kidLeft = queue.Dequeue();
                if (currentTossCounter != counterToss)
                {
                    currentTossCounter++;
                    queue.Enqueue(kidLeft);
                }
                else
                {
                    currentTossCounter = 1;
                    Console.WriteLine($"Removed {kidLeft}");
                }
            }
            foreach (string lastKid in queue)
            {
                Console.WriteLine($"Last is {lastKid}");
            }
        }
    }
}
