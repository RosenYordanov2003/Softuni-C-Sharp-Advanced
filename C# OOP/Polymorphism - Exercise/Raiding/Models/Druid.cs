namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name, 80)
        {

        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {base.Name} healed for {base.Power}";
        }
    }
}
