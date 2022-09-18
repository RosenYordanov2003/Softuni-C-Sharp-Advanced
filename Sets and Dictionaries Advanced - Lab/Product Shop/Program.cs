using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,double>> shops = new Dictionary<string,Dictionary<string,double>>();
            string command;
            while ((command=Console.ReadLine())!="Revision")
            {
                string[] tokens = command.Split(new char[] {' ',','},StringSplitOptions.RemoveEmptyEntries);
                string shop=tokens[0];
                string product=tokens[1];
                double price=double.Parse(tokens[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }
                shops[shop].Add(product, price);
            }
            shops=shops.OrderBy(x=>x.Key).ToDictionary(x=>x.Key,x=>x.Value);
            foreach (KeyValuePair<string,Dictionary<string,double>> shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (KeyValuePair<string,double> product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
