using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class UserRight:Entity
    {
        public long AutoId { get; set; }
        public int User { get; set; }
        public int MenuId { get; set; }
        public Nullable<int> AccessTypeID { get; set; }
    }
}
