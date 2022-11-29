using System;

namespace Composite.Models
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) : base(name, price) { }

        public override int CalculatePrice()
        {
            Console.WriteLine($"{name} has the following price: {price}$");
            return price;
        }
    }
}
