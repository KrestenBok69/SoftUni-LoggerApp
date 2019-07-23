using System.Text;

namespace LoggerApp.Layouts
{
    /// <summary>
    /// Used by appenders to specify a string format
    /// </summary>
    public class XmlLayout : ILayout
    {
        private readonly StringBuilder sb = new StringBuilder();
        private const string indentation = "    ";

        //<log>
        //  <date> date-time </date>
        //  <level> report-level </level>
        //  <message> message </message>
        //</log>
        public string Format
        {
            get
            {
                sb.Clear();
                sb.AppendLine("<log>");
                sb.AppendLine(indentation + "<date>{0}</date>");
                sb.AppendLine(indentation + "<level>{1}</level>");
                sb.AppendLine(indentation + "<message>{2}</message>");
                sb.Append("</log>");

                return sb.ToString();
            }
        }
    }
}
