using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> Racers;
        public Race(string name, int capacity)
        {
            this.Racers = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Racers.Count;
        public void Add(Racer Racer)
        {
            if (this.Capacity - this.Racers.Count >  0)
            {
                this.Racers.Add(Racer);
            }
         }
        public bool Remove(string name)
        {
            Racer racerToRemove = this.Racers.FirstOrDefault(x => x.Name == name);
            if (racerToRemove!=null)
            {
                this.Racers.Remove(racerToRemove);
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            return this.Racers.OrderByDescending(x => x.Age).First();
        }
        public Racer GetRacer(string name)
        {
            return this.Racers.First(x => x.Name == name);
        }
        public Racer GetFastestRacer()
        {
            return this.Racers.OrderByDescending(x=>x.Car.Speed).First();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (Racer racer in this.Racers)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
