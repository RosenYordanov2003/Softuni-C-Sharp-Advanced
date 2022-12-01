using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                else
                {
                    name = value;
                }
            }
        }

        public double Budget
        {
            get { return this.budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                else
                {
                    budget = value;
                }
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();


        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            if (units.Models.Count > 0)
            {
                List<string> list = new List<string>();
                foreach (IMilitaryUnit item in this.units.Models)
                {
                    list.Add(item.GetType().Name);
                }
                sb.AppendLine($"--Forces: {string.Join(", ", list)}");
            }
            else
            {
                sb.AppendLine("--Forces: No units");
            }
            if (weapons.Models.Count>0)
            {
                List<string> list = new List<string>();
                foreach (IWeapon item in this.weapons.Models)
                {
                    list.Add(item.GetType().Name);
                }
                sb.AppendLine($"--Combat equipment: {string.Join(", ", list)}");
            }
            else
            {
                sb.AppendLine("--Combat equipment: No weapons");
            }
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget-amount>=0)
            {
                this.Budget -= amount;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
        }

        public void TrainArmy()
        {
            foreach (IMilitaryUnit military in this.units.Models)
            {
                military.IncreaseEndurance();
            }
        }
        private double CalculateMilitaryPower()
        {
            double power = 0;
            power = this.Army.Sum(x => x.EnduranceLevel) + this.Weapons.Sum(x => x.DestructionLevel);
            if (this.units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                power = power + (power * 30) / 100;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                power = power + (power * 45) / 100;
            }
            return Math.Round(power, 3);
        }
    }
}
