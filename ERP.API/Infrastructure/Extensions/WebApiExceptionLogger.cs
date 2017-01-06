
using ERP.Common;
using ERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace ERP.API.Infrastructure.Extensions
{
    class WebApiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {

            string logDetails = "Request Url->" + context.Request.RequestUri.ToString() + "   Error ->" + context.ExceptionContext.Exception.ToString();
            if (context.ExceptionContext.Exception is ERPException)
            {
                logDetails = "Request Url" + context.Request.RequestUri.ToString() + "   Error Stack->" + ((ERPException)context.ExceptionContext.Exception).ErrorDesc;
            }
            ErrorLog log = LogException(logDetails);
            context.Exception.HelpLink = log.ID.ToString();
        }

        public static ErrorLog LogException(string logDetails)
        {
            ICommonApi _commonApi = new CommonApi();
            ErrorLog log = new ErrorLog()
            {
                Details = logDetails,
                ErrorID = 1,
                UserName = "WebApi"
            };
            log = _commonApi.WriteLog(log);
            return log;
        }
    }
}