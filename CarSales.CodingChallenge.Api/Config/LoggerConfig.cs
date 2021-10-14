using Serilog;
using System;
using System.IO;

namespace CarSales.CodingChallenge.Api.Config
{
    public class LoggerConfig
    {
        public static void ConfigerLogging()
        {
            var time = DateTime.Now;
            var logFileName =
                $"Log\\{time.Year}{time.Month}{time.Day}.txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Join(AppContext.BaseDirectory, logFileName))
                .CreateLogger();
        }
    }
}
