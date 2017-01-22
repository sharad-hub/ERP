
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Other
{
  public class LogEntity
    {
        public Nullable<int> UserID { get; set; }
        public string UserName { get; set; }
        public string MethodName { get; set; }
        public string MessageToLog { get; set; }
    }
}
