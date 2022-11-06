namespace Vehicles
{
    using Core;
    using Core.Contracts;
    using System;
    using Factories;
    using Models;
    using Vehicles.IO.Contracts;
    using Vehicles.IO;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IFactory factory = new Factory();

            Vehicle car = factory.CreateVehicle(carTokens[0], double.Parse(carTokens[1]), double.Parse(carTokens[2]));
            Vehicle truck = factory.CreateVehicle(truckTokens[0], double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

            IEngine engine = new Engine(car, truck, reader, writer);
            engine.Run();
        }
    }
}
