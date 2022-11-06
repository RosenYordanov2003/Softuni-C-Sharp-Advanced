namespace Vehicles.Models
{
    using Contracts;
    using System;
    using ExceptionMessages;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

       
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                if (value>tankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            protected set { this.fuelConsumption = value + this.FuelIncreasment; }
        }
        public double TankCapacity
        {
            get { return tankCapacity; }
            protected set { tankCapacity = value; }
        }
        public virtual double FuelIncreasment => 0;

        public  virtual string Drive(double distance)
        {
            if (this.FuelQuantity - this.FuelConsumption * distance >= 0)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            if (liters<=0)
            {
                throw new ArgumentException(ExceptionMessages.NEGATIVE_FUEL);
            }
            if (this.FuelQuantity+liters<tankCapacity)
            {
                this.FuelQuantity += liters;
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.INVALID_FUEAL_AMOUNT,liters));
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
