namespace Vehicles.Factories
{
    using Models;
    public class Factory : IFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            return vehicle;
        }
    }
}
