using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Department:Entity
    {
        public int DepartId { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
