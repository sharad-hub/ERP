using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class State:Entity
    {
        public int ID { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public string StateName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
