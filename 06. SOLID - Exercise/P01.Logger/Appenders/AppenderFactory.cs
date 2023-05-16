using System;
using System.Collections.Generic;
using System.Text;
using P01.Logger.Appenders.Contracts;
using P01.Logger.Layouts.Contracts;

public class AppenderFactory : IAppenderFactory
{
    public IAppender CreateAppender(string type, ILayout layout)
    {
        string typeAsLower = type.ToLower();

        switch (typeAsLower)
        {
            case "consoleappender":
                return new ConsoleAppender(layout);
            case "fileappender":
                return new FileAppender(layout, new LogFile());
            default:
                throw new ArgumentException("Invalid appender type");
        }
    }
}

