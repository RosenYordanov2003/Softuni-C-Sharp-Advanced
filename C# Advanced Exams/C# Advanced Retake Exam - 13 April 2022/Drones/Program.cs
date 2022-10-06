using System;
using System.Collections.Generic;

namespace Drones
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Airfield airfield = new Airfield("Heathrow", 10, 10.5);
            Drone drone = new Drone("D20", "DEERC", 6);
            Console.WriteLine(drone);
            Console.WriteLine(airfield.AddDrone(drone));
            Console.WriteLine(airfield.Count);
            Console.WriteLine(airfield.RemoveDrone("DE51"));
            Drone secondDrone = new Drone("CW4", "Cheerwing", 8);
            Drone thirdDrone = new Drone("X5SW-V3", "Cheerwing", 7);
            Drone fourthDrone = new Drone("X20", "Cheerwing", 4);
            Drone fifthDrone = new Drone("EVO2", "Autel", 10);
            Drone sixtDrone = new Drone("XL5-6S-FPV", "iFlight", 10);
            Console.WriteLine(airfield.AddDrone(secondDrone));
            Console.WriteLine(airfield.AddDrone(thirdDrone));
            Console.WriteLine(airfield.AddDrone(fourthDrone));
            Console.WriteLine(airfield.AddDrone(fifthDrone)); 
            Console.WriteLine(airfield.AddDrone(sixtDrone));
            Console.WriteLine(airfield.FlyDrone("CW4"));
            Console.WriteLine("-----------------FlyDronesByRange-----------------");
            List<Drone> flyDrones = airfield.FlyDronesByRange(10);
            foreach (var droneToFly in flyDrones)
            {
                Console.WriteLine(droneToFly);
            }
            Console.WriteLine(airfield.RemoveDroneByBrand("Cheerwing"));
            Console.WriteLine("----------------------Report----------------------");
            Console.WriteLine(airfield.Report());
        }
    }
}
