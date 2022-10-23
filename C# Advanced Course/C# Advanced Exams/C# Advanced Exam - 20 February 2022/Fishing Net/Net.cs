using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        public Net(string material, int capacity)
        {
            this.fish = new List<Fish>();
            this.Material = material;
            this.Capacity = capacity;
        }
        public List<Fish> Fish
        {
            get { return this.fish; }
        }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return this.fish.Count; }
        }
        public string AddFish(Fish fish)
        {
            string message = string.Empty;
            if (fish.FishType == null || fish.FishType == " " || fish.FishType == " " || fish.Weight <= 0 || fish.Length <= 0)
            {
                message = "Invalid fish.";
            }
            else if (Capacity - this.fish.Count > 0)
            {
                this.fish.Add(fish);
                message = $"Successfully added {fish.FishType} to the fishing net.";
            }
            else
            {
                message = "Fishing net is full.";
            }
            return message;
        }
        public bool ReleaseFish(double weight)
        {
            bool isExist = false;
            if (this.fish.Any(x => x.Weight == weight))
            {
                isExist = true;
                Fish fishToRemove = fish.Find(x => x.Weight == weight);
                fish.Remove(fishToRemove);
            }
            return isExist;
        }
        public Fish GetFish(string fishType)
        {
            Fish fishToReturn = fish.Find(x => x.FishType == fishType);
            return fishToReturn;
        }
        public Fish GetBiggestFish()
        {
            Fish longestFish = fish.OrderByDescending(x => x.Length).First();
            return longestFish;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
           sb.AppendLine($"Into the {this.Material}:");
            foreach (Fish fish in this.fish.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}

