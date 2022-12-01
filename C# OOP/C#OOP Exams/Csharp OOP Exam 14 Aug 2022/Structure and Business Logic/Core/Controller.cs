using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else
            {
                IMilitaryUnit unit = CreateUnit(unitTypeName);
                if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
                else
                {
                    planet.Spend(unit.Cost);
                    planet.AddUnit(unit);
                    return $"{unitTypeName} added successfully to the Army of {planetName}!";
                }
            }
        }


        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else
            {
                if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
                else
                {
                    IWeapon weapon = CraftWeapon(weaponTypeName, destructionLevel);
                    planet.Spend(weapon.Price);
                    planet.AddWeapon(weapon);
                    return $"{planetName} purchased {weaponTypeName}!";
                }
            }
        }


        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) == null)
            {
                IPlanet planet = new Planet(name, budget);
                this.planets.AddItem(planet);
                return $"Successfully added Planet: {name}";
            }
            else
            {
                return $"Planet {name} is already added!";
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (IPlanet planet in planets.Models.OrderByDescending(x=>x.MilitaryPower).ThenBy(x=>x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = this.planets.FindByName(planetOne);
            IPlanet secondPlanet = this.planets.FindByName(planetTwo);
            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && (!secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")))
                {
                    double firstPlanetBudget = firstPlanet.Budget;
                    firstPlanet.Spend(firstPlanetBudget / 2);
                    double losingPlanetBudgetBudget = secondPlanet.Budget;
                    firstPlanet.Profit(losingPlanetBudgetBudget / 2);
                    double weaponsBudget = secondPlanet.Weapons.Sum(x => x.Price);
                    double armyBudget = secondPlanet.Army.Sum(a => a.Cost);
                    firstPlanet.Profit(weaponsBudget + armyBudget);
                    this.planets.RemoveItem(secondPlanet.Name);
                    return $"{firstPlanet.Name} destructed {secondPlanet.Name}!";
                }
                else if (!firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && (secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")))
                {
                    double secondPlanetBudget = secondPlanet.Budget;
                    secondPlanet.Spend(secondPlanetBudget / 2);
                    double losingPlanetBudget = firstPlanet.Budget;
                    secondPlanet.Profit(losingPlanetBudget / 2);
                    double weaponsBudget = firstPlanet.Weapons.Sum(x => x.Price);
                    double armyBudget = firstPlanet.Army.Sum(a => a.Cost);
                    secondPlanet.Profit(weaponsBudget + armyBudget);
                    this.planets.RemoveItem(firstPlanet.Name);
                    return $"{secondPlanet.Name} destructed {firstPlanet.Name}!";
                }
                else if (firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    double firstPlanetBudget = firstPlanet.Budget;
                    double secondPlanetBudget = secondPlanet.Budget;
                    firstPlanet.Spend(firstPlanetBudget / 2);
                    secondPlanet.Spend(secondPlanetBudget / 2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else
                {
                    double firstPlanetBudget = firstPlanet.Budget;
                    double secondPlanetBudget = secondPlanet.Budget;
                    firstPlanet.Spend(firstPlanetBudget / 2);
                    secondPlanet.Spend(secondPlanetBudget / 2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                double firstPlanetBudget = firstPlanet.Budget;
                firstPlanet.Spend(firstPlanetBudget / 2);
                double losingPlanetBudgetBudget = secondPlanet.Budget;
                firstPlanet.Profit(losingPlanetBudgetBudget / 2);
                double weaponsBudget = secondPlanet.Weapons.Sum(x => x.Price);
                double armyBudget = secondPlanet.Army.Sum(a => a.Cost);
                firstPlanet.Profit(weaponsBudget + armyBudget);
                this.planets.RemoveItem(secondPlanet.Name);
                return $"{firstPlanet.Name} destructed {secondPlanet.Name}!";
            }
            else
            {
                double secondPlanetBudget = secondPlanet.Budget;
                secondPlanet.Spend(secondPlanetBudget / 2);
                double losingPlanetBudget = firstPlanet.Budget;
                secondPlanet.Profit(losingPlanetBudget / 2);
                double weaponsBudget = firstPlanet.Weapons.Sum(x => x.Price);
                double armyBudget = firstPlanet.Army.Sum(a => a.Cost);
                secondPlanet.Profit(weaponsBudget + armyBudget);
                this.planets.RemoveItem(firstPlanet.Name);
                return $"{secondPlanet.Name} destructed {firstPlanet.Name}!";
            }
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else
            {
                if (planet.Army.Count == 0)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
                }
                else
                {
                    planet.Spend(1.25);
                    planet.TrainArmy();
                    return $"{planetName} has upgraded its forces!";
                }
            }
        }
        private IMilitaryUnit CreateUnit(string unitTypeName)
        {
            IMilitaryUnit unit = null;
            if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            return unit;
        }
        private IWeapon CraftWeapon(string weaponTypeName, int destructionLevel)
        {
            IWeapon weapon = null;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            return weapon;
        }
    }
}
