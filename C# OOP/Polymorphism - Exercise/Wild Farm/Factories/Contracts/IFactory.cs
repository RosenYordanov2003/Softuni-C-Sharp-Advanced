using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Models;
using Wild_Farm.Models.Contracts;

namespace Wild_Farm.Factories.Contracts
{
    public interface IFactory
    {
        public IAnimal CreateAnimal(string[] tokens);
        public Food CreateFood(string[] tokens);
    }
}
