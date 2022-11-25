namespace NavalVessels.Core
{
    using System;
    using System.Linq;
    using Models;
    using System.Collections.Generic;
    using Contracts;
    using NavalVessels.Models.Contracts;
    using Repositories;
    using NavalVessels.Repositories.Contracts;

    public class Controller : IController
    {
        private IRepository<IVessel> vessels;
        private ICollection<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(c => c.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            }
            else
            {
                this.captains.Add(new Captain(fullName));
                return $"Captain {fullName} is hired.";
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vessels.FindByName(name) != null)
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }
            else if (vesselType != "Battleship" && vesselType != "Submarine")
            {
                return "Invalid vessel type.";
            }
            IVessel vessel = CreateVessel(name, mainWeaponCaliber, speed, vesselType);
            this.vessels.Add(vessel);
            return
                $"{vessel.GetType().Name} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }


        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            Type type = vessel.GetType();
            if (type.Name == "Battleship")
            {
                Battleship vesselAsBattleship = vessel as Battleship;
                vesselAsBattleship.ToggleSonarMode();
                return $"Battleship {vesselAsBattleship.Name} toggled sonar mode.";
            }
            else
            {
                Submarine vesselAsSubmarine = vessel as Submarine;
                vesselAsSubmarine.ToggleSubmergeMode();
                return $"Submarine {vesselAsSubmarine.Name} toggled submerge mode.";
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackVessel = this.vessels.FindByName(attackingVesselName);
            IVessel defendVessel = this.vessels.FindByName(defendingVesselName);
            if (attackVessel == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (defendVessel == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attackVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (defendVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }
            attackVessel.Attack(defendVessel);
            attackVessel.Captain.IncreaseCombatExperience();
            defendVessel.Captain.IncreaseCombatExperience();
            return
                $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendVessel.ArmorThickness}.";
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            if (vessel != null)
            {
                vessel.RepairVessel();
                return $"Vessel {vessel.Name} was repaired.";
            }
            return $"Vessel {vesselName} could not be found.";
        }


        private IVessel CreateVessel(string name, double mainWeaponCaliber, double speed, string vesselType)
        {
            IVessel vessel;
            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            return vessel;
        }

    }
}
