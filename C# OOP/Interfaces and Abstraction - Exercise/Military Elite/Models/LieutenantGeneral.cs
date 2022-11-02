using Military_Elite.Contracts;
using Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Dictionary<int, IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public Dictionary<int, IPrivate> Privates { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (KeyValuePair<int, IPrivate> priv in Privates)
            {
                sb.AppendLine("  " + priv.Value.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
