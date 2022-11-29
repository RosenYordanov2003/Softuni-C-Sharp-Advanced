namespace Prototype.Models
{
    using System.Collections.Generic;
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }
        public SandwichPrototype this[string name]
        {
            get { return sandwiches[name]; }
            set { sandwiches[name] = value; }
        }
    }
}
