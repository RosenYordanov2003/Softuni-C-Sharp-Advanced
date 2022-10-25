using System;
namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle motor = new RaceMotorcycle(100, 50);
            motor.Drive(6);
            Console.WriteLine(motor.Fuel);
            SportCar sportCar = new SportCar(100, 200);
            sportCar.Drive(8);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
