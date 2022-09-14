using System;
using System.Collections.Generic;
namespace Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countCarsCanPass = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string command = string.Empty;
            int passedCarsCounter = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 1; i <= countCarsCanPass; i++)
                    {
                        if (queue.Count != 0)
                        {
                            passedCarsCounter++;
                            string passedCar = queue.Dequeue();
                            Console.WriteLine($"{passedCar} passed!");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine($"{passedCarsCounter} cars passed the crossroads.");
        }
    }
}
