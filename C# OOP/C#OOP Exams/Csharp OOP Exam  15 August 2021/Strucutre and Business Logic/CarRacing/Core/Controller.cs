using System;
using System.Linq;
using System.Reflection;
using System.Text;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Core
{
    using Contracts;
    public class Controller : IController
    {
        private IRepository<ICar> cars;
        private IRepository<IRacer> racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (!IsValidCarType(type))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            ICar car = CreateCar(type, make, model, VIN, horsePower);
            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            else if (!IsValidRacerType(type))
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            IRacer racer = CreateRacer(type, username, car);
            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);
            if (racerOne == null || racerTwo == null)
            {
                string userName = string.Empty;
                if (racerOne == null)
                {
                    userName = racerOneUsername;
                }
                else
                {
                    userName = racerTwoUsername;
                }
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound,userName));
            }
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IRacer racer in racers.Models.OrderByDescending(r=>r.DrivingExperience).ThenBy(r=>r.Username))
            {
                sb.AppendLine(racer.ToString());
               // sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }


        private bool IsValidCarType(string type)
        {
            Type typeToFind = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Car)).FirstOrDefault(t => t.Name == type);
            if (typeToFind == null)
            {
                return false;
            }
            return true;
        }
        private ICar CreateCar(string type, string make, string model, string vin, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, vin, horsePower);
            }
            else
            {
                car = new TunedCar(make, model, vin, horsePower);
            }

            return car;
        }

        private bool IsValidRacerType(string type)
        {
            Type racerType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Racer))
                .FirstOrDefault(t => t.Name == type);
            if (racerType == null)
            {
                return false;
            }
            return true;
        }

        private IRacer CreateRacer(string type, string userName, ICar car)
        {
            IRacer racer;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(userName, car);
            }
            else
            {
                racer = new StreetRacer(userName, car);
            }
            return racer;
        }
    }
}
