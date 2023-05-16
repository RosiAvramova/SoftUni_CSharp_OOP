using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;
using System;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager machinesManager;
        private IReader reader;
        private IWriter writer;
        public Engine(MachinesManager manager, IReader reader, IWriter writer)
        {
            this.machinesManager = manager;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            while (true)
            {
                var inputArgs = this.reader.ReadCommands().Split();
                if (inputArgs[0] == "Quit")
                {
                    break;
                }
                var command = inputArgs[0];
                var result = string.Empty;
                try
                {
                    switch (command)
                    {
                        case "HirePilot":
                            result = this.machinesManager.HirePilot(inputArgs[1]);
                            break;

                        case "PilotReport":
                            result = this.machinesManager.PilotReport(inputArgs[1]);
                            break;

                        case "ManufactureTank":
                            result = this.machinesManager.ManufactureTank(inputArgs[1], double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));
                            break;

                        case "ManufactureFighter":
                            result = this.machinesManager.ManufactureFighter(inputArgs[1], double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));
                            break;

                        case "MachineReport":
                            result = this.machinesManager.MachineReport(inputArgs[1]);
                            break;

                        case "AggressiveMode":
                            result = this.machinesManager.ToggleFighterAggressiveMode(inputArgs[1]);
                            break;

                        case "DefenseMode":
                            result = this.machinesManager.ToggleTankDefenseMode(inputArgs[1]);
                            break;

                        case "Engage":
                            result = this.machinesManager.EngageMachine(inputArgs[1], inputArgs[2]);
                            break;

                        case "Attack":
                            result = this.machinesManager.AttackMachines(inputArgs[1], inputArgs[2]);
                            break;
                    }

                    this.writer.Write(result);
                }

                catch (Exception msg)
                {
                    this.writer.Write($"Error: {msg.Message}");
                }
            }
        }
    }
}