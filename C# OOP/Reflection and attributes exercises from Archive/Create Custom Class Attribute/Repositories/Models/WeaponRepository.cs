using System.Linq;

namespace InfernoInfinity.Repositories.Models
{
    using System.Collections.Generic;
    using Contracts;
    using Weapons.Contracts;
    public class WeaponRepository : IRepository
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Weapons => this.weapons;

        public void Add(IWeapon weapon)
        {
          this.weapons.Add(weapon);
        }

        public IWeapon FindByName(string weaponName)
        {
            return this.weapons.FirstOrDefault(w => w.Name == weaponName);
        }
    }
}
