using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] levelsOfFresh = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(ingredients);
            Stack<int> stack = new Stack<int>(levelsOfFresh);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            while (stack.Any() && queue.Any())
            {
                string currentDish = string.Empty;
                int currentIngredient = queue.Dequeue();
                if (currentIngredient==0)
                {
                    continue;
                }
                int currentFreshLevel = stack.Pop();
                int sum = currentFreshLevel * currentIngredient;
                if (sum == 150)
                {
                    currentDish = "Dipping sauce";
                    if (!dictionary.ContainsKey(currentDish))
                    {
                        dictionary.Add(currentDish, 0);
                    }
                    dictionary[currentDish]++;
                }
                else if (sum == 250)
                {
                    currentDish = "Green salad";
                    if (!dictionary.ContainsKey(currentDish))
                    {
                        dictionary.Add(currentDish, 0);
                    }
                    dictionary[currentDish]++;
                }
                else if (sum == 300)
                {
                    currentDish = "Chocolate cake";
                    if (!dictionary.ContainsKey(currentDish))
                    {
                        dictionary.Add(currentDish, 0);
                    }
                    dictionary[currentDish]++;
                }
                else if (sum == 400)
                {
                    currentDish = "Lobster";
                    if (!dictionary.ContainsKey(currentDish))
                    {
                        dictionary.Add(currentDish, 0);
                    }
                    dictionary[currentDish]++;
                }
                else
                {
                    currentIngredient += 5;
                    queue.Enqueue(currentIngredient);
                }
            }
            PrintResult(queue, stack, dictionary);
        }

        static void PrintResult(Queue<int> queue, Stack<int> stack, Dictionary<string, int> dictionary)
        {
            if (dictionary.Count==4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes! ");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (queue.Any())
            {
                Console.WriteLine($"Ingredients left: {queue.Sum()}");
            }
            foreach (KeyValuePair<string,int> item in dictionary.Where(x=>x.Value>0).OrderBy(x=>x.Key))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}
