namespace NavalVessels.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using NavalVessels.Models.Contracts;
    using Contracts;
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> vessels;

        public VesselRepository()
        {
            vessels = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => vessels;
        public void Add(IVessel model)
        {
            this.vessels.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return this.vessels.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return this.vessels.FirstOrDefault(v => v.Name == name);
        }
    }
}
