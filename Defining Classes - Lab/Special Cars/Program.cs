using System;
using System.Linq;
using System.Collections.Generic;

namespace Special_Cars
{
    public class Program
    {
        static void Main()
        {
            List<List<int>> years = new List<List<int>>();
            List<List<double>> pressure = new List<List<double>>();
            string firstCommand = string.Empty;
            Tires tires = new Tires();
            while ((firstCommand = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = firstCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                List<int> yearsList = tires.GetYears(tokens);
                years.Add(yearsList);
                List<double> currentPressure = tires.GetPressure(tokens);
                pressure.Add(currentPressure);
            }
            string secondCommand = string.Empty;
            Engine engine = new Engine();
            List<List<int>> horsePower = new List<List<int>>();
            List<List<double>> cubicCapacity = new List<List<double>>();
            while ((secondCommand = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = secondCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                List<int> currentHorsePower = engine.GetHorsePower(tokens);
                horsePower.Add(currentHorsePower);
                List<double> currentCubicCapacity = engine.GetCubicCapacity(tokens);
                cubicCapacity.Add(currentCubicCapacity);
            }
            string finalCommand = string.Empty;
            List<Car> cars = new List<Car>();
            while ((finalCommand = Console.ReadLine()) != "Show special")
            {
                string[] tokens = finalCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);
                Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engineIndex, tiresIndex);
                cars.Add(currentCar);
            }
            GetSpecialCars(cars, horsePower, cubicCapacity, years, pressure);
        }

        static void GetSpecialCars(List<Car> cars, List<List<int>> horsePower, List<List<double>> cubicCapacity, List<List<int>> years, List<List<double>> pressure)
        {
            List<Car> specialCars = new List<Car>();
            foreach (Car specialCar in cars)
            {
                var currentCarHorsePower = horsePower[specialCar.EngineIndex].Sum();
                var currentCarTierSum = pressure[specialCar.TiresIndex].Sum();
                if (specialCar.Year >= 2017 && currentCarHorsePower > 330 && currentCarTierSum >= 9 && currentCarTierSum <= 10)
                {
                    specialCar.FuelQuantity = specialCar.Drive(specialCar.FuelQuantity, specialCar.FuelConsumption);
                    Console.WriteLine($"Make: {specialCar.Make}");
                    Console.WriteLine($"Model: {specialCar.Model}");
                    Console.WriteLine($"Year: {specialCar.Year}");
                    Console.WriteLine($"HorsePowers: {currentCarHorsePower}");
                    Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
                }
            }
        }
    }
}

