namespace P06.BirthdayCelebrations.Models
{
    using System;
    using P06.BirthdayCelebrations.Interfaces;

    public class Citizen : IName, IIdentifiable, IBirthable
    {
        private int age;

        public Citizen(string name, int age, string id, string birthdata)
        {
            this.age = age;
          this.Name = name;
          this.Id = id;
            this.Birthdata = DateTime.ParseExact(birthdata, "dd/mm/yyyy", null);
        }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public DateTime Birthdata { get; private set; }
    }
}
