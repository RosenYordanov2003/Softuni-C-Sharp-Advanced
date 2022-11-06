using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_INCREASMENT = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }
        public override double FuelIncreasment => FUEL_INCREASMENT;
    } 
}
