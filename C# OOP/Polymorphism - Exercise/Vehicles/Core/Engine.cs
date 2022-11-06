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
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(Vehicle car, Vehicle truck, IReader reader, IWriter writer)
        {
            this.car = car;
            this.truck = truck;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action=="Drive")
                {
                    if (tokens[1]=="Car")
                    {
                        writer.WriteLine(car.Drive(double.Parse(tokens[2])));
                    }
                    else
                    {
                        writer.WriteLine(truck.Drive(double.Parse(tokens[2])));
                    }
                }
                else
                {
                    if (tokens[1]=="Car")
                    {
                        car.Refuel(double.Parse(tokens[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(tokens[2]));
                    }
                }
            }
            writer.WriteLine(car);
            writer.WriteLine(truck);
        }
    }
}
