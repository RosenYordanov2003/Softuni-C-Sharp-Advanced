namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const int _InitialOxygen = 90;
        public Meteorologist(string name) : base(name, _InitialOxygen){}
    }
}
