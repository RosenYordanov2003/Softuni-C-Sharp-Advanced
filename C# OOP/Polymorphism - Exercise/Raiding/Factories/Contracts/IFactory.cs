using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories.Contracts
{
    public interface IFactory
    {
        BaseHero CreateHero(string typeHero, string name);
    }
}
