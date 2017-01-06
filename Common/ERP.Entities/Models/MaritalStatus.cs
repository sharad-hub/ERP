using System;
using System.Collections.Generic;

namespace ERP.Data.Models
{
    public partial class MaritalStatus
    {
        public int Id { get; set; }
        public Nullable<int> CompId { get; set; }
        public string MaritalStatus1 { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
