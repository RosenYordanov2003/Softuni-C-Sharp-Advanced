using System;

namespace Parking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking("Underground parking garage", 5);

            Car volvo = new Car("Volvo", "XC70", 2010);

            Console.WriteLine(volvo); // Volvo XC70 (2010)

            parking.Add(volvo);

            
            Console.WriteLine(parking.Remove("Volvo", "XC90")); // False
            Console.WriteLine(parking.Remove("Volvo", "XC70")); // True

            Car peugeot = new Car("Peugeot", "307", 2011);
            Car audi = new Car("Audi", "S4", 2005);

            parking.Add(peugeot);
            parking.Add(audi);

            Car latestCar = parking.GetLatestCar();
            Console.WriteLine(latestCar); // Peugeot 307 (2011)

            // Get Car
            Car audiS4 = parking.GetCar("Audi", "S4");
            Console.WriteLine(audiS4); // Audi S4 (2005)

            // Count
            Console.WriteLine(parking.Count); // 2

            // Get Statistics
            Console.WriteLine(parking.GetStatistics());

        }
    }
}
