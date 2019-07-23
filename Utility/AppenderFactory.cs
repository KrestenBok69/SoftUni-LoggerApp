using LoggerApp.Layouts;

namespace LoggerApp.Appenders
{
    /// <summary>
    /// Takes outside information to create an appender
    /// </summary>
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender = null;

            //Any new appenders have to be added here
            //for the factory to be able to produce them
            if (type == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, reportLevel);
            }
            else if (type == "FileAppender")
            {
                appender = new FileAppender(layout, new LogFile(), reportLevel);
            }

            return appender;
        }
    }
}
