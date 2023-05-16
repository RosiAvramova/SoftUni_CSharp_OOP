namespace _08_MilitaryElite
{
    using _08_MilitaryElite.Contracts;
    using _08_MilitaryElite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var soldiers = new List<ISoldier>();

            var line = string.Empty;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split();
                var soldierRank = tokens[0];
                var soldierId = tokens[1];
                var soldierFirstName = tokens[2];
                var soldierLastName = tokens[3];
                var soldierSalary = 0.0m;

                switch (soldierRank)
                {
                    case "Private":
                        soldierSalary = decimal.Parse(tokens[4]);

                        var privateSoldier = new Private(soldierId, soldierFirstName, soldierLastName, soldierSalary);
                        soldiers.Add(privateSoldier);

                        break;

                    case "LieutenantGeneral":
                        soldierSalary = decimal.Parse(tokens[4]);
                        ICollection<ISoldier> subalterns = new List<ISoldier>();

                        foreach (var id in tokens.Skip(5))
                        {
                            subalterns.Add(soldiers.FirstOrDefault(s => s.Id == id));
                        }

                        var lieutenant = new LieutenantGeneral(soldierId, soldierFirstName, soldierLastName, soldierSalary, subalterns);
                        soldiers.Add(lieutenant);

                        break;

                    case "Engineer":
                        soldierSalary = decimal.Parse(tokens[4]);
                        var engineerCorps = tokens[5];

                        try
                        {
                            var engineer = new Engineer(soldierId, soldierFirstName, soldierLastName, soldierSalary, engineerCorps, tokens.Skip(6).ToArray());
                            soldiers.Add(engineer);
                        }

                        catch (Exception)
                        {
                        }
                        
                        break;

                    case "Commando":
                        soldierSalary = decimal.Parse(tokens[4]);
                        var commandoCorps = tokens[5];

                        var commando = new Commando(soldierId, soldierFirstName, soldierLastName, soldierSalary, commandoCorps, tokens.Skip(6).ToArray());
                        soldiers.Add(commando);

                        break;

                    case "Spy":
                        var codeNumber = int.Parse(tokens[4]);

                        var spy = new Spy(soldierId, soldierFirstName, soldierLastName, codeNumber);
                        soldiers.Add(spy);

                        break;

                    default:
                        break;
                }
            }
            foreach (var soldier in soldiers)
            {
                Console.Write(soldier);
            }
        }
    }
}
