using System.Text;

namespace CarRacing.Models.Racers
{
    using System;
    using CarRacing.Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private string userName;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        protected Racer(string userName, string racerBehavior, int drivingExperience, ICar car)
        {
            Username = userName;
            RacingBehavior = racerBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }
        public string Username
        {
            get {return userName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                userName = value;
            }
        }

        public string RacingBehavior
        {
            get { return racingBehavior; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get { return drivingExperience; }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperience = value;
            }
        }

        public ICar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                car = value;
            }
        }
        public virtual void Race()
        {
            Car.Drive();
        }
        public bool IsAvailable() => Car.FuelAvailable > Car.FuelConsumptionPerRace;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {Username}");
            sb.AppendLine($"--Driving behavior: {RacingBehavior}");
            sb.AppendLine($"--Driving experience: {DrivingExperience}");
            sb.AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");
            return sb.ToString().TrimEnd();
        }
    }
}
