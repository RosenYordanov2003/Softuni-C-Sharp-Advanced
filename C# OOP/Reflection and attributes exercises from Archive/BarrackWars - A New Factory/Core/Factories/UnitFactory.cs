using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using _03BarracksFactory.Models.Units;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Unit)).ToArray();
            IUnit unit = null;
            foreach (Type type in types)
            {
                if (unitType == type.Name)
                {
                    unit = (IUnit)Activator.CreateInstance(type);
                    break;
                }
            }
            return unit;
        }
    }
}
