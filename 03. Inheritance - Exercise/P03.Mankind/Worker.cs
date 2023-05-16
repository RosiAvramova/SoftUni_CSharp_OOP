namespace P3.Mankind
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Worker : Human
    {
        private const string ErrorMessage = "Expected value mismatch! Argument: {0}";

        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            :base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get => this.weekSalary;
            private set
            {

                if (value <= 10)
                {
                    throw new ArgumentException(string.Format(ErrorMessage, nameof(this.weekSalary)));
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException(string.Format(ErrorMessage, nameof(this.workHoursPerDay)));
                }

                this.workHoursPerDay = value;
            }
        }

        public double CalculateSalaryPerHour()
        {
            return this.weekSalary / this.workHoursPerDay / 5;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Week Salary: {this.weekSalary:f2}");
            sb.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
            sb.AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
