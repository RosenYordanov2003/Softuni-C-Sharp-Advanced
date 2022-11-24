namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using Formula1.Models.Contracts;
    using Contracts;
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.models;
        public void Add(IPilot model)
        {
          this.models.Add(model);
        }

        public bool Remove(IPilot model)
        {
            return this.models.Remove(model);
        }

        public IPilot FindByName(string name)
        {
            return this.models.FirstOrDefault(p => p.FullName == name);
        }
    }
}
