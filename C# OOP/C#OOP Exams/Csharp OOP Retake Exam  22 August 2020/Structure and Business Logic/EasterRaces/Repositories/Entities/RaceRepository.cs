namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using EasterRaces.Models.Races.Contracts;
    using Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public IRace GetByName(string name)
        {
            return races.FirstOrDefault(d => d.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll() => races;


        public void Add(IRace model)
        {
            races.Add(model);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
