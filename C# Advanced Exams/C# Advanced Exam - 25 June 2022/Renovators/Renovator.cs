using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;
        public Renovator(string name, string type, double rate, int days)
        {
            this.name = name;
            this.type = type;
            this.rate = rate;
            this.days = days;
            this.hired = false;
        }
        public string Name
        {
            get { return this.name; }
        }
        public string Type
        {
            get { return this.type; }
        }
        public double Rate
        {
            get { return this.rate; }
        }
        public int Days
        {
            get { return this.days; }
        }
        public bool Hired
        {
            get { return this.hired; }
            set { this.hired = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {this.name}");
            sb.AppendLine($"--Specialty: {this.type}");
            sb.AppendLine($"--Rate per day: {this.rate} BGN");
            return sb.ToString().Trim();
        }
    }
}
