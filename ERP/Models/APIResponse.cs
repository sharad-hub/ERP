 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    /// <summary>
    /// Used to extend the API response, for instance; we want to recieve an object(entity) from API.
    /// </summary>
    public class APIResponse//<T> 
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string CaseId { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorContent { get; set; }      
    }
    public class APIResponseError
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ErrorLog Error { get; set; }
    }
    public class ApiException : Exception
    {
        private string _dcMessage = string.Empty;
        public int ErrorId { get; set; }

        public string DcMessage
        {
            get
            {
                return _dcMessage ?? string.Empty;
            }
            set
            {
                _dcMessage = value;
            }
        }
        public ApiException()
            : base() { }

        public ApiException(string message)
            : base(message) { }

        public ApiException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ApiException(string message, Exception innerException)
            : base(message, innerException) { }

        public ApiException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}