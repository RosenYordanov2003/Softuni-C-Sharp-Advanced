using System;
using System.Collections.Generic;
using System.Text;

namespace Special_Cars
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;
        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }
        public double CubicCapacity
        {
            get { return this.cubicCapacity; }
            set { this.cubicCapacity = value; }
        }
        public List<int> GetHorsePower(string[] tokens)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < tokens.Length; i += 2)
            {
                list.Add(int.Parse(tokens[i]));
            }
            return list;
        }
        public List<double> GetCubicCapacity(string[] tokens)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < tokens.Length; i += 2)
            {
                list.Add(double.Parse(tokens[i + 1]));
            }
            return list;
        }
    }
}
