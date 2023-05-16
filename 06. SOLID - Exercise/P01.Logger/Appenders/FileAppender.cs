using P01.Logger.Appenders.Contracts;
using P01.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class FileAppender : Appender
{
    private const string Path = @"..\..\..\log.txt";

    private ILogFile logFile;

    public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
    {
        this.logFile = logFile;
    }
        
    public override void Append(string dateTime, ReportLevel reportLevel, string message)
    {
        if (this.ReportLevel <= reportLevel)
        {
            this.MessagesCount++;

            string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;

            this.logFile.Write(content);

            File.AppendAllText(Path, content);
        }
    }

    public override string ToString()
    {
        return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
    }
}

