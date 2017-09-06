using NLog;
using NLog.Config;
using NLog.Targets;

namespace SharedKernel
{
    public static class Logger
    {

        private static readonly NLog.Logger _logger;
        
        static Logger()
        {
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties 
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";


            fileTarget.FileName = "${basedir}/file.txt";
            fileTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            fileTarget.ArchiveFileName = "${basedir}/{#}.Log.txt";
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Date;
            fileTarget.MaxArchiveFiles = 7;
            fileTarget.KeepFileOpen = false;
            fileTarget.ConcurrentWrites = true;


            // Step 4. Define rules
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;

            _logger = LogManager.GetLogger("AspNetCoreTestsLogger");

            // Example usage
            /*
            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("fatal log message");
            */
        }

        public static void Fatal(string msg)
        {
            _logger.Fatal(msg);
        }

        public static void Log(string msg)
        {
            _logger.Debug(msg);
        }

        public static void Trace(string msg)
        {
            _logger.Trace(msg);
        }
    }
}
