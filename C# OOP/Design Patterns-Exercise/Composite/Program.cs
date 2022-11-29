using System;
using Composite.Models;

namespace Composite
{
    public class Program
    {
        static void Main(string[] args)
        {
            SingleGift gift = new SingleGift("IPhone", 1600);
            gift.CalculatePrice();
            SingleGift toy1 = new SingleGift("Truck", 30);
            toy1.CalculatePrice();
            SingleGift toy2 = new SingleGift("Airplane", 99);
            toy2.CalculatePrice();
            CompositeGift compositeGiftBox = new CompositeGift("Mystery box", 0);
            int boxSum1 = compositeGiftBox.CalculatePrice();
            compositeGiftBox.Add(gift);
            compositeGiftBox.Add(toy1);
            compositeGiftBox.Add(toy2);
            int boxSum2 = compositeGiftBox.CalculatePrice();
            Console.WriteLine(boxSum2);
        }
    }
}
