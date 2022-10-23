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
            Console.WriteLine($"Make: {bmw.Make}\nModel: {bmw.Model}\nYear: {bmw.Model}");
        }
    }
}
