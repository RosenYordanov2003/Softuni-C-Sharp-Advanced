using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface IComando:ISpecialSoldier
    {
        public ICollection<IMission> Missions { get;}
    }
}
