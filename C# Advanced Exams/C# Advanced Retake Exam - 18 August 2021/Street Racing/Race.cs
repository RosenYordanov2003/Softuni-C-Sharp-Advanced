using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> Participants;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
           this.Participants = new List<Car>();
           this.Name = name;
           this.Type = type;
           this.Laps = laps;
           this.Capacity = capacity;
           this.MaxHorsePower = maxHorsePower;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count { get { return this.Participants.Count; } }
        public void Add(Car car)
        {
            if (this.Capacity-this.Participants.Count>0&&car.HorsePower<=this.MaxHorsePower)
            {
                if (!this.Participants.Any(c=>c.LicensePlate==car.LicensePlate))
                {
                    this.Participants.Add(car);
                }
            }
        }
        public bool Remove(string licensePlate)
        {
            bool isExist = false;
            Car carToRemove = this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (carToRemove!=null)
            {
                isExist = true;
                this.Participants.Remove(carToRemove);
            }
            return isExist;
        }
        public Car FindParticipant(string licensePlate)
        {
            Car carToReturn = this.Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
            if (carToReturn!=null)
            {
                return carToReturn;
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            if (this.Participants.Count==0)
            {
                return null;
            }
            else
            {
                return this.Participants.OrderByDescending(x => x.HorsePower).First();
            }
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (Car car in this.Participants)
            {
               sb.AppendLine(car.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
