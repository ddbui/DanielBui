using log4net;
using log4net.Config;
using Prism.Logging;

namespace MissionPlanner.Logging
{
    public class Logger : ILoggerFacade
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Logger));

        public Logger()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Log message based on category
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        /// <param name="priority">Priority is ignored</param>
        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    _logger.Debug(message);
                    break;

                case Category.Warn:
                    _logger.Warn(message);
                    break;

                case Category.Exception:
                    _logger.Error(message);
                    break;

                case Category.Info:
                    _logger.Info(message);
                    break;
            }
        }
    }
}
