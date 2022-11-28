namespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Gym.Models.Equipment.Contracts;
    using Contracts;
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipments;
        public EquipmentRepository()
        {
            this.equipments = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models { get; }
        public void Add(IEquipment model)
        {
            this.equipments.Add(model);
        }
        public bool Remove(IEquipment model)
        {
            return this.equipments.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.equipments.FirstOrDefault(e => e.GetType().Name == type);
        }
    }
}
