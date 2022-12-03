namespace WarCroft.Entities.Characters.Contracts
{
    using System;
    using Constants;
    using Inventory;
    using Items;
    public abstract class Character
    {
        private string name;

        private double baseHealth;

        private double health;

        private double _armor;

        private double _baseArmor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            BaseHealth = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            IsAlive = true;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        public double BaseHealth
        {
            get => baseHealth;
            private set => baseHealth = value;
        }

        public double Health
        {
            get => health;
            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double BaseArmor
        {
            get => _baseArmor;
            private set => _baseArmor = value;
        }

        public double Armor
        {
            get => _armor;
            set
            {
                if (value > _baseArmor)
                {
                    _armor = _baseArmor;
                }
                if (value < 0)
                {
                    _armor = 0;
                }
                else
                {
                    _armor = value;
                }
            }
        }
        public double AbilityPoints { get; set; }
        public bool IsAlive { get; set; }
        public Bag Bag { get; set; }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if (hitPoints > Armor)
            {
                hitPoints -= Armor;
                Armor = 0;
                Health -= hitPoints;
                if (Health <= 0)
                {
                    IsAlive = false;
                }
            }
            else
            {
                Armor -= hitPoints;
            }
        }
        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}