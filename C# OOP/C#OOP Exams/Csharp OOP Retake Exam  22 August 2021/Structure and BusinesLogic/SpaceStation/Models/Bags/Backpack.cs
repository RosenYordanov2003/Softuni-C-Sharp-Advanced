namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;
    using Contracts;
    public class Backpack : IBag
    {
        private List<string> _items;

        public Backpack()
        {
            this._items = new List<string>();
        }
        public ICollection<string> Items => _items;
    }
}
