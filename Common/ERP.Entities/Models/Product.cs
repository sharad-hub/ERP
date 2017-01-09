using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Product:Entity
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }
}