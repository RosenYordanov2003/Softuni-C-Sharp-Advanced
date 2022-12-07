namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double DefaultCubicCentimeters = 3000;
        private const int MinHorsePower = 250;
        private const int MaxHorsePower = 450;
        public SportsCar(string model, int horsePower) : base(model, horsePower, DefaultCubicCentimeters, MinHorsePower, MaxHorsePower) {}

    }
}
