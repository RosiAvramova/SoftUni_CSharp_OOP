using System;
using System.Collections.Generic;
using System.Reflection;

namespace P06.TrafficLights
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            TrafficLights[] trafficLights = new TrafficLights[input.Length];

            for (int i = 0; i < trafficLights.Length; i++)
            {
                trafficLights[i] = (TrafficLights)Activator.CreateInstance(typeof(TrafficLights), new object[] { input[i] });
            }

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                List<string> result = new List<string>();

                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.Update();

                    var field = typeof(TrafficLights).GetField("currentSignal", BindingFlags.Instance | BindingFlags.NonPublic);

                    result.Add(field.GetValue(trafficLight).ToString());
                }

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
