namespace InfernoInfinity.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Repositories.Contracts;
    using Weapons.Contracts;
    using Gems.Contracts;
    using System.Reflection;
    using Gems.Models;
    using Weapons.Models;

    public class Engine : IEngine
    {
        private IRepository repository;

        public Engine(IRepository repository)
        {
            this.repository = repository;
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (true)
            {
                if (command == "END")
                {
                    break;
                }
                string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Create")
                {
                    CreateWeaponMethod(tokens, repository);
                }
                else if (action == "Add")
                {
                    AddMethod(tokens, repository);
                }
                else if (action == "Remove")
                {
                    IWeapon weapon = repository.FindByName(tokens[1]);
                    if (weapon != null)
                    {
                        weapon.RemoveGem(int.Parse(tokens[2]));
                    }
                }
                else if (action == "Print")
                {
                    IWeapon weaponToPrint = repository.FindByName(tokens[1]);
                    if (weaponToPrint != null)
                    {
                        Console.WriteLine(weaponToPrint);
                    }
                }
                command = Console.ReadLine();
            }
        }
        private static void CreateWeaponMethod(string[] tokens, IRepository repository)
        {
            string weaponInfoTokens = tokens[1];

            string[] weaponInfo = weaponInfoTokens.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string weaponType = weaponInfo[0];
            string type = weaponInfo[1];
            IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Weapon));
            foreach (Type itemType in types)
            {
                if (itemType.Name == type)
                {
                    IWeapon instance = (IWeapon)Activator.CreateInstance(itemType, new object[] { weaponType, tokens[2] });
                    repository.Add(instance);
                    break;
                }
            }
        }
        private static void AddMethod(string[] tokens, IRepository repository)
        {
            string weaponName = tokens[1];
            int index = int.Parse(tokens[2]);
            string gemInfo = tokens[3];
            string[] gemSplittedInfo = gemInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string gemType = gemSplittedInfo[0];
            string gem = gemSplittedInfo[1];
            IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Gem)).ToArray();
            foreach (Type type in types)
            {
                if (type.Name == gem)
                {
                    IGem gemInstance = (IGem)Activator.CreateInstance(type, new object[] { gemType });
                    IWeapon weapon = repository.FindByName(weaponName);
                    weapon.AddGem(index, gemInstance);
                    break;
                }
            }
        }
    }
}
