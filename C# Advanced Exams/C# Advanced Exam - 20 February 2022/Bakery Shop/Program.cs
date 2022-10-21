using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            Dictionary<string, int> bakeProducts = new Dictionary<string, int>();

            double[] flourArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();

            Queue<double> waterQueue = new Queue<double>(waterArray);
            Stack<double> flourStack = new Stack<double>(flourArray);
            while (waterQueue.Count > 0 && flourStack.Count > 0)
            {
                string productToBake = string.Empty;
                double currentWaterProportion = waterQueue.Dequeue();
                double currentFlourProportion = flourStack.Pop();
                double result = currentWaterProportion + currentFlourProportion;
                double waterPerenct = (currentWaterProportion * 100) / result;
                double flourPerenct = (currentFlourProportion * 100) / result;
                if (waterPerenct == 40 && flourPerenct == 60)
                {
                    productToBake = "Muffin";
                    if (!bakeProducts.ContainsKey(productToBake))
                    {
                        bakeProducts[productToBake] = 0;
                    }
                    bakeProducts[productToBake]++;
                }
                else if (waterPerenct == 30 && flourPerenct == 70)
                {
                    productToBake = "Baguette";
                    if (!bakeProducts.ContainsKey(productToBake))
                    {
                        bakeProducts[productToBake] = 0;
                    }
                    bakeProducts[productToBake]++;
                }
                else if (waterPerenct == 20 && flourPerenct == 80)
                {
                    productToBake = "Bagel";
                    if (!bakeProducts.ContainsKey(productToBake))
                    {
                        bakeProducts[productToBake] = 0;
                    }
                    bakeProducts[productToBake]++;
                }
                else
                {
                    if (flourPerenct!=50||waterPerenct!=50)
                    {
                        double difference = currentFlourProportion - currentWaterProportion;
                        currentFlourProportion -= difference;
                        double result2 = currentFlourProportion + currentWaterProportion;
                        double waterNewPercent = (currentWaterProportion * 100) / result2;
                        double flourNewPercent = (currentFlourProportion * 100) / result2;
                        flourStack.Push(difference);
                        productToBake = "Croissant";
                        if (!bakeProducts.ContainsKey(productToBake))
                        {
                            bakeProducts[productToBake] = 0;
                        }
                        bakeProducts[productToBake]++;
                    }
                    if (waterPerenct == 50 && flourPerenct == 50)
                    {
                        productToBake = "Croissant";
                        if (!bakeProducts.ContainsKey(productToBake))
                        {
                            bakeProducts[productToBake] = 0;
                        }
                        bakeProducts[productToBake]++;
                    }
                }
            }
            PrintResult(bakeProducts, waterQueue, flourStack);
        }

        static void PrintResult(Dictionary<string, int> bakeProducts, Queue<double> waterQueue, Stack<double> flourStack)
        {
            foreach (KeyValuePair<string,int> products in bakeProducts.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{products.Key}: {products.Value}");
            }
            if (waterQueue.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ",waterQueue)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flourStack.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ",flourStack)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
