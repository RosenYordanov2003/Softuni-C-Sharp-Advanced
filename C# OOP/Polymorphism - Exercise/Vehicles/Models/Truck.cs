using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_INCREASMENT = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelIncreasment => FUEL_INCREASMENT;
        public override void Refuel(double liters)
        {
            base.Refuel(liters - (liters * 5) / 100);
        }
    }
}
