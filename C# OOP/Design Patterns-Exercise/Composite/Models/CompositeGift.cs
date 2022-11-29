using System;

namespace Composite.Models
{
    using System.Collections.Generic;
    using Contracts;
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> _gifts;

        public CompositeGift(string name, int price) : base(name, price)
        {
            _gifts = new List<GiftBase>();
        }

        public override int CalculatePrice()
        {
            int totalPrice = 0;
            string result = this._gifts.Count > 0
                ? $"{name} contains the following products with prices:"
                : "There are no products";
            Console.WriteLine(result);
            foreach (GiftBase gift in this._gifts)
            {
                totalPrice += gift.CalculatePrice();
            }
            return totalPrice;
        }

        public void Add(GiftBase gift)
        {
            this._gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this._gifts.Remove(gift);
        }
    }
}
