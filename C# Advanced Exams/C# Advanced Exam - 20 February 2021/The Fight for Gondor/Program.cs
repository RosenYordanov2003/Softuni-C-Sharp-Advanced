using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            int[] plates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> orcs = new Stack<int>();
            Queue<int> queue = new Queue<int>(plates);
            for (int i = 1; i <= numberOfWaves; i++)
            {
                int[] currentWave = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (!queue.Any())
                {
                    break;
                }
                AddWave(currentWave, orcs);
                if (i % 3 == 0)
                {
                    int bonusPlate = int.Parse(Console.ReadLine());
                    queue.Enqueue(bonusPlate);
                }
                while (orcs.Any() && queue.Any())
                {
                    int currentPlate = queue.Peek();
                    while (currentPlate > 0)
                    {
                        if (!orcs.Any())
                        {
                            if (currentPlate > 0)
                            {
                                queue.Dequeue();
                                string  secondQueueResults = string.Join(" ", queue);
                                string[] array = secondQueueResults.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                queue.Clear();
                                queue.Enqueue(currentPlate);
                                foreach (string item in array)
                                {
                                    queue.Enqueue(int.Parse(item));
                                }
                            }
                            break;
                        }
                        int currentOrc = orcs.Pop();

                        if (currentOrc == currentPlate)
                        {
                            currentPlate -= currentOrc;
                            queue.Dequeue();
                        }
                        else if (currentOrc < currentPlate)
                        {
                            currentPlate -= currentOrc;
                        }
                        else
                        {
                            int originalValue = currentPlate;
                            currentPlate -= currentOrc;
                            currentOrc -= originalValue;
                            queue.Dequeue();
                            orcs.Push(currentOrc);
                        }
                    }
                }
            }
            string result = queue.Count == 0 ? "The orcs successfully destroyed the Gondor's defense." : "The people successfully repulsed the orc's attack.";
            string result2 = orcs.Count == 0 ? $"Plates left: {string.Join(", ", queue)}" : $"Orcs left: {string.Join(", ", orcs)}";
            Console.WriteLine($"{result}\n{result2}");
        }

        static void AddWave(int[] currentWave, Stack<int> orcs)
        {
            foreach (int item in currentWave)
            {
                orcs.Push(item);
            }
        }
    }
}
//3
//10 20 30
//5 6 7
//3 4 5
//6 7 8
//4