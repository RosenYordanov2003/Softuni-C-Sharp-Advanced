namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int InitialComfort = 5;
        private const decimal InitialPrice = 10;
        public Plant() : base(InitialComfort, InitialPrice) {}
    }
}
