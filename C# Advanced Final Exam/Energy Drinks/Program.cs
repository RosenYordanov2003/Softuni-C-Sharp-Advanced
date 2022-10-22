using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MaxCoffein = 300;
            int currentCoffein = 0;
            int[] coffeinArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] drinksArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(coffeinArray);
            Queue<int> queue = new Queue<int>(drinksArray);
            while (queue.Any() && stack.Any())
            {
                int currentCofein = stack.Pop();
                int currentEnergyDrink = queue.Dequeue();
                int sum = currentCofein * currentEnergyDrink;
                if (sum + currentCoffein <= MaxCoffein)
                {
                    currentCoffein += sum;
                }
                else
                {
                    queue.Enqueue(currentEnergyDrink);
                    if (currentCoffein - 30 > 0)
                    {
                        currentCoffein -= 30;
                    }
                }
            }
            string drinksResult = queue.Count == 0 ? "At least Stamat wasn't exceeding the maximum caffeine." : $"Drinks left: {string.Join(", ", queue)}";
            Console.WriteLine(drinksResult);
            Console.WriteLine($"Stamat is going to sleep with {currentCoffein} mg caffeine.");
        }
    }
}
