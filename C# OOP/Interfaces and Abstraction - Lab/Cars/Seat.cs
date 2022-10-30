using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color} Seat {Model}";
        }
    }
}
