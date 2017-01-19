using System;
using System.Collections.Generic;

namespace ERP.DTO.Models
{
    public partial class DepartmentMaster
    {
        public int DepartId { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
