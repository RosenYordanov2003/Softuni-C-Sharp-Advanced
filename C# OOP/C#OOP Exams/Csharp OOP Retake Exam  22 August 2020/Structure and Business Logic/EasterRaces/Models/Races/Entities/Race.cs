using System;
using System.Collections.Generic;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;

        private int laps;

        private List<IDriver> drivers;

        private const int NameMinSymbols = 5;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
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

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfLaps);
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers;
        public void AddDriver(IDriver driver)
        {
            if (driver==null)
            {
                throw new ArgumentNullException( ExceptionMessages.DriverInvalid);
            }

            if (driver.Car==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Contains(driver))
            {
                throw new ArgumentNullException(
                    string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }
            drivers.Add(driver);
        }
    }
}
