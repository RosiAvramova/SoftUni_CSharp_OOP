namespace P3.Mankind
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Human
    {
        private const int MinLengthFirstName = 4;
        private const int MinLengthLastName = 3;

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                this.ValidateFirstLetterIsUpper(value, nameof(this.firstName));

                this.ValidateLenght(value, MinLengthFirstName, nameof(this.firstName));
                
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                this.ValidateFirstLetterIsUpper(value, nameof(this.lastName));

                this.ValidateLenght(value, MinLengthLastName, nameof(this.lastName));

                this.lastName = value;
            }
        }

        private void ValidateLenght(string value, int validLength, string parameterName)
        {
            if (value.Length < validLength)
            {
                throw new ArgumentException($"Expected length at least {validLength} symbols! Argument: {parameterName}");
            }
        }

        private void ValidateFirstLetterIsUpper(string value, string parameterName)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {parameterName}");
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.firstName}");
            sb.AppendLine($"Last Name: {this.lastName}");
            return sb.ToString().TrimEnd();
        }
    }
}
