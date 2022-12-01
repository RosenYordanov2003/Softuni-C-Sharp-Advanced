namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int CapacityToSet = 50;
        public FreshwaterAquarium(string name) : base(name, CapacityToSet){}
    }
}
