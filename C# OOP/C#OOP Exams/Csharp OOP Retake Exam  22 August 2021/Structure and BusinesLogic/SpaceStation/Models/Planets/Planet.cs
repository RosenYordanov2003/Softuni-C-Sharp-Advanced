namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Utilities.Messages;
    public class Planet : IPlanet
    {
        private string _name;
        private List<string> _items;

        public Planet(string name)
        {
            Name = name;
            this._items = new List<string>();
        }

        public ICollection<string> Items=> _items;

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                this._name = value;
            }
        }
    }
}
