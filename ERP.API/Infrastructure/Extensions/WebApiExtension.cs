using ERP.Common;
using ERP.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace ERP.API.Infrastructure.Extensions
{
    public static class WebApiExtension
    {
        public static string ToJSON(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        public static HttpResponseMessage CreateBadRequestResponse(this ApiController controller, string content, string reasonPhrase)
        {
            //Log Error as HttpResponseException does not handle Global Error log :(
            //CAN WE FIND ANY BETTER APPROACH?
            string url = controller.Request.RequestUri.ToString();
            ErrorLog errorlogged = WebApiExceptionLogger.LogException(string.Format("Url->{0},Content->{1}, Reason->{2}", url, content, reasonPhrase));
            reasonPhrase = string.Format("Web_Api_Error:{0}.{1}", errorlogged.ID, reasonPhrase);
            var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(content),
                ReasonPhrase = reasonPhrase
            };

            return resp;
        }

        public static T GetObject<T>(this JToken request)
        {
            return request.ToObject<T>();
        }

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
}