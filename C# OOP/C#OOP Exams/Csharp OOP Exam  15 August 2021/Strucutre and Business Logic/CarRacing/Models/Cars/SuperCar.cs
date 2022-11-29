namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double AvailableFuel = 80;
        private const double ConsumptionPerRace = 10;
        public SuperCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, AvailableFuel, ConsumptionPerRace)
        {
        }
    }
}
