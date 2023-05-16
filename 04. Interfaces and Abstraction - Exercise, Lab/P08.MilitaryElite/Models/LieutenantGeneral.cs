namespace _08_MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

   public class LieutenantGeneral : Private, ILieutenant
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, ICollection<ISoldier> privates)
            :base(id, firstName, lastName, salary)
        {
            this.Privates = new List<ISoldier>(privates);
        }
        public ICollection<ISoldier> Privates { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            builder.AppendLine("Privates:");

            foreach (var soldier in Privates)
            {
                builder.Append(soldier.ToString());
            }

            return builder.ToString();
        }
    }
}
