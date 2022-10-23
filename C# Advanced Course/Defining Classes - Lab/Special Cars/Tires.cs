using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacture
{
    public class Tires
    {
        private int year;
        private double pressure;

        public Tires(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        public int Year { get; set; }
        public double Pressure { get; set; }



    }
}
