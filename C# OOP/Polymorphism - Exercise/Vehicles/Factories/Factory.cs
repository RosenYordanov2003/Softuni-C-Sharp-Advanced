namespace Vehicles.Factories
{
    using Models;
    public class Factory : IFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else
            {
                vehicle = new Truck(fuelQuantity,fuelConsumption);
            }
            return vehicle;
        }
    }
}
