using System;
using System.Linq;
using System.Collections.Generic;
namespace Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split(' ').Select(cup => int.Parse(cup)).ToArray();

            int[] bottlesCapacity = Console.ReadLine().Split(' ').Select(bottle => int.Parse(bottle)).ToArray();

            Stack<int> stack = new Stack<int>(bottlesCapacity);
            int wastedWater = 0;
            Queue<int> queue = new Queue<int>(cupsCapacity);
            while (stack.Count > 0 && queue.Count > 0)
            {
                int currentWaterLiters = stack.Pop();
                int currentCup = queue.Peek();
                if (currentWaterLiters >= currentCup)
                {
                    queue.Dequeue();
                    wastedWater += currentWaterLiters - currentCup;
                }
                else if (currentWaterLiters<currentCup)
                {
                    currentCup -= currentWaterLiters;
                    while (currentCup>0)
                    {
                        int currentWater = stack.Pop();
                        if (currentWater >= currentCup)
                        {
                            queue.Dequeue();
                            wastedWater+=currentWater-currentCup;
                            currentCup -= currentWater;
                        }
                        else
                        {
                            currentCup-=currentWater;
                        }
                    }
                }
            }
            if (stack.Count==0)
            {
                Console.WriteLine($"Cups: {string.Join(" ",queue)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stack)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
