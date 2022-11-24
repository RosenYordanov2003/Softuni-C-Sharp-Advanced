using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IFormulaOneCar> carRepository;
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;

        public Controller()
        {
            this.carRepository = new FormulaOneCarRepository();
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
        }
        public string CreatePilot(string fullName)
        {
            IPilot pilotToAdd = this.pilotRepository.FindByName(fullName);
            if (pilotToAdd != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            this.pilotRepository.Add(new Pilot(fullName));
            return $"Pilot {fullName} is created.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = carRepository.FindByName(model);
            if (car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            //else if (!IsValidTypeCar(type))
            //{
            //    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            //}
            car = CreateCarInstance(type, model, horsepower, engineDisplacement);
            this.carRepository.Add(car);
            return $"Car {car.GetType().Name}, model {car.Model} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            this.raceRepository.Add(new Race(raceName, numberOfLaps));
            return $"Race {raceName} is created.";
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilotToFind = this.pilotRepository.FindByName(pilotName);
            IFormulaOneCar carToFind = this.carRepository.FindByName(carModel);
            if (pilotToFind == null || pilotToFind.Car != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (carToFind == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage,
                    carModel));
            }
            pilotToFind.AddCar(carToFind);
            this.carRepository.Remove(carToFind);
            return $"Pilot {pilotToFind.FullName} will drive a {carToFind.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace raceToFind = this.raceRepository.FindByName(raceName);
            IPilot pilotToFind = this.pilotRepository.FindByName(pilotFullName);

            if (raceToFind == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else if (pilotToFind == null || pilotToFind.CanRace == false || raceToFind.Pilots.Contains(pilotToFind))
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            raceToFind.AddPilot(pilotToFind);
            return $"Pilot {pilotToFind.FullName} is added to the {raceToFind.RaceName} race.";
        }

        public string StartRace(string raceName)
        {
            IRace raceToFind = this.raceRepository.FindByName(raceName);
            if (raceToFind == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else if (raceToFind.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            else if (raceToFind.TookPlace)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            List<IPilot> topThreePilots = raceToFind.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(raceToFind.NumberOfLaps)).Take(3).ToList();

            raceToFind.TookPlace = true;
            topThreePilots[0].WinRace();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {topThreePilots[0].FullName} wins the {raceToFind.RaceName} race.");
            sb.AppendLine($"Pilot {topThreePilots[1].FullName} is second in the {raceToFind.RaceName} race.");
            sb.AppendLine($"Pilot {topThreePilots[2].FullName} is third in the {raceToFind.RaceName} race.");
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IRace race in this.raceRepository.Models.Where(r => r.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IPilot pilot in this.pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }



        //private bool IsValidTypeCar(string type)
        //{
        //    Type carType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(FormulaOneCar)).FirstOrDefault(t => t.Name == type);
        //    if (carType == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        private IFormulaOneCar CreateCarInstance(string type, string model, int horsepower, double engineDisplacement)
        {
            //Type carType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(FormulaOneCar))
            //    .FirstOrDefault(t => t.Name == type);
            //IFormulaOneCar car =
            //    (IFormulaOneCar)Activator.CreateInstance(carType, new object[] { model, horsepower, engineDisplacement });
            //return car;
            IFormulaOneCar car;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            return car;
        }
    }
}
