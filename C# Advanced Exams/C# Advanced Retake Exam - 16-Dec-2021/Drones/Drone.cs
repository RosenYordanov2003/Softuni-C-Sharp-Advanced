using System.Text;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool avalilabe;
        public Drone(string name, string brand, int range)
        {
            this.name = name;
            this.brand = brand;
            this.range = range;
            this.avalilabe = true;
        }
        public string Name { get { return this.name; } private set { } }
        public string Brand { get { return this.brand; } private set { } }
        public int Rnage { get { return this.range; } private set { } }
        public bool Avalilabe { get { return this.avalilabe; } set { this.avalilabe = value; } }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {this.name}");
            sb.AppendLine($"Manufactured by: {this.brand}");
            sb.AppendLine($"Range: {this.range} kilometers");
            return sb.ToString().Trim();
        }
    }
}
