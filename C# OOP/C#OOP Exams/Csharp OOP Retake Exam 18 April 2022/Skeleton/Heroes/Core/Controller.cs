using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using System.Xml.Linq;
using Heroes.Models.Map;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            IWeapon weapon = this.weapons.FindByName(weaponName);
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            else
            {
                hero.AddWeapon(weapon);
                return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
            }
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            else if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            else
            {
                if (type == "Barbarian")
                {
                    IHero hero = new Barbarian(name, health, armour);
                    this.heroes.Add(hero);
                    return $"Successfully added Barbarian {name} to the collection.";
                }
                else
                {
                    IHero hero = new Knight(name, health, armour);
                    this.heroes.Add(hero);
                    return $"Successfully added Sir {name} to the collection.";
                }
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            else if (type != "Claymore" && type != "Mace")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
            else
            {
                IWeapon weapon = null;
                if (type == "Mace")
                {
                    weapon = new Mace(name, durability);
                }
                else
                {
                    weapon = new Claymore(name, durability);
                }
                this.weapons.Add(weapon);
                return $"A {type.ToLower()} {name} is added to the collection.";
            }
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IHero hero in this.heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon!=null)
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
                else
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
            }
            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            List<IHero> heroesToFight = this.heroes.Models.Where(x=>x.IsAlive==true&&x.Weapon!=null).ToList();
            return map.Fight(heroesToFight);
        }

    }
}
