namespace _08_MilitaryElite.Models
{
    using _08_MilitaryElite.Contracts;
    using System;

    public class Mission : IMission
    {
        private string state;

        public Mission(string codename, string state)
        {
            this.CodeName = codename;
            this.State = state;
        }

        public string State
        {
            get => this.state;
            private set
            {
                if (value != "inProgress" && value != "Finished" )
                {
                   throw new ArgumentException();
               }
                this.state = value;
            }
        }

        public string CodeName { get; set; }

        public void CompleteMission()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}{Environment.NewLine}";
        }
    }
}
