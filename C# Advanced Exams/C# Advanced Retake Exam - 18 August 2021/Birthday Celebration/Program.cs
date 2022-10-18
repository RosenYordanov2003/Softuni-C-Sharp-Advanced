using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_Advanced_Retake_Exam__18_August_2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[] foodPlates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Queue<int> queue = new Queue<int>(guests);
            Stack<int> stack = new Stack<int>(foodPlates);
            int wastedFood = 0;
            while (stack.Any() && queue.Any())
            {
                int currentGramsFood = stack.Pop();
                int currentGuest = queue.Peek();
                if (currentGramsFood >= currentGuest)
                {
                    currentGramsFood -= currentGuest;
                    wastedFood += currentGramsFood;
                    queue.Dequeue();
                }
                else if (currentGramsFood < currentGuest)
                {
                    currentGuest -= currentGramsFood;
                    bool isRemoved = false;
                    while (currentGuest > 0 && stack.Any())
                    {
                        int currentFood = stack.Pop();
                        if (currentFood >= currentGuest)
                        {
                            wastedFood += Math.Abs(currentGuest -= currentFood);
                            isRemoved = true;
                            break;
                        }
                        else
                        {
                            currentGuest -= currentFood;
                        }
                    }
                    if (isRemoved)
                    {
                        queue.Dequeue();
                    }
                }
            }
            PrintResult(queue, stack, wastedFood);
        }

        static void PrintResult(Queue<int> queue, Stack<int> stack, int wastedFood)
        {
            if (queue.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ",queue)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(" ",stack)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
