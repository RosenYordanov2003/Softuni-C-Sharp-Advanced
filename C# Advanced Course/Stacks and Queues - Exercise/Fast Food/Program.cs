using System;
using System.Linq;
using System.Collections.Generic;
namespace Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalFoodForTheDay = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(' ').Select(order => int.Parse(order)).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            int theBiggestOrder = queue.Max();
            bool isOrderComplete = true;
            while (queue.Count != 0)
            {
                int currentOrder = queue.Peek();
                if (totalFoodForTheDay - currentOrder >= 0)
                {
                    totalFoodForTheDay -= currentOrder;
                    queue.Dequeue();
                    continue;
                }
                else
                {
                    isOrderComplete = false;
                    break;
                }
            }
            Console.WriteLine(theBiggestOrder);
            if (isOrderComplete)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
