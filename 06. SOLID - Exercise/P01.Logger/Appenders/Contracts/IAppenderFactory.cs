using P01.Logger.Appenders.Contracts;
using P01.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

public interface IAppenderFactory
{
    IAppender CreateAppender(string type, ILayout layout);
}

