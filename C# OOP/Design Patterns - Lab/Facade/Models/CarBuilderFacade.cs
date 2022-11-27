namespace Facade.Models
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            Car = new Car();
        }
        public CarInfoBuilder CarInfo => new CarInfoBuilder(Car);
        public CarAddressBuilder CarAddress => new CarAddressBuilder(Car);

        public Car Build() => Car;
    }
}
