namespace P06.BirthdayCelebrations
{
    using P06.BirthdayCelebrations.Interfaces;
    using P06.BirthdayCelebrations.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IBirthable> names = new List<IBirthable>();

            while (input != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "Citizen")
                {
                    names.Add(new Citizen(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]));
                }
                else if (inputArgs[0] == "Pet")
                {
                    names.Add(new Pet(inputArgs[1], inputArgs[2]));
                }

                input = Console.ReadLine();
            }

            int specificYear = int.Parse(Console.ReadLine());

            names.Where(c => c.Birthdata.Year == specificYear)
            .Select(c => c.Birthdata)
            .ToList()
            .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));
        }
    }
}
