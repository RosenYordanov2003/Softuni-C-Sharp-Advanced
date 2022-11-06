namespace Vehicles.Models
{
    using System;
    using ExceptionMessages;
    public class Truck : Vehicle
    {
        private const double FUEL_INCREASMENT = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity) : base(fuelQuantity, fuelConsumption,tankCapacity)
        {
        }
        public override double FuelIncreasment => FUEL_INCREASMENT;
        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(ExceptionMessages.NEGATIVE_FUEL);
            }
            if (FuelQuantity + liters * 0.95 <= TankCapacity)
            {
                this.FuelQuantity += liters * 0.95;
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.INVALID_FUEAL_AMOUNT, liters));
            }
        }
    }
}
