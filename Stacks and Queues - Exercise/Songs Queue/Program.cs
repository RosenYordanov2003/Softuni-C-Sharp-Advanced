using System;
using System.Linq;
using System.Collections.Generic;
namespace Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(songs);
            while (queue.Count != 0)
            {

                string action = Console.ReadLine();
                if (action.Contains("Add"))
                {
                    string songToAdd = action.Substring(4);

                    if (queue.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(songToAdd);
                    }
                }
                else if (action == "Play")
                {
                    queue.Dequeue();
                }
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
