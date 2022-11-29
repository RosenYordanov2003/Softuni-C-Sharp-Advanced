namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Contracts;
    using Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using Models.Mission;
    using SpaceStation.Models.Mission.Contracts;
    using Models.Planets;
    using SpaceStation.Models.Planets.Contracts;
    using Repositories;
    using SpaceStation.Repositories.Contracts;
    using Utilities.Messages;
    public class Controller : IController
    {
        private IRepository<IAstronaut> _astronauts;
        private IRepository<IPlanet> _planets;
        private HashSet<IPlanet> _visitedPlanets;
        private IMission _mission;

        public Controller()
        {
            this._astronauts = new AstronautRepository();
            this._planets = new PlanetRepository();
            this._mission = new Mission();
            this._visitedPlanets = new HashSet<IPlanet>();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            if (!IsvalidAstronaut(type))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            IAstronaut astronaut = CreateAstronaut(type, astronautName);
            this._astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, astronaut.GetType().Name, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }
            this._planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronautToRemove = this._astronauts.FindByName(astronautName);
            if (astronautToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,
                    astronautName));
            }

            this._astronauts.Remove(astronautToRemove);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronauts = this._astronauts.Models.Where(a => a.Oxygen > 60).ToList();
            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            IPlanet planet = this._planets.FindByName(planetName);
            this._mission.Explore(planet, astronauts);
            this._visitedPlanets.Add(planet);
            return string.Format(OutputMessages.PlanetExplored, planetName, astronauts.Where(a=>a.Oxygen<=0).ToList().Count);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this._visitedPlanets.Count} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (IAstronaut astronaut in this._astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                string result = astronaut.Bag.Items.Count > 0
                    ? string.Format(string.Join(", ", astronaut.Bag.Items))
                    : "none";
                sb.AppendLine($"Bag items: {result}");
            }

            return sb.ToString().Trim();
        }

        private bool IsvalidAstronaut(string type)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Astronaut)).ToArray();
            foreach (Type item in types)
            {
                if (item.Name == type)
                {
                    return true;
                }
            }
            return false;
        }
        private IAstronaut CreateAstronaut(string type, string name)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(name);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(name);
            }
            else
            {
                astronaut = new Geodesist(name);
            }
            return astronaut;
        }
    }
}
