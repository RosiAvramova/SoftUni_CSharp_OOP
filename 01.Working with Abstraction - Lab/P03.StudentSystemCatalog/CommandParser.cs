using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.StudentSystemCatalog
{
    public class CommandParser
    {
        public Command Parse(string input)
        {
            string[] parts = input.Split();
            string name = parts[0];
            string[] arguments = parts.Skip(1).ToArray();
            Command command = new Command(name, arguments);

            return command;
        }
    }
}
