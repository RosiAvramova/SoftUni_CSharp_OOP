namespace P06.BirthdayCelebrations.Models
{
    using P06.BirthdayCelebrations.Interfaces;
    using System;
  

    public class Pet : IName, IBirthable
    {
        public Pet(string name, string birthdata)
        {
           this.Name = name;
            this.Birthdata = DateTime.ParseExact(birthdata, "dd/mm/yyyy", null);
        }

        public DateTime Birthdata { get; private set; }

        public string Name { get; private set; }
    }
}
