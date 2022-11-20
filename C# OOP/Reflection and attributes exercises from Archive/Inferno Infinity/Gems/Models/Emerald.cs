namespace InfernoInfinity.Gems.Models
{
    public class Emerald : Gem
    {
        private const int EmeraldStrength = 1;
        private const int EmeraldAgility = 4;
        private const int EmeraldVitality = 9;
        public Emerald(string gemType) : base(gemType, EmeraldStrength, EmeraldAgility, EmeraldVitality) {}
    }
}
