using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class ProductSKU : Entity
    {

        public int ID { get; set; }
        [ForeignKey("Product")]
        public Nullable<int> ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string SKUSize { get; set; }
        public float MRP { get; set; }
        public float UnitPrice { get; set; }
        public float BasicPrice { get; set; }
        public float ProductGrossWeight { get; set; }
        public float ProductNetWeight { get; set; }
        public float ReOrderLevel { get; set; }
        public float MinimumStockLevel { get; set; }
        public float MaximumStockLevel { get; set; }
        public bool Status { get; set; }
    }
}
