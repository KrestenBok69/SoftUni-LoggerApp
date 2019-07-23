using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoggerApp.Appenders;

namespace LoggerApp.Loggers
{
    /// <summary>
    /// Uses its appenders to log messages
    /// to any given place (i.e. console, file, winform etc.)
    /// </summary>
    public class Logger : ILogger
    {
        //Keeps a list of all its appenders
        //so as to write to all outputs with one method
        public List<IAppender> Appenders { get; }

        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders.ToList();
        }

        //All the different types of reportLevels
        //Add any new reportLevel entries here
        public void Error(string dateTime, string message)
        {
            string reportLevel = "ERROR";
            Log(dateTime, reportLevel, message);
        }

        public void Info(string dateTime, string message)
        {
            string reportLevel = "INFO";
            Log(dateTime, reportLevel, message);
            
        }

        public void Warning(string dateTime, string message)
        {
            string reportLevel = "WARNING";
            Log(dateTime, reportLevel, message);
        }

        public void Critical(string dateTime, string message)
        {
            string reportLevel = "CRITICAL";
            Log(dateTime, reportLevel, message);
        }

        public void Fatal(string dateTime, string message)
        {
            string reportLevel = "FATAL";
            Log(dateTime, reportLevel, message);
        }

        //Used at the end of the application
        //Returns all logger info
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Logger info" + Environment.NewLine);
            foreach (var appender in Appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().Trim();
        }

        //Appends the message to all outputs
        private void Log(string dateTime, string reportLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }
    }
}
