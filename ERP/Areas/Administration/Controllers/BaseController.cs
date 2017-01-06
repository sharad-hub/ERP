using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ERP.Areas.Administration.Controllers
{
    [HandleError]
    public class BaseController<TSource> : Controller
    {
        private const string LogOnSession = "LogOnSession";
        private const string ErrorController = "Error";
        private const string LogOnController = "Account";
        private const string LogOnAction = "Index";

       
       // protected ILogger _logger;

        protected BaseController()
        {
           // _logger = LogManager.Instance;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            /*important to check both, because logOnController should be access able with out any session*/
            if (!IsNonSessionController(requestContext) && !HasSession())
            {
                // Rederect(requestContext, Url.Action(LogOnAction, LogOnController));
            }
        }

        private static bool IsNonSessionController(RequestContext requestContext)
        {
            var currentController = requestContext.RouteData.Values["controller"].ToString().ToLower();
            var nonSessionedController = new List<string>() { ErrorController.ToLower(), LogOnController.ToLower() };
            return nonSessionedController.Contains(currentController);
        }

        private static void Rederect(RequestContext requestContext, string action)
        {
            requestContext.HttpContext.Response.Clear();
            requestContext.HttpContext.Response.Redirect(action);
            requestContext.HttpContext.Response.End();
        }

        protected bool HasSession()
        {
            return Session[LogOnSession] != null;
        }

        public TSource LogOnSessionModel
        {
            get
            {
                return (TSource)this.Session[LogOnSession];
            }
            set
            {
                Session[LogOnSession] = value;
            }
        }

       
        protected TSource GetLogOnSessionModel
        {
            get
            {
                return (TSource)this.Session[LogOnSession];
            }
        }

        protected void SetLogOnSessionModel(TSource model)
        {
            Session[LogOnSession] = model;
        }

        protected void AbandonSession()
        {
            if (HasSession())
            {
                Session.Abandon();
            }
        }

        //#region Error and Logging

        //public void Info(string message)
        //{
        //    AddMessage(message, LogMessageType.Info);
        //}

        //public void Error(string message)
        //{
        //    AddMessage(message, LogMessageType.Error);
        //}

        //private void AddMessage(string message, LogMessageType type)
        //{
        //    var messages = new List<LogMessage>();

        //    if (TempData["MessageForView"] != null)
        //        messages = (List<LogMessage>)TempData["MessageForView"];

        //    messages.Add(new LogMessage { LogMessageType = type, Message = message });

        //    TempData["MessageForView"] = messages;
        //}

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes")]
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    // Fail if we can't do anything; app will crash.
        //    if (filterContext == null)
        //        return;

        //    // Get exception from filter context
        //    var ex = filterContext.Exception ?? new Exception("No further information exists.");

        //    filterContext.ExceptionHandled = true;

        //    var data = new ErrorViewModel
        //    {
        //        ErrorMessage = HttpUtility.HtmlEncode(ex.Message),
        //        TheException = ex
        //    };

        //    filterContext.Result = View("Error", data);
        //}

        //#endregion Error and Logging
    }
}