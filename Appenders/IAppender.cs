using LoggerApp.Layouts;
using System.Text;

namespace LoggerApp.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }
        StringBuilder Sb { get; }
        void Append(string dateTime, string reportLevel, string message);
        ReportLevel ReportLevel { get; }
        string ToString();
    }
}
