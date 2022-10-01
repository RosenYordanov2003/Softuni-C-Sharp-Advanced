using System;
using System.Collections.Generic;
using System.Text;

namespace Special_Cars
{
    public class Tires
    {
        private int year;
        private double pressure;
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }
        public List<int> GetYears(string[] tokens)
        {
            List<int> years = new List<int>();
            for (int i = 0; i < tokens.Length; i += 2)
            {
                years.Add(int.Parse(tokens[i]));
            }
            return years;
        }
        public List<double> GetPressure(string[] tokens)
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
