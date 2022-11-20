namespace InfernoInfinity.Weapons.Models
{
    using Gems.Contracts;
    public class Axe : Weapon
    {
        private const int AxeMinDamage = 5;
        private const int AxeMaxDamage = 10;
        private const int SocketLength = 4;
        public Axe(string commonType, string name) : base(commonType, name, AxeMinDamage, AxeMaxDamage)
        {
            Sockets = new IGem[SocketLength];
        }
    }
}
