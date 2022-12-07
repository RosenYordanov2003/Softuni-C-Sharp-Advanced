namespace EasterRaces.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using Models.Drivers;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories.Contracts;
    using EasterRaces.Repositories.Entities;
    using Utilities.Messages;
    public class ChampionshipController : IChampionshipController
    {
        private const int RaceMinDriversCount = 3;

        private IRepository<IDriver> drivers;

        private IRepository<ICar> cars;

        private IRepository<IRace> races;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            cars = new CarRepository();
            races = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            drivers.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;
            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    cars.Add(car);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    cars.Add(car);
                    break;
            }
           return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            races.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (cars.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            IDriver driver = drivers.GetByName(driverName);
            ICar car = cars.GetByName(carModel);
            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, RaceMinDriversCount));
            }

            List<IDriver> topThreeDrivers =
                drivers.GetAll().OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            races.Remove(race);
            StringBuilder sb = new StringBuilder();
            IDriver winner = topThreeDrivers[0];
            winner.WinRace();
            sb.AppendLine($"Driver {topThreeDrivers[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {topThreeDrivers[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {topThreeDrivers[2].Name} is third in {race.Name} race.");
            return sb.ToString().Trim();
        }
    }
}
