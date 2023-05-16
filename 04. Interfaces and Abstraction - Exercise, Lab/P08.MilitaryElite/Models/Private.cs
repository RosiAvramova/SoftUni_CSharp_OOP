namespace _08_MilitaryElite.Models
{
    using _08_MilitaryElite.Contracts;
    using System;

    public class Private : Soldier, ISoldier
    {
        public Private(string id, string firstName, string lastName, decimal salary)
            :base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public  override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}";
        }
    }
}
