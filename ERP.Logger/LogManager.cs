using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Logger
{
    /// <summary>
    /// LogManager class returns an instance of class which implements logging 
    /// </summary>
    public sealed class LogManager
    {
        private readonly static ILogger logger = new NLogLogger();

        private LogManager()
        {
        }

        public static ILogger Instance
        {
            get
            {
                return logger;
            }
        }

    }
}
