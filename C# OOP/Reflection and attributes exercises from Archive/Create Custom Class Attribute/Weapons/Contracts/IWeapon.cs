namespace InfernoInfinity.Weapons.Contracts
{
    using InfernoInfinity.Gems.Contracts;
    public interface IWeapon
    {
        public string CommonType { get;}
        public string Name { get;}
        public int MinDamage { get;}
        public int MaxDamage { get;}
        public IGem[] Sockets { get;}
        public void AddGem(int socketIndex,IGem gem);
        public void RemoveGem(int socketIndex);
    }
}
