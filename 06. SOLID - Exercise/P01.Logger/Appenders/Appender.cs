﻿using P01.Logger.Appenders.Contracts;
using P01.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


public abstract class Appender : IAppender
{

    protected Appender(ILayout layout)
    {
        this.Layout = layout;
    }

    protected ILayout Layout { get; }

    public ReportLevel ReportLevel { get; set; }

    public int MessagesCount { get; protected set; } 

    public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
     
}

