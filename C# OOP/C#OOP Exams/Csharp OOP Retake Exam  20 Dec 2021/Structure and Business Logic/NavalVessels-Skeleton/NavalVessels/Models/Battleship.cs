using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    using System;
    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        private const int InitialArmour = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmour)
        {
            SonarMode = false;
        }

        public bool SonarMode
        {
            get { return this.sonarMode; }
            private set { this.sonarMode = value; }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < InitialArmour)
            {
                ArmorThickness = InitialArmour;
            }
        }

        public void ToggleSonarMode()
        {
            this.SonarMode = !this.SonarMode;
            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            string sonarModeResult = SonarMode == true ? "ON" : "OFF";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            string targetsResult = this.Targets.Count > 0 ? string.Format(string.Join(", ", Targets)) : "None";
            sb.AppendLine($" *Targets: {targetsResult}");
            sb.AppendLine($" *Sonar mode: {sonarModeResult}");
            return sb.ToString().Trim();
        }
    }
}
