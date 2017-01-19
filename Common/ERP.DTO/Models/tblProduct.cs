using System;
using System.Collections.Generic;

namespace ERP.DTO.Models
{
    public partial class tblProduct
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
