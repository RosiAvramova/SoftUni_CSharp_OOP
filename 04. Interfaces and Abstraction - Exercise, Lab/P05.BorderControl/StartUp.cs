namespace P05.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs.Length == 3)
                {
                    identifiables.Add(new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]));
                }
                else if (inputArgs.Length == 2)
                {
                    identifiables.Add(new Robot(inputArgs[0], inputArgs[1]));
                }
                
                input = Console.ReadLine();
            }

            string lastDigits = Console.ReadLine();

            foreach (var identifiable in identifiables.Where(c => c.Id.EndsWith(lastDigits)))
            {
                Console.WriteLine(identifiable.Id);
            }

            //foreach (var identifiable in identifiables.Where(c => c.Id.EndsWith(lastDigits)).Select(c => c.Id))
            //{
            //    Console.WriteLine(identifiable);
            //}
        }
    }
}
