namespace SpaceStation.Models.Astronauts
{
    public class Geodesist:Astronaut
    {
        private const int _InitialOxygen = 50;

        public Geodesist(string name) : base(name, _InitialOxygen) {}
    }
}
