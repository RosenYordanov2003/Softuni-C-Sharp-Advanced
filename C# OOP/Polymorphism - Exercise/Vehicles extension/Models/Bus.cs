using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_INCREASMENT = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelIncreasment => FUEL_INCREASMENT;
        public string DriveEmptyBus(double distance)
        {
            if (this.FuelQuantity - (this.FuelConsumption-FUEL_INCREASMENT) * distance >= 0)
            {
                this.FuelQuantity -= (this.FuelConsumption-FUEL_INCREASMENT) * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }
    }
}
