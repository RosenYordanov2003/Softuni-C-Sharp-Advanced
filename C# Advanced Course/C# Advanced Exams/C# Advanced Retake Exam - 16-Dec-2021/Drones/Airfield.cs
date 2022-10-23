using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> Drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Drones = new List<Drone>();
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return this.Drones.Count; } private set { } }
        public string AddDrone(Drone drone)
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                message = "Invalid drone.";
            }
            else if (drone.Rnage < 5 || drone.Rnage > 15)
            {
                message = "Invalid drone.";
            }
            else if (this.Capacity - this.Drones.Count > 0)
            {
                this.Drones.Add(drone);
                message = $"Successfully added {drone.Name} to the airfield.";
            }
            else
            {
                message = "Airfield is full.";
            }
            return message;
        }
        public bool RemoveDrone(string name)
        {
            bool isExist = false;
            Drone droneToRemove = Drones.FirstOrDefault(x => x.Name == name);
            if (droneToRemove != null)
            {
                isExist = true;
                this.Drones.Remove(droneToRemove);
            }
            return isExist;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int countRemovedDrones = 0;
            for (int i = 0; i < this.Drones.Count; i++)
            {
                Drone currentDrone = Drones[i];
                if (currentDrone.Brand == brand)
                {
                    this.Drones.Remove(currentDrone);
                    i--;
                    countRemovedDrones++;
                }
            }
            return countRemovedDrones;
        }
        public Drone FlyDrone(string name)
        {
            Drone droneToSet = this.Drones.FirstOrDefault(x => x.Name == name);
            if (droneToSet != null)
            {
                droneToSet.Avalilabe = false;
                return droneToSet;
            }
            else
            {
                return null;
            }
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesByRange = this.Drones.Where(d => d.Rnage >= range&&d.Avalilabe!=false).ToList();
            for (int i = 0; i < dronesByRange.Count; i++)
            {
                Drone currentDron = dronesByRange[i];
                currentDron.Avalilabe = false;
            }
            return dronesByRange;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (Drone item in this.Drones.Where(d=>d.Avalilabe!=false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
