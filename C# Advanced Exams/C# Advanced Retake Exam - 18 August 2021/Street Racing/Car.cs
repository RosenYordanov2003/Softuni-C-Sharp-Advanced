using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
           this.Make = make;
           this.Model = model;
           this.LicensePlate = licensePlate;
           this.HorsePower = horsePower;
           this.Weight = weight;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Make: {this.Make}");
            stringBuilder.AppendLine($"Model: {this.Model}");
            stringBuilder.AppendLine($"License Plate: {this.LicensePlate}");
            stringBuilder.AppendLine($"Horse Power: {this.HorsePower}");
            stringBuilder.AppendLine($"Weight: {this.Weight}");
            return stringBuilder.ToString().Trim();
        }
    }
}
