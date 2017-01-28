using ERP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class AddProductSkusVM
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public List<ProductSKU> ProductSKUs { get; set; }
    }
}