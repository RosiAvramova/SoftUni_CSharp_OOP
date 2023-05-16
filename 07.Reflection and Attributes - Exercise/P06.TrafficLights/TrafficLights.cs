using System;
using System.Collections.Generic;
using System.Text;

namespace P06.TrafficLights
{
    public class TrafficLights
    {
        private Signal currentSignal;

        public TrafficLights(string signal)
        {
            this.currentSignal = (Signal)Enum.Parse(typeof(Signal), signal);
        }

        public void Update()
        {
            int previous = (int)currentSignal;

            currentSignal = (Signal)(++previous % Enum.GetNames(typeof(Signal)).Length);
        }
    }
}
