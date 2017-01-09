using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
   public class AssignedModuleVm
    {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public bool Selected { get; set; }
        public int AccessTypeID { get; set; }
        public string AccessTypeName { get; set; }
    }
}
