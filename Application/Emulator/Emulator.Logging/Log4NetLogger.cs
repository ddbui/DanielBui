using log4net;
using Prism.Logging;
using System;

namespace Emulator.Logging
{
    /// <summary>
    /// Log4NetLogger, our first logging option.
    /// </summary>
    public class Log4NetLogger : ILoggerFacade
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(Log4NetLogger));

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    logger.Debug(message);
                    break;

                case Category.Exception:
                    logger.Error(message);
                    break;

                case Category.Info:
                    logger.Info(message);
                    break;

                case Category.Warn:
                    logger.Warn(message);
                    break;

                default:
                    break;

            }
        }
    }
}
