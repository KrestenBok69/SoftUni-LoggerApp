using LoggerApp.Loggers;
using System;

namespace LoggerApp.Utility
{
    /// <summary>
    /// Communicates with the console, taking user input
    /// </summary>
    public static class CommandInterpreter
    {
        //Takes all user commands and gives them
        //to the logger
        public static void InterpretCommand(ILogger logger)
        {
            string input = Console.ReadLine();
            while(input != "END")
            {
                string[] command = input.Split('|');
                string reportLevel = command[0];
                string time = command[1];
                string message = command[2];

                switch (reportLevel.ToUpper())
                {
                    case "INFO":
                        logger.Info(time, message);
                        break;

                    case "WARNING":
                        logger.Warning(time, message);
                        break;

                    case "ERROR":
                        logger.Error(time, message);
                        break;

                    case "CRITICAL":
                        logger.Critical(time, message);
                        break;

                    case "FATAL":
                        logger.Fatal(time, message);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }
            
            
        }
    }
}
