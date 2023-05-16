namespace _08_MilitaryElite.Models
{
    using Contracts;
    using System;

    public class SpecialisedSoldier : Private, ISpecialable, ISoldier
    {
        private string corps;
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salaty, string corps)
            : base(id, firstName, lastName, salaty)
        {
            this.Corps = corps;
        }
        public string Corps
        {
            get => this.corps;
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException();
                }
                this.corps = value;
            }
        }
    }
}
