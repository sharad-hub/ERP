using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class CompanyWiseModule:Entity
    {
        public int Id { get; set; }
        public Nullable<int> CompId { get; set; }
        public Nullable<int> ModuleId { get; set; }
        public string ModuleName { get; set; }
        public Nullable<int> Orderby { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
