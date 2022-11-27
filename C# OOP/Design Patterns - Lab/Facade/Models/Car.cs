namespace Facade.Models
{
    public class Car
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public int NumberOfDoors { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return
                $"CarType: {Type}, Color: {Color}, Number of doors: {NumberOfDoors}, Manufacured: {City}, at address: {Address}";
        }
    }
}
