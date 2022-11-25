using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    using System;
    using System.Text;

    public class Submarine : Vessel,ISubmarine
    {
        private const int InitialArmour = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmour)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode
        {
            get { return this.submergeMode; }
            private set { submergeMode = value; }
        }

        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !this.SubmergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness<InitialArmour)
            {
                ArmorThickness = InitialArmour;
            }
        }

        public override string ToString()
        {
            string subMergeModeResult = SubmergeMode == true ? "ON" : "OFF";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            string targetsResult = this.Targets.Count > 0 ? string.Format(string.Join(", ", Targets)) : "None";
            sb.AppendLine($" *Targets: {targetsResult}");
            sb.AppendLine($" *Submerge mode: {subMergeModeResult}");
            return sb.ToString().Trim();
        }
    }
}
