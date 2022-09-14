using System;
using System.Collections.Generic;
namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command!="Paid")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    foreach (string names in queue)
                    {
                        Console.WriteLine(names);
                    }
                    queue.Clear();
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
