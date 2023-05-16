using MortalEngines.Core;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using MortalEngines.IO;
using System.Collections.Generic;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            var reader = new Reader();
            var writer = new Writer();

            var pilots = new List<IPilot>();
            List<IMachine> machines = new List<IMachine>();
            TankFactory tankFactory = new TankFactory();
            FighterFactory fighterFactory = new FighterFactory();
            var machineManager = new MachinesManager();
            var engine = new Engine(machineManager, reader, writer);

            engine.Run();
        }
    }
}