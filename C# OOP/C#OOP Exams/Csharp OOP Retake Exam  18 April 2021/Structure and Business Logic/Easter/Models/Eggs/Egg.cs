namespace Easter.Models.Eggs
{
    using System;
    using Contracts;
    using Utilities.Messages;
    public class Egg : IEgg
    {
        private string _name;
        private int _energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                _name = value;
            }
        }

        public int EnergyRequired
        {
            get { return _energyRequired; }
            private set
            {
                if (value < 0)
                {
                    _energyRequired = 0;
                }
                else
                {
                    _energyRequired = value;
                }
            }
        }
        public void GetColored()
        {
            EnergyRequired -= 10;
        }
        public bool IsDone() => EnergyRequired == 0;
    }
}
