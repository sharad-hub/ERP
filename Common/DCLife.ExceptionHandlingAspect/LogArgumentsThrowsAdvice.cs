using log4net;
using Spring.Aop;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DCLife.Exceptions
{
    // this advice will iterate through the arguments and call the ILog.Debug(object)
    public class LogArgumentsThrowsAdvice : IThrowsAdvice
    {

        //#region prop

        //private ILog Logger;

        //#endregion

        #region ctor

        public LogArgumentsThrowsAdvice()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //Logger = LogManager.GetLogger(this.GetType().Name);
        }

        #endregion

        #region Methods
        public void AfterThrowing(MethodInfo method, Object[] args, Object target, Exception exception)
        {
            //The AOP exception logger. You can log the exception the way you want.
            string preText = string.Empty;
            string allArgs = string.Empty;
            Guid id = Guid.NewGuid();
            if (exception is DCLifeException)
                return;
            if (args != null && args.Length > 0)
            {
                foreach (Object arg in args)
                {
                    allArgs = allArgs + "," + arg;
                }
            }
            if (allArgs.Length > 0)
                allArgs = allArgs.Substring(1);
            if (allArgs.Length == 0)
                allArgs = "NO_ARG_GIVEN"; //No Arguments are there

            //Logger.Debug(string.Format("Method Name={0}-Target={1}-AllArgs={2}-LogID={3}", method, target, allArgs, id));
            exception.HelpLink = id.ToString();
        }
        #endregion
    }
}
