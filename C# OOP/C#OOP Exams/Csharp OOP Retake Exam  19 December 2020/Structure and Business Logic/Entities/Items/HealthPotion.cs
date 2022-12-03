namespace WarCroft.Entities.Items
{
    using Characters.Contracts;
    public class HealthPotion : Item
    {
        private const int InitialWeight = 5;
        public HealthPotion() : base(InitialWeight){}
        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;
        }
    }
}
