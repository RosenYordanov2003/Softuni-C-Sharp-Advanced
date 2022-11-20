namespace InfernoInfinity.Gems.Models
{
    using System.Collections.Generic;
    using Contracts;
    public abstract class Gem : IGem
    {
        private Dictionary<string, int> gemIncreasment = new Dictionary<string, int>
        {
            {"Chipped",1},
            {"Regular",2},
            {"Perfect",5},
            {"Flawless",10}
        };
        protected Gem(string gemType, int strengthIncreasemet, int agilityIncreasement, int vitalityIncreasement)
        {
            GemType = gemType;
            StrengthIncreasemet = strengthIncreasemet + gemIncreasment[gemType];
            AgilityIncreasement = agilityIncreasement + gemIncreasment[gemType];
            VitalityIncreasement = vitalityIncreasement + gemIncreasment[gemType];
        }
        public string GemType { get; }
        public int StrengthIncreasemet { get; }
        public int AgilityIncreasement { get; }
        public int VitalityIncreasement { get; }
    }
}
