using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces.Contracts
{
    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }
        string GetName();
    }
}
