namespace WarCroft.Entities.Characters
{
    using Contracts;
    using Inventory;
    public class Priest : Character,IHealer
    {
        private const int InitialBaseHealth = 50;
        private const int InitialBaseArmour = 25;
        private const int InitialAbilityPoints = 40;
        public Priest(string name) : base(name, InitialBaseHealth, InitialBaseArmour, InitialAbilityPoints, new Backpack()){}

        public void Heal(Character character)
        {
            if (this.IsAlive&&character.IsAlive)
            {
                character.Health += AbilityPoints;
            }
        }
    }
}
