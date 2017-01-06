using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
  public  class MenuVM
    {
        public int MenuID { get; set; }
        public string MenueName { get; set; }
        public string MenuCode { get; set; }
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public bool IsSelectd { get; set; }
    }
}
