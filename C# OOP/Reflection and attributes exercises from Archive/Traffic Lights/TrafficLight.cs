using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLights
{
    public class TrafficLight
    {
        public Dictionary<string,string> _trafficLights = new Dictionary<string,string>
        {
            {"Green","Yellow"},
            {"Yellow","Red"},
            {"Red","Green"}
        };

        public string Light(string currentLight)
        {
            return _trafficLights[currentLight];    
        }
    }
}
