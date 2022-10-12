using System.Text;

namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;
        public Animal(string species, string diet, double weight, double length)
        {
            this.species = species;
            this.diet = diet;
            this.weight = weight;
            this.length = length;
        }
        public string Species { get { return this.species; } private set {; } }
        public string Diet { get { return this.diet; } private set {; } }
        public double Weight { get { return this.weight; } private set {; } }
        public double Length { get { return this.length; } private set {; } }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {this.species} is a {this.diet} and weighs {this.weight} kg.");
            return sb.ToString().Trim();
        }
    }
}
