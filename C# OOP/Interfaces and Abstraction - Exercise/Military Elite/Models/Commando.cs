using Military_Elite.Contracts;
using Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    public class Commando : SpecialSoldier, IComando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corp, ICollection<IMission> missions) : base(id, firstName, lastName, salary, corp)
        {
            Missions = missions;
        }
        public ICollection<IMission> Missions { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {base.Corp}");
            sb.AppendLine("Missions:");
            foreach (IMission mission in Missions)
            {
                sb.AppendLine("   " + mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
