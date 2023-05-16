namespace _08_MilitaryElite.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer<RepairTask>
    {

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, string[] repairs)
                : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = SetRepairs(repairs);
        }

        public ICollection<RepairTask> Repairs { get; set; }

        private List<RepairTask> SetRepairs(string[] repairs)
        {
            var part = string.Empty;
            var hours = 0;
            var tasks = new List<RepairTask>();

            for (int i = 0; i < repairs.Count() - 1; i+=2)
            {
                
                part = repairs[i];
                hours = int.Parse(repairs[i + 1]);
                var task = new RepairTask(part, hours);
                tasks.Add(task);
            }

            return tasks;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            builder.AppendLine($"Corps: {this.Corps}");
            builder.AppendLine("Repairs:");

            foreach (var task in this.Repairs)
            {
                builder.AppendLine(task.ToString());
            }

            return builder.ToString();
        }
    }
}
