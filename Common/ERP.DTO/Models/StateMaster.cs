using System;
using System.Collections.Generic;

namespace ERP.DTO.Models
{
    public partial class StateMaster
    {
        public int StateId { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public string StateName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
