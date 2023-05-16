namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Pilots;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"{string.Format(OutputMessages.PilotExists, name)}";
            }

            var pilot = new Pilot(name);
            this.pilots.Add(pilot);
            return $"{string.Format(OutputMessages.PilotHired, name)}";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"{string.Format(OutputMessages.MachineExists, name)}";
            }

            var tank = (ITank)TankFactory.CreateTank(name, attackPoints, defensePoints);
            tank.ToggleDefenseMode();
            this.machines.Add(tank);

            return $"{string.Format(OutputMessages.TankManufactured, tank.Name, tank.AttackPoints, tank.DefensePoints)}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"{string.Format(OutputMessages.MachineExists, name)}";
            }

            var tank = (IFighter)FighterFactory.CreateFighter(name, attackPoints, defensePoints);
            tank.ToggleAggressiveMode();
            this.machines.Add(tank);
            var tankModeStatus = tank.AggressiveMode == true ? "ON" : "OFF";
            return $"{string.Format(OutputMessages.FighterManufactured, name, tank.AttackPoints, tank.DefensePoints, tankModeStatus)}";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilots.Any(p => p.Name == selectedPilotName))
            {
                return $"{string.Format(OutputMessages.PilotNotFound, selectedPilotName)}";
            }

            if (!this.machines.Any(m => m.Name == selectedMachineName))
            {
                return $"{string.Format(OutputMessages.MachineNotFound, selectedMachineName)}";
            }

            var tank = this.machines.First(m => m.Name == selectedMachineName);

            if (tank.Pilot != null)
            {
                return $"{string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName)}";
            }

            var pilot = this.pilots.First(p => p.Name == selectedPilotName);
            pilot.AddMachine(tank);
            tank.Pilot = pilot;
            return $"{string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName)}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!this.machines.Any(m => m.Name == attackingMachineName) || !this.machines.Any(m => m.Name == defendingMachineName))
            {
                if (!this.machines.Any(m => m.Name == attackingMachineName))
                {
                    return $"{string.Format(OutputMessages.MachineNotFound, attackingMachineName)}";
                }

                if (!this.machines.Any(m => m.Name == defendingMachineName))
                {
                    return $"{string.Format(OutputMessages.MachineNotFound, defendingMachineName)}";
                }

            }

            var attackingMachine = this.machines.First(m => m.Name == attackingMachineName);
            var defendingMachine = this.machines.First(m => m.Name == defendingMachineName);

            if (attackingMachine.HealthPoints <= 0 || defendingMachine.HealthPoints <= 0)
            {
                if (attackingMachine.HealthPoints == 0)
                {
                    return $"{string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName)}";
                }

                if (defendingMachine.HealthPoints == 0)
                {
                    return $"{string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName)}";
                }
            }

            attackingMachine.Attack(defendingMachine);
            return $"{string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints)}";
        }

        public string PilotReport(string pilotReporting)
        {
            if (!this.pilots.Any(p => p.Name == pilotReporting))
            {
                return $"{string.Format(OutputMessages.PilotNotFound, pilotReporting)}";
            }
            var pilot = this.pilots.First(p => p.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            if (!this.machines.Any(m => m.Name == machineName))
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }
            var machine = this.machines.First(m => m.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machines.Any(m => m.Name == fighterName))
            {
                var fighter = (IFighter)this.machines.First(m => m.Name == fighterName);
                fighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }

            return string.Format(OutputMessages.MachineNotFound, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machines.Any(m => m.Name == tankName))
            {
                var tank = (ITank)this.machines.First(m => m.Name == tankName);
                tank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }

            return string.Format(OutputMessages.MachineNotFound, tankName);
        }
    }
}