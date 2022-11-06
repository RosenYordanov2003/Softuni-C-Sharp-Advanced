namespace Vehicles.Models.Contracts
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get;}
        string Drive(double distance);
        void Refuel(double liters);
    }
}
