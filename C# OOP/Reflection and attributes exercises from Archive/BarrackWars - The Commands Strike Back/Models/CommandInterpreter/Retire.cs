using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Data
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory factory) : base(data, repository, factory){}

        public override string Execute()
        {
            return this.Repository.RemoveUnit(this.Data[1]);
          
        }
    }
}
