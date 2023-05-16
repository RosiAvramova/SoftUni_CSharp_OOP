﻿
using P01.Logger.Appenders.Contracts;
using P01.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

public class CommandInterpreter : ICommandInterpreter
{
    private ICollection<IAppender> appenders;
    private IAppenderFactory appenderFactory;
    private ILayoutFactory layoutFactory;

    public CommandInterpreter()
    {
        this.appenders = new List<IAppender>();
        this.appenderFactory = new AppenderFactory();
        this.layoutFactory = new LayoutFatory();
    }

    public void AddAppender(string[] args)
    {
        string typeAppender = args[0];
        string typeLayout = args[1];

        ReportLevel reportLevel = ReportLevel.INFO;

        if (args.Length == 3)
        {
            reportLevel = Enum.Parse<ReportLevel>(args[2]);
        }

        ILayout layout = this.layoutFactory.CreateLayout(typeLayout);

       IAppender appender = this.appenderFactory.CreateAppender(typeAppender, layout);

        appender.ReportLevel = reportLevel;

        appenders.Add(appender);
    }

    public void AddReport(string[] args)
    {
        string reportType = args[0];
        string dateTime = args[1];
        string message = args[2];

        ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportType);

        foreach (var appender in appenders)
        {
            appender.Append(dateTime, reportLevel, message);
        }
    }

    public void PrintInfo()
    {
        Console.WriteLine("Logger info");
        foreach (var appender in appenders)
        {
            Console.WriteLine(appender);
        }
    }
}

