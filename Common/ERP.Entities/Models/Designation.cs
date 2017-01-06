using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Designation:Entity
    {
        public int Id { get; set; }
        public Nullable<int> compId { get; set; }
        public string Designation1 { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
