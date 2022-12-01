namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int CapacityToSet = 25;
        public SaltwaterAquarium(string name) : base(name, CapacityToSet){}
    }
}
