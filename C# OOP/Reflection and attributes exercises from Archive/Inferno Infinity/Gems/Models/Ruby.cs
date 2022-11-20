namespace InfernoInfinity.Gems.Models
{
    public class Ruby : Gem
    {
        private const int RubyStrength = 7;
        private const int RubyAgility = 2;
        private const int RubyVitality = 5;

        public Ruby(string gemType) : base(gemType, RubyStrength, RubyAgility, RubyVitality){}
    }
}
