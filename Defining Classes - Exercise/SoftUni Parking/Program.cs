using SoftuniParking;
using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Car car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            //Car car2 = new Car("Audi", "A3", 110, "EB8787MN");
            //Console.WriteLine(car.ToString());
            //Parking parking = new Parking(5);
            //Console.WriteLine(parking.AddCar(car));
            //Console.WriteLine(parking.AddCar(car));
            //Console.WriteLine(parking.AddCar(car2));
            //Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            //Console.WriteLine(parking.RemoveCar("EB8787MN"));
            //Console.WriteLine(parking.Count);
            Car car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            Car car2 = new Car("Audi", "A3", 110, "EB8787MN");
            Car car3 = new Car("Audi", "A6", 110, "EB8787MN");
            Car car4 = new Car("Audi", "A8", 110, "EB8787MO");
            Parking parking = new Parking(3);
            Console.WriteLine(parking.AddCar(car));
            Console.WriteLine(parking.AddCar(car2));
            Console.WriteLine(parking.AddCar(car3));
            Console.WriteLine(parking.AddCar(car4));
            Console.WriteLine(parking.RemoveCar("CC1856BG"));
            Console.WriteLine(parking.Count);

        }
    }
}
