namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Items;
    using Constants;
    public abstract class Bag : IBag
    {
        protected Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }
        private List<Item> items;
        public int Capacity { get; set; };
        public int Load => items.Select(i => i.Weight).Sum();
        public IReadOnlyCollection<Item> Items => items;
        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!items.Any(i => i.GetType().Name == name))

            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            Item item = items.First(i => i.GetType().Name == name);
            items.Remove(item);
            return item;
        }
    }
}
