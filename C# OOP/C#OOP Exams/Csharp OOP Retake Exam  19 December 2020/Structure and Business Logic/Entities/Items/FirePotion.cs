namespace WarCroft.Entities.Items
{
    using Characters.Contracts;
    public class FirePotion : Item
    {
        private const int InitialWeight = 5;
        public FirePotion() : base(InitialWeight){}
        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;
            if (character.Health<=0)
            {
                character.IsAlive = false;
            }
        }
    }
}
