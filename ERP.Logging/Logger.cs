using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace ERP.Logging
{
    /// <summary>
    /// NLogLogger class implements all the required functionality for logging
    /// </summary>
    public class NLogLogger : ILogger
    {
        private Logger logger;

        #region Constructors
        public NLogLogger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public NLogLogger(string name)
        {
            logger = NLog.LogManager.GetLogger(name);
        }
        #endregion

        #region Info
        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Info<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            logger.Info(message, argument1, argument2);
        }

        public void Info<TArgument1>(string message, TArgument1 argument1)
        {
            logger.Info(message, argument1);
        }
        #endregion

        #region Warn
        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Warn<TArgument1>(string message, TArgument1 argument1)
        {
            logger.Warn(message, argument1);
        }

        public void Warn<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            logger.Warn(message, argument1, argument2);
        }

        #endregion

        #region Debug
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Debug<TArgument1>(string message, TArgument1 argument1)
        {
            logger.Debug(message, argument1);
        }

        public void Debug<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            logger.Debug(message, argument1, argument2);
        }
        #endregion

        #region Error
        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(string message, Exception x)
        {
            logger.Error(x, message);
        }

        public void Error<TArgument1>(string message, TArgument1 argument1)
        {
            logger.Error(message, argument1);
        }

        public void Error<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            logger.Error(message, argument1, argument2);
        }

        public void Error(Exception x)
        {
            Error(LogUtility.BuildExceptionMessage(x));
        }

        #endregion

        #region Fatal
        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public void Fatal<TArgument1>(string message, TArgument1 argument1)
        {
            logger.Fatal(message, argument1);
        }

        public void Fatal<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            logger.Fatal(message, argument1, argument2);
        }

        public void Fatal(Exception x)
        {
            Fatal(LogUtility.BuildExceptionMessage(x));
        }
        #endregion

        #region Trace

        public void Trace(string message)
        {
            logger.Trace(message);

        }

        public void Trace<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            logger.Trace(message, argument1, argument2);
        }

        public void Trace<TArgument1>(string message, TArgument1 argument1)
        {
            logger.Trace(message, argument1);
        }
        #endregion
    }
}
