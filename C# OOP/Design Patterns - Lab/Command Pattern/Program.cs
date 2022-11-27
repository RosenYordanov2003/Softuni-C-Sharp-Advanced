using System;
using Command_Pattern.Eums;
using Command_Pattern.Models;
using Command_Pattern.Models.Contracts;

namespace Command_Pattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            ModifyPrice modify = new ModifyPrice();
            Product product = new Product("IPhone", 2500);
            Execute(product, modify, new ProductCommand(product, PriceAction.Increase, 450));
            Execute(product, modify, new ProductCommand(product, PriceAction.Decrease, 127));
            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommand(command);
            modifyPrice.Invoke();
        }
    }
}
