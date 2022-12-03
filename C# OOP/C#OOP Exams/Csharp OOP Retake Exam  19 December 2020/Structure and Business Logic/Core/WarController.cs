namespace WarCroft.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Constants;
    using Entities.Characters;
    using Entities.Characters.Contracts;
    using Entities.Items;
    public class WarController
    {
        private ICollection<Character> characters;
        private Stack<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            if (!ValidateType(args[0], typeof(Character)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            }

            Character character;
            if (args[0] == "Priest")
            {
                character = new Priest(args[1]);
            }
            else
            {
                character = new Warrior(args[1]);
            }
            characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, args[1]);
        }


        public string AddItemToPool(string[] args)
        {
            if (!ValidateType(args[0], typeof(Item)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, args[0]));
            }
            Item item;
            if (args[0] == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                item = new FirePotion();
            }
            items.Push(item);
            return string.Format(SuccessMessages.AddItemToPool, args[0]);
        }

        public string PickUpItem(string[] args)
        {
            Character character = characters.FirstOrDefault(c => c.Name == args[0]);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = items.Pop();
            character.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, args[0], item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            Character character = characters.FirstOrDefault(c => c.Name == args[0]);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            Item item = character.Bag.GetItem(args[1]);
            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem, args[0], args[1]);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Character character in characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                string result = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {result}");
            }
            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            Character character = characters.FirstOrDefault(c => c.Name == args[0]);
            if (character == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);
            }
            Character deffender = characters.FirstOrDefault(c => c.Name == args[1]);
            if (deffender == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[1]);
            }
            Warrior warrior = character as Warrior;
            if (warrior == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, args[0]));
            }

            warrior.Attack(deffender);
            string message = string.Format
                (SuccessMessages.AttackCharacter, warrior.Name, deffender.Name, warrior.AbilityPoints, deffender.Name, deffender.Health, deffender.BaseHealth, deffender.Armor, deffender.BaseArmor);
            if (!deffender.IsAlive)
            {
                string secondMessage = string.Format(SuccessMessages.AttackKillsCharacter, deffender.Name);
                return message + Environment.NewLine + secondMessage;
            }

            return message;
        }

        public string Heal(string[] args)
        {
            Character character = characters.FirstOrDefault(c => c.Name == args[0]);
            if (character == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);
            }

            Character receiver = characters.FirstOrDefault(c => c.Name == args[1]);
            if (receiver == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[1]);
            }
            Priest healer = character as Priest;
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }
            healer.Heal(receiver);
            return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints,
                receiver.Name, receiver.Health);
        }

        private bool ValidateType(string charType, Type type)
        {
            Type type1 = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == type)
                .FirstOrDefault(t => t.Name == charType);
            bool result = type1 == null ? false : true;
            return result;
        }
    }
}
