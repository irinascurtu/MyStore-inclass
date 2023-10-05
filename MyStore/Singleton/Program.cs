// See https://aka.ms/new-console-template for more information
using Singleton;

Console.WriteLine("Hello, World!");

Logger logger = Logger.GetInstance();
logger.Log("This is a log message");
logger.Log(Logger.Count.ToString());
Console.WriteLine("---------------------");
Logger logger2 = Logger.GetInstance();
logger.Log("This is a log message from logger 2!");
logger.Log(Logger.Count.ToString());

Console.ReadLine();