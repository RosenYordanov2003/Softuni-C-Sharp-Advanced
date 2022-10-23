using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);
                Car currentCar = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(currentCar);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ');
                string modelToDrive = tokens[1];
                double amountKmToDrive = double.Parse(tokens[2]);
                Car carToDrive = cars.Find(x => x.Model == modelToDrive);
                carToDrive.Drive(amountKmToDrive);
            }
            PrintResult(cars);
        }

        static void PrintResult(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
