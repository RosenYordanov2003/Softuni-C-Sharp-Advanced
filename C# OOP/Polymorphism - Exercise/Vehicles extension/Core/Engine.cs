namespace Vehicles.Core
{
    using System;
    using Contracts;
    using Vehicles.IO.Contracts;
    using Vehicles.Models;

    public class Engine : IEngine
    {
        private Vehicle car;
        private Vehicle truck;
        private Vehicle bus;
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(Vehicle car, Vehicle truck, Vehicle bus, IReader reader, IWriter writer)
        {
            this.car = car;
            this.truck = truck;
            this.reader = reader;
            this.writer = writer;
            this.bus = bus;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                try
                {
                    if (action == "Drive")
                    {
                        if (tokens[1] == "Car")
                        {
                            writer.WriteLine(car.Drive(double.Parse(tokens[2])));
                        }
                        else if (tokens[1] == "Truck")
                        {
                            writer.WriteLine(truck.Drive(double.Parse(tokens[2])));
                        }
                        else
                        {
                            writer.WriteLine(bus.Drive(double.Parse(tokens[2])));
                        }
                    }
                    else if (action == "Refuel")
                    {
                        if (tokens[1] == "Car")
                        {
                            car.Refuel(double.Parse(tokens[2]));
                        }
                        else if (tokens[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(tokens[2]));
                        }
                        else
                        {
                            bus.Refuel(double.Parse(tokens[2]));
                        }
                    }
                    else
                    {
                        if (bus is Bus bus1)
                        {
                            writer.WriteLine(bus1.DriveEmptyBus(double.Parse(tokens[2])));
                        }
                    }
                }
                catch (Exception exception)
                {
                    writer.WriteLine(exception.Message);
                }
            }
            writer.WriteLine(car);
            writer.WriteLine(truck);
            writer.WriteLine(bus);
        }
    }
}
