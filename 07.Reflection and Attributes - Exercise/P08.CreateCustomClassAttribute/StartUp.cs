using System;

namespace P08.CreateCustomClassAttribute
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Type classType = typeof(Weapon);

            object[] attributes = classType
                .GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                ClassAttribute classAttr = attribute as ClassAttribute;

                if (classAttr != null)
                {
                    string command;

                    while ((command = Console.ReadLine()) != "END")
                    {
                        switch (command)
                        {
                            case "Author":
                                Console.WriteLine($"Author: {classAttr.Author}");
                                break;
                            case "Revision":
                                Console.WriteLine($"Revision: {classAttr.Revision}");
                                break;
                            case "Description":
                                Console.WriteLine($"Class description: {classAttr.Description}");
                                break;
                            case "Reviewers":
                                Console.WriteLine($"Reviewers: { string.Join(", ", classAttr.Reviewers)}");
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
           
        }
    }
}
