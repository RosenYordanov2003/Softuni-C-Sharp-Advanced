namespace Formula1.Models
{
    using System;
    using Contracts;
    using Utilities;
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private bool canRace;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            FullName = fullName;
            canRace = false;
            numberOfWins = 0;
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get { return this.car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                this.car = value;
            }
        }

        public int NumberOfWins
        {
            get { return this.numberOfWins; }
            private set { numberOfWins = value; }
        }

        public bool CanRace
        {
            get { return this.canRace; }
            private set { this.canRace = value; }
        }
        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
