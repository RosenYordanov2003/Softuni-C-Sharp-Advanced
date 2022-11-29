namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double _InitialOxygen = 70;

        public Biologist(string name) : base(name, _InitialOxygen) { }
        public override void Breath()
        {
            this.Oxygen -= 5;
        }
    }
}
