namespace WarCroft.Entities.Characters
{
    using System;
    using Contracts;
    using Inventory;
    using Constants;

    public class Warrior : Character, IAttacker
    {
        private const int InitialBaseHealth = 100;
        private const int InitialBaseArmour = 50;
        private const int InitialAbilityPoints = 40;
        public Warrior(string name) : base(name, InitialBaseHealth, InitialBaseArmour, InitialAbilityPoints, new Satchel()) { }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
            character.TakeDamage(AbilityPoints);
        }
    }
}
