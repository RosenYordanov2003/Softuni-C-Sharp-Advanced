namespace Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }
        public string Name { get; private set; }
        public int Power { get; set; }
        public abstract string CastAbility();
    }
}
