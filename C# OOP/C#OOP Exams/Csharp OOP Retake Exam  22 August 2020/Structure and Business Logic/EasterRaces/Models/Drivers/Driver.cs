namespace EasterRaces.Models.Drivers
{
    using System;
    using EasterRaces.Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;

    public class Driver : IDriver
    {
        private string name;

        private const int NameMinSymbols = 5;

        private ICar car;

        private int numberOfWins;

        private bool canPractice;

        public Driver(string name)
        {
            Name = name;
            canPractice = false;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, NameMinSymbols));
                }
                name = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set => car = value;
        }

        public int NumberOfWins
        {
            get => numberOfWins;
            private set => numberOfWins = value;
        }

        public bool CanParticipate
        {
            get => canPractice;
            private set => canPractice = value;
        }
        public void WinRace()
        {
            this.numberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            this.car = car;
            canPractice = true;
        }
    }
}
