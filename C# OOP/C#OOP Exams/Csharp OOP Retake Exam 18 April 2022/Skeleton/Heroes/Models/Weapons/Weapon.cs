using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        protected Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Weapon type cannot be null or empty.");
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Durability
        {
            get { return durability; }
            protected set
            {
                if (value < 0)
                {
                    throw new Exception("Durability cannot be below 0.");
                }
                else
                {
                    durability = value;
                }
            }
        }
        public abstract int DoDamage();
    }
}
