using System;
using System.Collections.Generic;

namespace ERP.Data.Models
{
    public partial class Gender
    {
        public int Id { get; set; }
        public string Gender1 { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
