using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Extensions
{
    public class LogHelper
    {
        public static string GetLogString(string userName, string methodName, string data)
        {
            return String.Format("UserName:{0}, Method Name:{1}, Data{2}", userName, methodName, data);
        }
    }
}