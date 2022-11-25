namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using Utilities.Messages;
    using Contracts;
    using System.Text;
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public ICaptain Captain
        {
            get { return this.captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                captain = value;
            }
        }

        public double ArmorThickness
        {
            get { return this.armorThickness; }
            set { armorThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get { return this.mainWeaponCaliber; }
            protected set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return this.speed; }
            protected set { speed = value; }
        }

        public ICollection<string> Targets => targets;
        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            if (this.MainWeaponCaliber >= target.ArmorThickness)
            {
                target.ArmorThickness = 0;
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }
            this.targets.Add(target.Name);
        }

        public abstract void RepairVessel();


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            string targetsResult = this.targets.Count > 0 ? string.Format(string.Join(", ", targets)) : "None";
            sb.AppendLine($"*Targets: {targetsResult}");
            return sb.ToString().Trim();
        }
    }
}
