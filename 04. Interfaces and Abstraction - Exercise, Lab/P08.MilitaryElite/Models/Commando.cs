using System;
using System.Collections;
using System.Collections.Generic;
namespace _08_MilitaryElite.Models
{
    using System.Text;
    using _08_MilitaryElite.Contracts;

    public class Commando : Private, ISpecialable, ICommando
    {

        public Commando(string id, string firstName, string lastName, decimal salary, string corps, string[] missions)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
            this.Missions = SetMissions(missions);
        }

        public string Corps { get; set; }

        public ICollection<IMission> Missions { get; set; }

        private ICollection<IMission> SetMissions(string[] missions)
        {
            var allMissions = new List<IMission>();
            var mission = string.Empty;
            var stats = string.Empty;
            for (int i = 0; i < missions.Length - 1; i += 2)
            {
                try
                {
                    mission = missions[i];
                    stats = missions[i + 1];
                    var task = new Mission(mission, stats);
                    allMissions.Add(task);
                }
                catch (Exception)
                {
                }
                
            }

            return allMissions;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            builder.AppendLine($"Corps: {this.Corps}");
            builder.AppendLine("Missions:");


            foreach (var mission in this.Missions)
            {
                builder.Append(mission.ToString());
            }

            return builder.ToString();
        }
    }
}
