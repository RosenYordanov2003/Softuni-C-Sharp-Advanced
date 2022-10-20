using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;
        public Parking(string type, int capacity)
        {
            this.cars = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.cars.Count;
        public void Add(Car car)
        {
            if (this.Capacity - this.cars.Count > 0)
            {
                this.cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = this.cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (carToRemove != null)
            {
                this.cars.Remove(carToRemove);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (this.cars.Count == 0)
            {
                return null;
            }
            return this.cars.OrderByDescending(c => c.Year).First();
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car carToGet = this.cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (carToGet != null)
            {
                return carToGet;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (Car car in this.cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
