using LoggerApp.Interpreters;
using LoggerApp.Loggers;
using LoggerApp.Utility;
using System;

namespace LoggerApp
{
    public class Program
    {
        static void Main()
        {
            //TODO: Validation needs to be added

            //Gets the number of appenders wanted from the user's input
            int numberOfAppenders = int.Parse(Console.ReadLine());

            //Creates a logger with (n) number of appenders
            Logger logger = LoggerFactory.CreateLogger(numberOfAppenders);

            //Reads the user's input from the console
            //and gives it to the logger
            CommandInterpreter.InterpretCommand(logger);

            //Prints all logger information
            //to the console
            Console.WriteLine(logger);
        }
    }
}
