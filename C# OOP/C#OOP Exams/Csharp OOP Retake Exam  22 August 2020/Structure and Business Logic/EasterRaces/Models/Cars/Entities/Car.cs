namespace EasterRaces.Models.Cars.Entities
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private string model;

        private double cubicCentimeters;

        private int horsePower;

        private int minHorsePower;

        private int maxHorsePower;

        private const int ModelMinimumSymbols = 4;
        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            HorsePower = horsePower;
        }
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, ModelMinimumSymbols));
                }
                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                horsePower = value;
            }
        }
        public double CubicCentimeters
        {
            get => cubicCentimeters;
            private set => cubicCentimeters = value;
        }
        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
