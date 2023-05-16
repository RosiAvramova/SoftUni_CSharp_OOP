using MortalEngines.IO.Contracts;
using System;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        public string ReadCommands()
        {
            return Console.ReadLine();
        }


    }
}