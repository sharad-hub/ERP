using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Logging
{
    /// <summary>
    /// LogUtility class implements the basic functionality required for logging such as building log message
    /// </summary>
    public sealed class LogUtility
    {
        private LogUtility()
        {

        }
        /// <summary>
        /// BuildExceptionMessage method builds the logging message
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string BuildExceptionMessage(Exception exception)
        {

            Exception logException = exception;

            if (exception.InnerException != null)

                logException = exception.InnerException;

            StringBuilder sbErrorMsg = new StringBuilder();

            //sbErrorMsg.Append( Environment.NewLine + "Error in Path :" + System.Web.HttpContext.Current.Request.Path);
            //// Get the QueryString along with the Virtual Path
            //sbErrorMsg += Environment.NewLine + "Raw Url :" + System.Web.HttpContext.Current.Request.RawUrl;

            // Get the error message
            sbErrorMsg.Append(Environment.NewLine);
            sbErrorMsg.Append("Message :" + logException.Message);

            // Source of the message
            sbErrorMsg.Append(Environment.NewLine);
            sbErrorMsg.Append("Source :" + logException.Source);

            // Stack Trace of the error
            sbErrorMsg.Append(Environment.NewLine);
            sbErrorMsg.Append("Stack Trace :" + logException.StackTrace);

            // Method where the error occurred
            sbErrorMsg.Append(Environment.NewLine);
            sbErrorMsg.Append("TargetSite :" + logException.TargetSite);

            return sbErrorMsg.ToString();


        }

    }
}
