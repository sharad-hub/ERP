using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Logging;
namespace ERP.Services
{
   
  public class LoggerService : ILoggerService
    {      
       public void LogError(string message)
        {
            LogManager.Instance.Error(message);
        }
        public void LogInfo(string message)
        {
            LogManager.Instance.Info(message);
        }
        public void LogTrace(string message)
        {
            LogManager.Instance.Trace(message);
        }

        public void LogInfo<T>(T type,string message)
        {
            LogManager.Instance.Info(message);
        }
    }
}
