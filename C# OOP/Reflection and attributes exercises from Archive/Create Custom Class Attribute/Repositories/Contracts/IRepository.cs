namespace InfernoInfinity.Repositories.Contracts
{
    using System.Collections.Generic;
    using Weapons.Contracts;
    public interface IRepository
    {
        public IReadOnlyCollection<IWeapon> Weapons { get;}
        public void Add(IWeapon weapon);
        public IWeapon FindByName(string weaponName);
    }
}
