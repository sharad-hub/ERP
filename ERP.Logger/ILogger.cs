using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Logger
{
    /// <summary>
    /// ILogger interface specifies all the methods required for logging which are implemented by the NLogLogger class
    /// </summary>
    public interface ILogger
    {
        void Info(string message);
        void Info<TArgument1>(string message, TArgument1 argument1);
        void Info<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2);

        void Warn(string message);
        void Warn<TArgument1>(string message, TArgument1 argument1);
        void Warn<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2);

        void Debug(string message);
        void Debug<TArgument1>(string message, TArgument1 argument1);
        void Debug<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2);

        void Error(string message);
        void Error<TArgument1>(string message, TArgument1 argument1);
        void Error<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2);
        void Error(string message, Exception x);
        void Error(Exception exception);

        void Fatal(string message);
        void Fatal<TArgument1>(string message, TArgument1 argument1);
        void Fatal<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2);
        void Fatal(Exception exception);

        void Trace(string message);
        void Trace<TArgument1>(string message, TArgument1 argument1);
        void Trace<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2);

    }
}
