using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Mashines;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const int initialHealthPoints = 200;
        private int health = initialHealthPoints;
        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            this.AggressiveMode = false;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }

            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            var agresiveModeStatus = AggressiveMode == true ? "ON" : "OFF";
            return base.ToString() + $"{Environment.NewLine} *Aggressive: {agresiveModeStatus}";
        }
    }
}