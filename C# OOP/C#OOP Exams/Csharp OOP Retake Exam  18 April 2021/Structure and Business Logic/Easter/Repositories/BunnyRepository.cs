namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Easter.Models.Bunnies.Contracts;
    using Contracts;
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> _bunnies;

        public BunnyRepository()
        {
            _bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => _bunnies;

        public void Add(IBunny model)
        {
           _bunnies.Add(model);
        }

        public bool Remove(IBunny model)
        {
            return _bunnies.Remove(model);
        }

        public IBunny FindByName(string name)
        {
            return _bunnies.FirstOrDefault(b => b.Name == name);
        }
    }
}
