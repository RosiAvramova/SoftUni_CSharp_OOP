using System;

namespace P03.StudentSystemCatalog
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                CommandParser commandParser = new CommandParser();
                Command command = commandParser.Parse(Console.ReadLine());

                try
                {
                    if (command.Name == "Create")
                    {
                        string name = command.Arguments[0];
                        int age = int.Parse(command.Arguments[1]);
                        double grade = double.Parse(command.Arguments[2]);
                        studentSystem.Add(name, age, grade);
                    }
                    else if (command.Name == "Show")
                    {
                        string name = command.Arguments[0];
                        Student student = studentSystem.Show(name);
                        Console.WriteLine(student);
                    }
                    else if (command.Name == "Exit")
                    {
                        break;
                    }
                }
                catch
                {
                    continue;
                }

            }
        }
    }
}
