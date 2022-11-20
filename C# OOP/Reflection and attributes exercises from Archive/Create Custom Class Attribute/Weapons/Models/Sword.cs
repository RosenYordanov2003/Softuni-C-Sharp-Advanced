namespace InfernoInfinity.Weapons.Models
{
    using Gems.Contracts;
    public class Sword : Weapon
    {
        private const int SwordMinDamage = 4;
        private const int SwordMaxDamage = 6;
        private const int SocketLength = 3;
        public Sword(string commonType, string name) : base(commonType, name, SwordMinDamage, SwordMaxDamage)
        {
            Sockets = new IGem[SocketLength];
        }
    }
}
