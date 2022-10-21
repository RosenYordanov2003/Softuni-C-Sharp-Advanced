using System.Text;

namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;
        public Fish(string fishType, double length, double weight)
        {
          this.FishType = fishType;
          this.Length = length;
          this.Weight = weight;
        }

        public string FishType
        {
            get { return this.fishType; }
            set { this.fishType = value; }
        }
        public double Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"There is a {this.FishType}, {this.Length} cm. long, and {this.weight} gr. in weight.");
            return sb.ToString().Trim();
        }
    }
}
