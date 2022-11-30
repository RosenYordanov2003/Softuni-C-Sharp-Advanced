namespace Easter.Models.Bunnies
{
    using System.Linq;
    using System.Text;
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Easter.Models.Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private ICollection<IDye> _dyes;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            _dyes = new List<IDye>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }

        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (energy < 0)
                {
                    energy = 0;
                }
                else
                {
                    energy = value;
                }
            }
        }
        public ICollection<IDye> Dyes => _dyes;
        public abstract void Work();

        public void AddDye(IDye dye)
        {
            _dyes.Add(dye);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Energy: {Energy}");
            sb.AppendLine($"Dyes: {Dyes.Where(d=>d.IsFinished()==false).Count()} not finished");
            return sb.ToString().Trim();
        }
    }
}
