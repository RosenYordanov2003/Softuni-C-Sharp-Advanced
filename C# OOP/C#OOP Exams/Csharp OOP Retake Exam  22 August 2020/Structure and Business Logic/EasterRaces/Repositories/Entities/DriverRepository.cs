
namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using EasterRaces.Models.Drivers.Contracts;
    using Contracts;

    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;

        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }
        public IDriver GetByName(string name)
        {
            return drivers.FirstOrDefault(d => d.Name == name);
        }

        public IReadOnlyCollection<IDriver> GetAll() => drivers;
       

        public void Add(IDriver model)
        {
           drivers.Add(model);
        }

        public bool Remove(IDriver model)
        {
            return drivers.Remove(model);
        }
    }
}
