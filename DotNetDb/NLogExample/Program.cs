using System;
using NLog.Web;
using System.IO;

namespace NlogExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";

            // create instance of Logger
            var logger = NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            // log sample messages
            // logger.Trace("Sample trace message");
            // logger.Debug("Sample debug message");
            // logger.Info("Sample informational message");
            // logger.Warn("Sample warning message");
            // logger.Error("Sample error message");
            // logger.Fatal("Sample fatal error message");

            // // NLog supports structured messages
            // var fruit = new[] { "bananas", "apples", "pears" };
            // logger.Info("I like to eat {Fruit}", fruit);


            // Example of logging an exception
            try
            {
                int x = 10;
                int y = 0;
                Console.WriteLine(x / y);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }
    }
}