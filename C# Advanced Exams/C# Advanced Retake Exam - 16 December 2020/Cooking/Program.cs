using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] liquidArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] ingredientsArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(liquidArray);
            Stack<int> stack = new Stack<int>(ingredientsArray);
            Dictionary<string, int> productsToCook = new Dictionary<string, int>();
            productsToCook["Bread"] = 25;
            productsToCook["Cake"] = 50;
            productsToCook["Pastry"] = 75;
            productsToCook["Fruit Pie"] = 100;
            Dictionary<string, int> currentCookedProducts = new Dictionary<string, int>();
            currentCookedProducts["Bread"] = 0;
            currentCookedProducts["Cake"] = 0;
            currentCookedProducts["Pastry"] = 0;
            currentCookedProducts["Fruit Pie"] = 0;
            while (queue.Any() && stack.Any())
            {
                int currentLiquid = queue.Dequeue();
                int currentIngredient = stack.Pop();
                int sum = currentIngredient + currentLiquid;
                KeyValuePair<string, int> cookedProduct = productsToCook.FirstOrDefault(x => x.Value == sum);
                if (cookedProduct.Key != null)
                {
                    currentCookedProducts[cookedProduct.Key]++;
                }
                else
                {
                    stack.Push(currentIngredient += 3);
                }
            }
            Dictionary<string, int> dictionary = currentCookedProducts.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
            string result = dictionary.Count == 4 ? "Wohoo! You succeeded in cooking all the food!" : "Ugh, what a pity! You didn't have enough materials to cook everything.";
            string liquidsResult = queue.Count == 0 ? "Liquids left: none" : $"Liquids left: {string.Join(", ", queue)}";
            string ingredientsResult = stack.Count == 0 ? "Ingredients left: none" : $"Ingredients left: {string.Join(", ", stack)}";
            Console.WriteLine($"{result}\n{liquidsResult}\n{ingredientsResult}");
            foreach (KeyValuePair<string,int> item in currentCookedProducts.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
