namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Formula1.Models.Contracts;
    using Contracts;
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => models;
        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }

        public IRace FindByName(string name)
        {
            return this.models.FirstOrDefault(r => r.RaceName == name);
        }
    }
}
