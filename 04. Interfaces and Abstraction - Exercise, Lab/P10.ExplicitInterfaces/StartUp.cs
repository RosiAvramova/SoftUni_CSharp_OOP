namespace P10.ExplicitInterfaces
{
    using P10.ExplicitInterfaces.Interfaces;
    using System;
    
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();

                string name = inputArgs[0];
                string country = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                IPerson person = new Citizen(name, age, country);
                Console.WriteLine(person.GetName());

                IResident resident = new Citizen(name, age, country);
                Console.WriteLine(resident.GetName());

                // Another why with casting.

                //Citizen citizen = new Citizen(name, age, country);
                //Console.WriteLine(((IPerson)citizen).GetName());
                //Console.WriteLine(((IResident)citizen).GetName());


                input = Console.ReadLine();
            }
        }
    }
}
