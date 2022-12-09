namespace OnlineShop.Models.Products.Computers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Components;
    using Common.Constants;
    using Peripherals;
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;

        private List<IPeripheral> peripherals;


        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();
        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + components.Average(c => c.OverallPerformance);
            }
        }

        public override decimal Price =>
            base.Price + components.Select(c => c.Price).Sum() + peripherals.Select(p => p.Price).Sum();


        public void AddComponent(IComponent component)
        {
            if (components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, Id));
            }
            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType,
                    this.GetType().Name, Id));
            }

            IComponent componentToRemove = components.First(c => c.GetType().Name == componentType);
            components.Remove(componentToRemove);
            return componentToRemove;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, Id));
            }
            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    this.GetType().Name, Id));
            }

            IPeripheral peripheralToRemove = peripherals.First(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({Components.Count}):");
            foreach (IComponent component in components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            double result = peripherals.Count > 0 ? peripherals.Average(p => p.OverallPerformance) : 0;
            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({result:F2}):");
            foreach (IPeripheral peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
