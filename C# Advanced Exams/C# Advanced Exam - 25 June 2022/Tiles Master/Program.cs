using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTilesArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[] greyTilesArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Dictionary<string, int> areas = new Dictionary<string, int>();
            Queue<int> greyTilesQueue = new Queue<int>(greyTilesArray);
            Stack<int> whiteTilesStack = new Stack<int>(whiteTilesArray);
            while (greyTilesQueue.Any() && whiteTilesStack.Any())
            {
                string area = string.Empty;
                int currentgreyTile = greyTilesQueue.Dequeue();
                int curretWhiteTile = whiteTilesStack.Pop();
                if (currentgreyTile == curretWhiteTile)
                {
                    int totalTilesSum = currentgreyTile + curretWhiteTile;
                    if (totalTilesSum == 40)
                    {
                        area = "Sink";
                        if (!areas.ContainsKey(area))
                        {
                            areas[area] = 0;
                        }
                        areas[area]++;
                    }
                    else if (totalTilesSum == 50)
                    {
                        area = "Oven";
                        if (!areas.ContainsKey(area))
                        {
                            areas[area] = 0;
                        }
                        areas[area]++;
                    }
                    else if (totalTilesSum == 70)
                    {
                        area = "Wall";
                        if (!areas.ContainsKey(area))
                        {
                            areas[area] = 0;
                        }
                        areas[area]++;
                    }
                    else if (totalTilesSum == 60)
                    {
                        area = "Countertop";
                        if (!areas.ContainsKey(area))
                        {
                            areas[area] = 0;
                        }
                        areas[area]++;
                    }
                    else
                    {
                        area = "Floor";
                        if (!areas.ContainsKey(area))
                        {
                            areas[area] = 0;
                        }
                        areas[area]++;
                    }
                }
                else
                {
                    curretWhiteTile /= 2;
                    whiteTilesStack.Push(curretWhiteTile);
                    greyTilesQueue.Enqueue(currentgreyTile);
                }
            }
            PrintResult(whiteTilesStack, greyTilesQueue, areas);
        }

        static void PrintResult(Stack<int> whiteTilesStack, Queue<int> greyTilesQueue, Dictionary<string, int> areas)
        {
            if (whiteTilesStack.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTilesStack)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (greyTilesQueue.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ",greyTilesQueue)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }
            foreach (KeyValuePair<string,int> area in areas.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{area.Key}: {area.Value}");
            }
        }
    }
}
