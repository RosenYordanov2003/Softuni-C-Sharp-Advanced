namespace SpaceStation.Models.Mission
{
    using System.Linq;
    using System.Collections.Generic;
    using SpaceStation.Models.Astronauts.Contracts;
    using Contracts;
    using SpaceStation.Models.Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts.Where(a => a.Oxygen > 0))
            {
                while (astronaut.Oxygen > 0 && planet.Items.Count > 0)
                {
                    astronaut.Bag.Items.Add(planet.Items.First());
                    astronaut.Breath();
                    planet.Items.Remove(planet.Items.First());
                }
            }
        }
    }
}
