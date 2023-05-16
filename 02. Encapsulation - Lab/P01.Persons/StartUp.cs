namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var commandArgs = Console.ReadLine().Split();
                Person person = new Person(commandArgs[0], commandArgs[1], int.Parse(commandArgs[2]));
                persons.Add(person);
            }

            persons
                .OrderBy(n => n.FirstName)
                .ThenBy(a => a.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
