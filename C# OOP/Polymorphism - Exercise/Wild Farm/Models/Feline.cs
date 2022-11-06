namespace Wild_Farm.Models
{
    using Contracts;
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, string livingRegion,string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
