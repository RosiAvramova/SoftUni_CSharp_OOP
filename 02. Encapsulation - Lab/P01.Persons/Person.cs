namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string secondName, int age)
        {
            this.FirstName = firstName;
            this.LastName = secondName;
            this.Age = age;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }

    }
}
