using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons = new List<IWeapon>();
        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void Add(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.weapons.FirstOrDefault(w => w.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            IWeapon weaponToRemove = this.weapons.FirstOrDefault(x => x.Name == model.Name);
            return this.weapons.Remove(weaponToRemove);
        }
    }
}
