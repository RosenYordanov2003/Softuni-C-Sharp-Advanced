

namespace Vehicles.Factories
{
    using Models;
    interface IFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption);
    }
}
