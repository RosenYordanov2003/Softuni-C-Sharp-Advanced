using InfernoInfinity.CustomAttributes;

namespace InfernoInfinity.Weapons.Models
{
    using System.Collections.Generic;
    using InfernoInfinity.Gems.Contracts;
    using Contracts;
    [Custom]
    public abstract class Weapon : IWeapon, IStats
    {
        private Dictionary<string, int> weaponTypeIncreasement = new Dictionary<string, int>
        {
            {"Common",1},
            {"Uncommon",2},
            {"Rare",3},
            {"Epic",5}
        };
        protected Weapon(string commonType, string name, int minDamage, int maxDamage)
        {
            CommonType = commonType;
            Name = name;
            MinDamage = minDamage * weaponTypeIncreasement[CommonType];
            MaxDamage = maxDamage * weaponTypeIncreasement[CommonType];
            Strength = 0;
            Agility = 0;
            Vitality = 0;
        }
        public string CommonType { get; protected set; }
        public string Name { get; protected set; }
        public int MinDamage { get; protected set; }
        public int MaxDamage { get; protected set; }
        public IGem[] Sockets { get; protected set; }
        public int Strength { get; protected set; }
        public int Agility { get; protected set; }
        public int Vitality { get; protected set; }
        public void AddGem(int socketIndex, IGem gem)
        {
            if (IsValidIndex(socketIndex))
            {
                if (Sockets[socketIndex] == null)
                {
                    Sockets[socketIndex] = gem;
                    InCreaseStats(gem);
                }
                else
                {
                    IGem previousGem = this.Sockets[socketIndex];
                    RemovePreviousGemStats(previousGem);
                    InCreaseStats(gem);
                }
            }
        }


        public void RemoveGem(int socketIndex)
        {
            if (IsValidIndex(socketIndex))
            {
                if (this.Sockets[socketIndex] != null)
                {
                    IGem previousGem = this.Sockets[socketIndex];
                    RemovePreviousGemStats(previousGem);
                    this.Sockets[socketIndex] = null;
                }
            }
        }

        private bool IsValidIndex(int socketIndex)
        {
            return socketIndex >= 0 && socketIndex < Sockets.Length;
        }
        private void InCreaseStats(IGem gem)
        {
            this.Strength += gem.StrengthIncreasemet;
            this.Agility += gem.AgilityIncreasement;
            this.Vitality += gem.VitalityIncreasement;
            //Add Strength to damage
            this.MinDamage += gem.StrengthIncreasemet * 2;
            this.MaxDamage += gem.StrengthIncreasemet * 3;
            // Add Agility to damage
            this.MinDamage += gem.AgilityIncreasement;
            this.MaxDamage += gem.AgilityIncreasement * 4;
        }

        private void RemovePreviousGemStats(IGem previousGem)
        {
            this.Strength -= previousGem.StrengthIncreasemet;
            this.Agility -= previousGem.AgilityIncreasement;
            this.Vitality -= previousGem.VitalityIncreasement;
            this.MinDamage -= previousGem.StrengthIncreasemet * 2;
            this.MaxDamage -= previousGem.StrengthIncreasemet * 3;
            this.MinDamage -= previousGem.AgilityIncreasement;
            this.MaxDamage -= previousGem.AgilityIncreasement * 4;
        }

        public override string ToString()
        {
            return $"{Name}: {MinDamage}-{MaxDamage} Damage, +{Strength} Strength, +{Agility} Agility, +{Vitality} Vitality";
        }
    }
}
