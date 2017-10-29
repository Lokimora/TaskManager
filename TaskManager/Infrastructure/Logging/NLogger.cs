using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace TaskManager.Infrastructure.Logging
{
    public class NLogger
    {
        private readonly string fileTargetName = "fileTarget";
        private const string loggerName = "sdsNLog";

        private LoggingConfiguration config;

        public NLogger()
        {
            config = new LoggingConfiguration();

            ConfigureFileLogger();

            LogManager.Configuration = config;
        }

        //public Logger GetLogger()
        //{
        //    return LogManager.GetLogger()

        //    return null;
        //}

        private void ConfigureFileLogger()
        {
            var fileTarget = new FileTarget
            {
                FileName = "${basedir}/logFile.txt",
                Layout = "${message}"
            };
            var fileRule = new LoggingRule("*", LogLevel.Debug, fileTarget);

            config.AddTarget(fileTargetName, fileTarget);
            config.LoggingRules.Add(fileRule);

          

        }


    }
}
