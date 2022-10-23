using System;
using System.Collections.Generic;
using System.Linq;

namespace Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> beverages = new Dictionary<string, int>();
            int[] coffeQuantities = Console.ReadLine().Split(", ").Select(x => int.Parse(x)).ToArray();
            int[] milkQuantities = Console.ReadLine().Split(", ").Select(x => int.Parse(x)).ToArray();
            Queue<int> coffeQueue = new Queue<int>(coffeQuantities);
            Stack<int> milkStack = new Stack<int>(milkQuantities);
            while (milkStack.Count > 0 && coffeQueue.Count > 0)
            {
                string currentBevarages = string.Empty;
                int currentCoffe = coffeQueue.Dequeue();
                int currentMilk = milkStack.Pop();
                int sum = currentCoffe + currentMilk;
                if (sum == 50)
                {
                    currentBevarages = "Cortado";
                    if (!beverages.ContainsKey(currentBevarages))
                    {
                        beverages[currentBevarages] = 0;
                    }
                    beverages[currentBevarages]++;
                }
                else if (sum == 75)
                {
                    currentBevarages = "Espresso";
                    if (!beverages.ContainsKey(currentBevarages))
                    {
                        beverages[currentBevarages] = 0;
                    }
                    beverages[currentBevarages]++;
                }
                else if (sum == 100)
                {
                    currentBevarages = "Capuccino";
                    if (!beverages.ContainsKey(currentBevarages))
                    {
                        beverages[currentBevarages] = 0;
                    }
                    beverages[currentBevarages]++;
                }
                else if (sum == 150)
                {
                    currentBevarages = "Americano";
                    if (!beverages.ContainsKey(currentBevarages))
                    {
                        beverages[currentBevarages] = 0;
                    }
                    beverages[currentBevarages]++;
                }
                else if (sum == 200)
                {
                    currentBevarages = "Latte";
                    if (!beverages.ContainsKey(currentBevarages))
                    {
                        beverages[currentBevarages] = 0;
                    }
                    beverages[currentBevarages]++;
                }
                else
                {
                    currentMilk -= 5;
                    milkStack.Push(currentMilk);
                }
            }
            PrintResult(beverages, milkStack, coffeQueue);
        }

        static void PrintResult(Dictionary<string, int> beverages, Stack<int> milkStack, Queue<int> coffeQueue)
        {
            if (milkStack.Any()||coffeQueue.Any())
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            if (coffeQueue.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ",coffeQueue)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }
            if (milkStack.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ",milkStack)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }
            foreach (KeyValuePair<string,int> bevarage in beverages.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key))
            {
                Console.WriteLine($"{bevarage.Key}: {bevarage.Value}");
            }
        }
    }
}
