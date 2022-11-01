using Border_Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Robot : IIDentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model
        {
            get { return model; }
           private set { model = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
