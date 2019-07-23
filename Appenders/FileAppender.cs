using System;
using System.IO;
using System.Text;
using LoggerApp.Layouts;

namespace LoggerApp.Appenders
{
    /// <summary>
    /// Appends messages to a text file
    /// </summary>
    public class FileAppender : IAppender
    {
        //Keeps count of all the appended messages
        private int appendedMessages = 0;

        //Path to our txt file
        //Despite the code being incredibly ugly
        //This should end up in the project's "Output" subfolder,
        //instead of going into bin/Debug.... and so on.
        //Also works on all operating systems
        private readonly string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Output", "log.txt");

        //Layout can be given through the constructor, or injected through the property
        public ILayout Layout { get; }

        //Keeps all the messages appended to the file
        //and sums the size of all their characters
        public LogFile LogFile { get; }

        public StringBuilder Sb { get; }

        //Enumerator for all the report levels, from INFO to FATAL
        public ReportLevel ReportLevel { get; set; }

        //ReportLevel is optional, since it has a default value of INFO
        //meaning it appends all messages, unless told otherwise
        public FileAppender(ILayout layout, LogFile logFile, ReportLevel reportLevel = 0)
        {
            Layout = layout;
            LogFile = logFile;
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
                var text = Sb.ToString() + Environment.NewLine;
                File.AppendAllText(path, text);
                LogFile.Write(text);
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

            sb.AppendLine($"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {ReportLevel.ToString()},{Environment.NewLine}Messages appended: {appendedMessages}, File size: {LogFile.Size}");

            return sb.ToString();
        }
    }
}
