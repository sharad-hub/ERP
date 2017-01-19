using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Designation : Entity
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
