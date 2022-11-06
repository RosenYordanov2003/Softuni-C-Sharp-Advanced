namespace Wild_Farm.Models.Contracts
{
    public interface IMammal : IAnimal
    {
        public string LivingRegion { get; }
    }
}
