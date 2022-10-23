using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
           this.Multiprocessor = new List<CPU>();
           this.Model = model;
           this.Capacity = capacity;
        }

        public string Model { get; set; }
        public int Capacity { get; set; }

        public List<CPU> Multiprocessor { get; set; }
        public int Count => this.Multiprocessor.Count;
        public void Add(CPU cpu)
        {
            if (this.Capacity-this.Multiprocessor.Count>0)
            {
                this.Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            CPU cpuToRemove = this.Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            if (cpuToRemove!=null)
            {
                this.Multiprocessor.Remove(cpuToRemove);
                return true;
            }
            return false;
        }
        public CPU MostPowerful()
        {
            return this.Multiprocessor.OrderByDescending(c => c.Frequency).First();
        }
        public CPU GetCPU(string brand)
        {
            CPU cpuToReturn = this.Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            if (cpuToReturn != null)
            {
                return cpuToReturn;
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach (CPU cpu in this.Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
