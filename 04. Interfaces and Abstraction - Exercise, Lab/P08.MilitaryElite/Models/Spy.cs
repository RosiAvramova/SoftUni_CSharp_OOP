using _08_MilitaryElite.Contracts;
using System.Text;

namespace _08_MilitaryElite.Models
{
    class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName,  int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            builder.AppendLine($"Code Number: {this.CodeNumber}");

            return builder.ToString();
        }
    }
}
