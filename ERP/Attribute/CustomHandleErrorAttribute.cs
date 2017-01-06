using Elmah;
using ERP.APIWrappers;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Attribute
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
            string errorId = string.Empty;

            if (ConfigurationManager.AppSettings["ErrorLogging"] == null || ConfigurationManager.AppSettings["ErrorLogging"] == "SQL")
            {
                try
                {
                    string controller = filterContext.RouteData.Values["controller"].ToString();
                    string action = filterContext.RouteData.Values["action"].ToString();
                    //string errorText = string.Format("{0}/{1}:{2}", controller, action, filterContext.Exception.ToString());
                    //If error is raised by WebApi
                    string errorText = string.Empty;
                    errorText = string.Format("{0}/{1}:{2}", controller, action, filterContext.Exception.ToString());

                    if (filterContext.Exception is ApiException)
                    {
                        errorText = "Web_Api_Error:" + ((ApiException)filterContext.Exception).ErrorId + ". " + ((ApiException)filterContext.Exception).DcMessage + " " + errorText;
                    }

                    APIResponseError result = CommonWrapper.PostException(new ERP.Models.ErrorLog()
                    {   
                        Details = errorText,
                        Errored = DateTime.Now,
                        ErrorID = 21,
                        UserName =  HttpContext.Current.User.Identity.Name//filterContext.CurrentUser().Name  
                    },
                      HttpContext.Current.User.Identity.Name); // second param should be UserName.
                    errorId = result.Error.ID.ToString();
                }
                catch (Exception ex)
                {
                    errorId = Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(filterContext.Exception));
                }
            }
            else
            {
                errorId = Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(filterContext.Exception));
            }
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = new JsonResult()
                {
                    Data = new { TicketId = errorId, Message = string.Format("Error Id: {0}, Some error has occoured. Please try again.", errorId), InternalError = filterContext.Exception.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                filterContext.Result = new RedirectResult("/Internal/Error/Index/" + errorId, false);
            }
            filterContext.ExceptionHandled = true;
        }

        public static string RaiseErrorSignal(ERP.Models.ErrorLog argException)
        {
            var context = HttpContext.Current;
            if (context == null)
                return string.Empty;

            var signal = ErrorSignal.FromContext(context);
            if (signal == null)
                return string.Empty;

            string errorId = string.Empty;

            if (ConfigurationManager.AppSettings["ErrorLogging"] == null || ConfigurationManager.AppSettings["ErrorLogging"] == "SQL")
            {
                try
                {
                    APIResponseError result = CommonWrapper.PostException(argException, "Token"); // second param should be UserName.
                    errorId = result.Error.ID.ToString();
                }
                catch (Exception ex)
                {
                    errorId = Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error()
                    {
                        Message = argException.Details
                    });
                }
            }
            else
            {
                errorId = Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error()
                {
                    Message = argException.Details
                });
            }


            return errorId;
        }
    }
}