namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Planets.Contracts;
    using Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> _planets;

        public PlanetRepository()
        {
            this._planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => _planets;
        public void Add(IPlanet model)
        {
            this._planets.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            return this._planets.Remove(model);
        }

        public IPlanet FindByName(string name)
        {
            return this._planets.First(p => p.Name == name);
        }
    }
}
