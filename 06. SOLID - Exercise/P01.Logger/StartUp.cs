
using P01.Logger.Appenders.Contracts;
using P01.Logger.Layouts;
using P01.Logger.Layouts.Contracts;

class StartUp
{
    static void Main(string[] args)
    {
        ICommandInterpreter commandInterpreter = new CommandInterpreter();

        Engine engine = new Engine(commandInterpreter);

        engine.Run(); 
    }
}

