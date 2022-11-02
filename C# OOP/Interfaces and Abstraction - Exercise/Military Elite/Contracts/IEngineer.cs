using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface IEngineer:ISpecialSoldier
    {
        public ICollection<IRepair> Repairs { get;}
    }
}
