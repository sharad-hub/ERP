using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class AccessType:Entity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }
        public Nullable<bool> status { get; set; }
    }
}
