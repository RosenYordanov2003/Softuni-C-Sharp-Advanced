namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using Contracts;
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> _astronauts;

        public AstronautRepository()
        {
            this._astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => _astronauts;
        public void Add(IAstronaut model)
        {
            this._astronauts.Add(model);
        }
        public bool Remove(IAstronaut model)
        {
            return this._astronauts.Remove(model);
        }
        public IAstronaut FindByName(string name)
        {
            return this._astronauts.FirstOrDefault(a => a.Name == name);
        }
    }
}
