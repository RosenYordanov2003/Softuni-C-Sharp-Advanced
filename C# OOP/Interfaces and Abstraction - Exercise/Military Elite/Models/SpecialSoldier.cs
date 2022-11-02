using Military_Elite.Contracts;
using Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    public abstract class SpecialSoldier : Private, ISpecialSoldier
    {
        public SpecialSoldier(int id, string firstName, string lastName, decimal salary, Corps corp) : base(id, firstName, lastName, salary)
        {
            Corp = corp;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public Corps Corp { get; private set; }
    }
}
