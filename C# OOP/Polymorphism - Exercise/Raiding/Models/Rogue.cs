namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name,80)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
