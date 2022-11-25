using System.Text;

namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using Utilities.Messages;
    using Contracts;
    public class Captain : ICaptain
    {
        private string _fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;
            this.vessels = new List<IVessel>();
        }

        public string FullName
        {
            get { return this._fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                else
                {
                    this._fullName = value;
                }
            }
        }

        public int CombatExperience
        {
            get { return this.combatExperience; }
            private set { this.combatExperience = value; }
        }
        public ICollection<IVessel> Vessels => this.vessels;
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            if (vessels.Count>0)
            {
                foreach (IVessel vessel in vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
