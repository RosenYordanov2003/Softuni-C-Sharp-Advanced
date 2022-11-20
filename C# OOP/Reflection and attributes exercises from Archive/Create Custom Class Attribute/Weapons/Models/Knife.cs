namespace InfernoInfinity.Weapons.Models
{
    using Gems.Contracts;
    public class Knife: Weapon
    {
        private const int KnifeMinDamage = 3;
        private const int KnifeMaxDamage = 4;
        private const int SocketLength = 2;
        public Knife(string commonType, string name) : base(commonType, name, KnifeMinDamage, KnifeMaxDamage)
        {
            Sockets = new IGem[SocketLength];
        }
    }
}
