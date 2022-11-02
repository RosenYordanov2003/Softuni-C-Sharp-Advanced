using Military_Elite.Contracts;
using Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    public class Engineer : SpecialSoldier,IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corp, ICollection<IRepair> repairs) : base(id, firstName, lastName, salary, corp)
        {
            Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {base.Corp}");
            sb.AppendLine("Repairs:");
            foreach (IRepair repiar in Repairs)
            {
                sb.AppendLine("   "+repiar.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
