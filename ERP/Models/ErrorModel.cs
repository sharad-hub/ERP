using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class ErrorModel : Exception
    {
        
        public string FullDescription { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int HttpCode { get; set; }
        public bool IsSessionExpired { get; set; }
    }

    public partial class ErrorLog
    {
        public int ID { get; set; }
        public int ErrorID { get; set; }
        public DateTime Errored { get; set; }
        public string UserName { get; set; }
        public string Details { get; set; }
    }
}