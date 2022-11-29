using SpaceStation.Models.Bags;

namespace SpaceStation.Models.Astronauts
{
    using System;
    using Contracts;
    using Bags.Contracts;
    using Utilities.Messages;
    public class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get { return this.oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }
        public bool CanBreath => this.Oxygen > 0;
        public IBag Bag => bag;
        public virtual void Breath()
        {
            this.Oxygen -= 10;
        }
    }
}