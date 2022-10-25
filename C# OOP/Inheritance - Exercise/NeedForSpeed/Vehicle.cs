using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
           this.HorsePower = horsePower;
           this.Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption => DefaultFuelConsumption;
        public virtual void Drive(double kilometers)
        {
            if (this.Fuel-(this.FuelConsumption*kilometers)>=0)
            {
                this.Fuel -= this.FuelConsumption * kilometers;
            }
        }
    }
}
