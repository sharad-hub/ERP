using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class BuyerOrderItem : Entity
    {
        public long ID { get; set; }

        #region ForeignKeys
       // [ForeignKey("BuyerOrder")]
        public long BuyerOrderId { get; set; }
        //public virtual BuyerOrder BuyerOrder { get; set; }
       // [ForeignKey("FinYear")]
        public int FinYearId { get; set; }
        //public virtual FinYear FinYear { get; set; }
        //[ForeignKey("BuyerOrderNo")]
       // public string BuyerOrderNo { get; set; }//50

        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
        //[DisplayName("Product Name")]
        //public string ProductName { get; set; }
        //[ForeignKey("ProductSku")]
        public long ProductSkuID { get; set; } 
       // public virtual ProductSKU ProductSku { get; set; }
        public float UnitPrice { get; set; }
        public float MRP { get; set; }
        public float Quintity { get; set; }
        public int SchemeId { get; set; }
        public float SchemeFreeQty { get; set; }
        public float TotalOrderQty { get; set; }
        public float TotalOrderAmt { get; set; }
        public float TotalSchemeFreeAmt { get; set; }
        public float DiscPercentage { get; set; }
        public float DiscAmount { get; set; }        
        [DisplayName("Tax Percentage")]
        public float TaxPercentage { get; set; }
        [DisplayName("Tax Amount")]
        public float TaxAmount { get; set; }
        [DisplayName("Total Order Cost")]
        public float TotalOrderCost { get; set; }
        public int FactoryID { get; set; }

    }


    public class OrderScheduling : Entity
    {
        public int ID { get; set; }
        [ForeignKey("BuyerOrderItem")]
        public int OrderItemID { get; set; }
        public virtual BuyerOrderItem BuyerOrderItem { get; set; }
        public DateTime ScheduleDate { get; set; }
        public float ScheduleQuantity { get; set; }
    }

}
