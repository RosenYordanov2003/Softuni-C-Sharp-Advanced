using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym = CreateGym(gymType, gymName);
            this.gyms.Add(gym);
            return $"Successfully added {gym.GetType().Name}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            IEquipment equipment = CreateEquipment(equipmentType);
            this.equipment.Add(equipment);
            return $"Successfully added {equipment.GetType().Name}.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment,
                    equipmentType));
            }
            IGym gym = gyms.First(g => g.Name == gymName);
            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return $"Successfully added {equipment.GetType().Name} to {gymName}.";
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gyms.First(g => g.Name == gymName);
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            IAthlete athlete = CreateAthlete(athleteType, athleteName, motivation, numberOfMedals);
            if (!IsValidGym(athlete, gym))
            {
                return "The gym is not appropriate.";
            }
            gym.AddAthlete(athlete);
            return $"Successfully added {athlete.GetType().Name} to {gymName}.";
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.First(g => g.Name == gymName);
            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.First(g => g.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:F2} grams.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IGym gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }


        private IGym CreateGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }
            return gym;
        }

        private IEquipment CreateEquipment(string type)
        {
            IEquipment equipment;
            if (type == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }

            return equipment;
        }

        private IAthlete CreateAthlete(string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            return athlete;
        }

        private bool IsValidGym(IAthlete athlete, IGym gym)
        {
            if (athlete.GetType().Name == "Boxer")
            {
                if (gym.GetType().Name == "BoxingGym")
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (gym.GetType().Name == "WeightliftingGym")
                {
                    return true;
                }
                return false;
            }
        }
    }
}
