using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car bmw = new Car();
            bmw.Make = "VV";
            bmw.Model = "BMW X6";
            bmw.Year = 2022;
            bmw.FuelQuantity = 200;
            bmw.FuelConsumption = 200;
            bmw.Drive(2000);
            Console.WriteLine(bmw.WhoAmI());
        }
    }
}
