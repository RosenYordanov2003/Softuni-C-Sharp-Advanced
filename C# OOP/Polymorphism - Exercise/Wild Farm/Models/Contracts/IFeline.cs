using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Models.Contracts
{
    public interface IFeline : IAnimal
    {
        public string Breed { get;}
    }
}
