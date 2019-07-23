using LoggerApp.Appenders;
using LoggerApp.Layouts;
using LoggerApp.Loggers;
using System;
using System.Collections.Generic;

namespace LoggerApp.Interpreters
{
    /// <summary>
    /// Takes information from user input to create a logger
    /// </summary>
    public static class LoggerFactory
    {
        //All the appenders meant to be added to the logger
        private static List<IAppender> appenders = new List<IAppender>();
        public static Logger CreateLogger(int appenderNum)
        {
            for (int i = 0; i < appenderNum; i++)
            {
                //TODO: Have this read from the CommandInterpreter rather than the Console
                string[] appenderInfo = Console.ReadLine().Split();
                string appenderType = appenderInfo[0];
                string layoutType = appenderInfo[1];
                ReportLevel reportLevel = 0;
                if (appenderInfo.Length == 3)
                {
                    reportLevel = (ReportLevel)ReportLevel.Parse(typeof(ReportLevel), appenderInfo[2]);
                }

                //Creates the layout
                ILayout layout = LayoutFactory.CreateLayout(layoutType);

                //Creates the appender with the corresponding layout
                IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);

                appenders.Add(appender);
            }

            //Returns the logger, with all the appenders from the list
            var logger = new Logger(appenders.ToArray());
            return logger;
        }
    }
}
