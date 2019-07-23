namespace LoggerApp
{
    /// <summary>
    /// Basic enumerator for all the reportLevels our application's messages might have
    /// As the code is still not as loosedly-coupled as I'd like,
    /// everytime a reportLevel is added, an if-check must be done 
    /// in the Logger and CommandInterpreter classes
    /// </summary>
    public enum ReportLevel
    {
            INFO,
            WARNING,
            ERROR,
            CRITICAL,
            FATAL
    }
}
