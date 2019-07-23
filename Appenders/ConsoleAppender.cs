using System;
using System.Text;
using LoggerApp.Layouts;

namespace LoggerApp.Appenders
{
    /// <summary>
    /// Appends messages to the console
    /// </summary>
    public class ConsoleAppender : IAppender
    {
        //Keeps count of all the appended messages
        private int appendedMessages = 0;

        //Layout can be given through the constructor, or injected through the property
        public ILayout Layout { get; }

        public StringBuilder Sb { get; }

        //Enumerator for all the report levels, from INFO to FATAL
        public ReportLevel ReportLevel { get; set; }

        //ReportLevel is optional, since it has a default value of INFO
        //meaning it appends all messages, unless told otherwise
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = 0)
        {
            Layout = layout;
            ReportLevel = reportLevel;
            Sb = new StringBuilder();
        }

        //Appends the message, along with a date and report level
        public void Append(string dateTime, string reportLevel, string message)
        {
            //Parses the reportLevel to an integer, so as to check
            //if the message is a high enough reportLevel to be appended
            int lvl = (int)ReportLevel.Parse(typeof(ReportLevel), reportLevel);

            if(lvl >= (int)ReportLevel)
            {
                Sb.AppendFormat(Layout.Format, dateTime, reportLevel, message);
                Console.WriteLine(Sb.ToString());
                //Clearing the stringBuilder is important,
                //or else the second message will contain the entirety of the first aswell,
                //resulting in unwanted behaviour
                Sb.Clear();
                //Increments the message counter
                appendedMessages++;
            }
        }

        //Used at the end of the application, 
        //for listing all of the logger info
        public override string ToString()
        {
            var sb = new StringBuilder();
            var appenderType = this.GetType().Name;
            var layoutType = Layout.GetType().Name;

            sb.AppendLine($"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {ReportLevel.ToString()},{Environment.NewLine}Messages appended: {appendedMessages}");

            return sb.ToString();
        }
    }
}
