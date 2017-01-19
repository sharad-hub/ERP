using System;
using System.Collections.Generic;

namespace ERP.DTO.Models
{
    public partial class DesignationMaster
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
