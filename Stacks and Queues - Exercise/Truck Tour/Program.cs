using System;
using System.Linq;
using System.Collections.Generic;
namespace Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split().Select(num => int.Parse(num)).ToArray();
                queue.Enqueue(data);
            }
            int index = 0;
            while (true)
            {
                bool isDone = true;
                int totalFuel = 0;
                foreach (int[] stations in queue)
                {
                    int currentFuel = stations[0];
                    totalFuel += currentFuel;
                    int distance = stations[1];
                    if (totalFuel < distance)
                    {
                        index++;
                        int[]currentStation=queue.Dequeue();
                        queue.Enqueue(currentStation);
                        isDone = false;
                        break;
                    }
                    else
                    {
                        totalFuel -= distance;
                    }
                }
                if (isDone)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
