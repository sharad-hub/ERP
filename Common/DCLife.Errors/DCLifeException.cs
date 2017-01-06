using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCLife.Exceptions
{
    public class DCLifeException : Exception
    {
        public Int64 ErrorNumber;
        public string ErrorDesc;

        public string ErrorSource;
        public DCLifeException(Int64 ErrorNumber, string ErrorDesc, string ErrorSource)
            : base()
        {

            this.ErrorNumber = ErrorNumber;
            this.ErrorDesc = ErrorDesc;
            this.ErrorSource = ErrorSource;

        }

        public DCLifeException()
            : base()
        {

            this.ErrorNumber = -1;
            this.ErrorDesc = "Unknown error";
            this.ErrorSource = "Unknown source";

        }


        public DCLifeException(DCLifeException EX)
        {
            this.ErrorNumber = EX.ErrorNumber;
            this.ErrorDesc = EX.ErrorDesc;
            this.ErrorSource = EX.ErrorSource;

        }

        public DCLifeException(Exception EX)
            : base("", EX)
        {

            this.ErrorNumber = -1;
            this.ErrorDesc = EX.Message;
            this.ErrorSource = EX.Source;
        }


        public DCLifeException(Exception EX, Int64 ErrorNumber, string ErrorDesc, string ErrorSource)
            : base("Inner Exception", EX)
        {

            this.ErrorNumber = ErrorNumber;
            this.ErrorDesc = ErrorDesc;
            this.ErrorSource = ErrorSource;

        }
    }
}
