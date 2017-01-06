using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DTO
{
    public class ErrorLog
    {
        public int ID { get; set; }
        public int ErrorID { get; set; }
        public DateTime Errored { get; set; }
        public string UserName { get; set; }
        public string Details { get; set; }
    }

    public class ERPException : Exception
    {
        public Int64 ErrorNumber;
        public string ErrorDesc;

        public string ErrorSource;
        public ERPException(Int64 ErrorNumber, string ErrorDesc, string ErrorSource)
            : base()
        {

            this.ErrorNumber = ErrorNumber;
            this.ErrorDesc = ErrorDesc;
            this.ErrorSource = ErrorSource;

        }

        public ERPException()
            : base()
        {

            this.ErrorNumber = -1;
            this.ErrorDesc = "Unknown error";
            this.ErrorSource = "Unknown source";

        }


        public ERPException(ERPException EX)
        {
            this.ErrorNumber = EX.ErrorNumber;
            this.ErrorDesc = EX.ErrorDesc;
            this.ErrorSource = EX.ErrorSource;

        }

        public ERPException(Exception EX)
            : base("", EX)
        {

            this.ErrorNumber = -1;
            this.ErrorDesc = EX.Message;
            this.ErrorSource = EX.Source;
        }


        public ERPException(Exception EX, Int64 ErrorNumber, string ErrorDesc, string ErrorSource)
            : base("Inner Exception", EX)
        {

            this.ErrorNumber = ErrorNumber;
            this.ErrorDesc = ErrorDesc;
            this.ErrorSource = ErrorSource;

        }
    }
}
