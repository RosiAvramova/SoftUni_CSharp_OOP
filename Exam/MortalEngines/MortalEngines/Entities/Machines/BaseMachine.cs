using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Entities.Mashines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target is null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            var currentAttackPoints = this.AttackPoints - target.DefensePoints;
            target.HealthPoints -= currentAttackPoints;
            if (target.HealthPoints <= 0)
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"- {this.Name}");
            builder.AppendLine($" *Type: {this.GetType().Name}");
            builder.AppendLine($" *Health: {this.HealthPoints:f2}");
            builder.AppendLine($" *Attack: {this.AttackPoints:f2}");
            builder.AppendLine($" *Defense: {this.DefensePoints:f2}");
            var result = this.Targets.Any() ? $"{string.Join(", ", this.Targets)}" : "None";
            builder.AppendLine($" *Targets: {result}");

            return builder.ToString().TrimEnd();

        }
    }
}