using Heroes.Models.Contracts;
using System;
namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Hero name cannot be null or empty.");
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Hero health cannot be below 0.");
                }
                else
                {
                    health = value;
                }
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Hero armour cannot be below 0.");
                }
                else
                {
                    armour = value;
                }
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new Exception("Weapon cannot be null.");
                }
                else
                {
                    weapon = value;
                }
            }
        }

        public bool IsAlive
        {
            get { return this.Health > 0; }
            private set { }
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int result = this.Armour - points;
            if (result <= 0)
            {
                this.Armour = 0;
                if (this.Health - Math.Abs(result) <= 0)
                {
                    this.IsAlive = false;
                    this.Health = 0;
                }
                else
                {
                    this.Health = this.Health - Math.Abs(result);
                }
            }
            else
            {
                this.Armour -= points;
            }
        }
    }
}
