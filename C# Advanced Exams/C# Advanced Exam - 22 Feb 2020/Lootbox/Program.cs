using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBoxArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondLootBoxArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> firstBoxLoot = new Queue<int>(firstLootBoxArray);
            Stack<int> secondBoxLoot = new Stack<int>(secondLootBoxArray);
            List<int> list = new List<int>();
            while (firstBoxLoot.Any() && secondBoxLoot.Any())
            {
                int currentNumberFromFirstBox = firstBoxLoot.Peek();
                int currentNumberFromSecondBox = secondBoxLoot.Pop();
                int sum = currentNumberFromFirstBox + currentNumberFromSecondBox;
                if (sum % 2 == 0)
                {
                    list.Add(sum);
                    firstBoxLoot.Dequeue();
                }
                else
                {
                    firstBoxLoot.Enqueue(currentNumberFromSecondBox);
                }
            }
            PrintResult(firstBoxLoot, secondBoxLoot, list);
        }

        static void PrintResult(Queue<int> firstBoxLoot, Stack<int> secondBoxLoot, List<int> list)
        {
            if (!firstBoxLoot.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            int itemsSum = list.Sum();
            if (itemsSum>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {itemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {itemsSum}");
            }
        }
    }
}
