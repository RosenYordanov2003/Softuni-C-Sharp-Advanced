namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Easter.Models.Eggs.Contracts;
    using Contracts;
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> _eggs;

        public EggRepository()
        {
            _eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => _eggs;
        public void Add(IEgg model)
        {
            _eggs.Add(model);
        }

        public bool Remove(IEgg model)
        {
            return _eggs.Remove(model);
        }

        public IEgg FindByName(string name)
        {
            return _eggs.FirstOrDefault(e => e.Name == name);
        }
    }
}
