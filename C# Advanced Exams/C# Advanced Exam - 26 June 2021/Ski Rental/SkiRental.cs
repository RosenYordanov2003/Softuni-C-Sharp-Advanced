using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            this.data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }
        public void Add(Ski ski)
        {
            if (this.Capacity - this.data.Count > 0)
            {
                this.data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = this.data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            if (skiToRemove != null)
            {
                this.data.Remove(skiToRemove);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if (this.data.Count != 0)
            {
                Ski newestSki = this.data.OrderByDescending(x => x.Year).First();
                return newestSki;
            }
            return null;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski skiToReturn = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (skiToReturn != null)
            {
                return skiToReturn;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (Ski ski in this.data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
