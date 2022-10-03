using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftuniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }
        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
        public int Count
        {
            get { return this.cars.Count; }
        }
        public string AddCar(Car car)
        {
            string message = string.Empty;
            bool isExist = cars.Where(x => x.RegistrationNumber == car.RegistrationNumber).Any();
            if (isExist)
            {
                return message = "Car with that registration number, already exists!";
            }
            if (this.capacity - cars.Count > 0)
            {
                this.cars.Add(car);
                message = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
            else
            {
                message = "Parking is full!";
            }
            return message;
        }
        public string RemoveCar(string RegistrationNumbers)
        {
            bool isExist = false;
            string message = string.Empty;
            Car carToRemove = cars.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumbers);
            if (carToRemove != null)
            {
                isExist = true;
                cars.Remove(carToRemove);
                message = $"Successfully removed {RegistrationNumbers}";
            }
            if (!isExist)
            {
                message = "Car with that registration number, doesn't exist!";
            }
            return message;
        }
        public Car GetCar(string RegistrationNumbers)
        {
            Car carToReturn = cars.Find(x => x.RegistrationNumber == RegistrationNumbers);
            return carToReturn;
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < RegistrationNumbers.Count; i++)
            {
                string currentNumber = RegistrationNumbers[i];
                cars.RemoveAll(x => x.RegistrationNumber == currentNumber);
            }
        }
    }
}
