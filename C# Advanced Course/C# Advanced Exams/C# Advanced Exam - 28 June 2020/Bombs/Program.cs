using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bombCasing = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(bombEffectArray);
            Stack<int> stack = new Stack<int>(bombCasing);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary["Cherry Bombs"] = 0;
            dictionary["Smoke Decoy Bombs"] = 0;
            dictionary["Datura Bombs"] = 0;
            bool isEnoughBombs = false;
            while (queue.Any() && stack.Any())
            {
                Dictionary<string, int> currentDictionary = dictionary.Where(x => x.Value >= 3).ToDictionary(x => x.Key, x => x.Value);
                if (currentDictionary.Count == 3)
                {
                    isEnoughBombs = true;
                    break;
                }
                string currentBomb = string.Empty;
                int currentBombeffect = queue.Peek();
                int currentCasing = stack.Pop();
                int sum = currentBombeffect + currentCasing;
                if (sum == 60)
                {
                    currentBomb = "Cherry Bombs";
                    dictionary[currentBomb]++;
                    queue.Dequeue();
                }
                else if (sum == 120)
                {
                    currentBomb = "Smoke Decoy Bombs";
                    dictionary[currentBomb]++;
                    queue.Dequeue();
                }
                else if (sum == 40)
                {
                    currentBomb = "Datura Bombs";
                    dictionary[currentBomb]++;
                    queue.Dequeue();
                }
                else
                {
                    stack.Push(currentCasing -= 5);
                }
            }
            string result = isEnoughBombs == true ? "Bene! You have successfully filled the bomb pouch!" : "You don't have enough materials to fill the bomb pouch.";
            Console.WriteLine(result);
            string bombEffectResult = queue.Count == 0 ? "Bomb Effects: empty" : $"Bomb Effects: {string.Join(", ", queue)}";
            Console.WriteLine(bombEffectResult);
            string bombCasingResult = stack.Count == 0 ? "Bomb Casings: empty" : $"Bomb Casings: {string.Join(", ", stack)}";
            Console.WriteLine(bombCasingResult);
            foreach (KeyValuePair<string, int> item in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
