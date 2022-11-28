using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string gymName;
        private int capacity;
        private ICollection<IEquipment> equipments;
        private ICollection<IAthlete> athletes;

        protected Gym(string gymName, int capacity)
        {
            Name = gymName;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        public string Name
        {
            get { return this.gymName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.gymName = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { capacity = value; }
        }
        public double EquipmentWeight => this.equipments.Select(e => e.Weight).Sum();
        public ICollection<IEquipment> Equipment => equipments;
        public ICollection<IAthlete> Athletes => athletes;
        public void AddAthlete(IAthlete athlete)
        {
            if (this.capacity - this.athletes.Count > 0)
            {
                this.athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder gymReport = new StringBuilder();
            gymReport.AppendLine($"{Name} is a {this.GetType().Name}:");
            if (this.athletes.Count > 0)
            {
                string[] names = this.athletes.Select(a => a.FullName).ToArray();
                gymReport.AppendLine($"Athletes: {string.Join(", ", names)}");
            }
            else
            {
                gymReport.AppendLine("Athletes: No athletes");
            }
            gymReport.AppendLine($"Equipment total count: {Equipment.Count}");
            gymReport.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");
            return gymReport.ToString().TrimEnd();
        }
    }
}
