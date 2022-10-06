using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> swords = new Dictionary<string, int>();
            swords.Add("Gladius", 0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0);
            swords.Add("Broadsword", 0);
            int[] steel = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] carbon = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(steel);
            Stack<int> stack = new Stack<int>(carbon);
            while (stack.Any() && queue.Any())
            {
                string swordToCraft = string.Empty;
                int currentSteel = queue.Dequeue();
                int currentCarbon = stack.Pop();
                int sum = currentCarbon + currentSteel;
                if (sum == 70)
                {
                    swordToCraft = "Gladius";
                    swords[swordToCraft]++;
                }
                else if (sum == 80)
                {
                    swordToCraft = "Shamshir";
                    swords[swordToCraft]++;
                }
                else if (sum == 90)
                {
                    swordToCraft = "Katana";
                    swords[swordToCraft]++;
                }
                else if (sum == 110)
                {
                    swordToCraft = "Sabre";
                    swords[swordToCraft]++;
                }
                else if (sum == 150)
                {
                    swordToCraft = "Broadsword";
                    swords[swordToCraft]++;

                }
                else
                {
                    currentCarbon += 5;
                    stack.Push(currentCarbon);
                }
            }
            PrintResult(swords, queue, stack);
        }

        static void PrintResult(Dictionary<string, int> swords, Queue<int> queue, Stack<int> stack)
        {
            int craftedSwordsCount = swords.Values.Sum();
            if (craftedSwordsCount!=0)
            {
                Console.WriteLine($"You have forged {craftedSwordsCount} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (queue.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ",queue)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (stack.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", stack)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            foreach (KeyValuePair<string,int> sword in swords.Where(x=>x.Value>0).OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
