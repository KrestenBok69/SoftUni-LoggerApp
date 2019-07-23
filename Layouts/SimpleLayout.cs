namespace LoggerApp.Layouts
{
    /// <summary>
    /// Used by appenders to specify a string format
    /// </summary>
    public class SimpleLayout : ILayout
    {

        //<date-time> - <report level> - <message>
        public string Format => "{0} - {1} - {2}";
    }
}
