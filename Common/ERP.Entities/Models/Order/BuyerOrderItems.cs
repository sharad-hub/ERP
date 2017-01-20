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
        public int ID { get; set; }

        #region ForeignKeys
        [ForeignKey("BuyerOrder")]
        public int BuyerOrderId { get; set; }
        public virtual BuyerOrder BuyerOrder { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public int UnitId { get; set; }
        public int UnitPrice { get; set; }
        public int MRP { get; set; }
        public int Quintity { get; set; }
        public int SchemeId { get; set; }
        public int SchemeFreeQty { get; set; }
        public int TotalOrderQty { get; set; }
        public int TotalOrderAmt { get; set; }
        public int TotalSchemeFreeAmt { get; set; }
        public int DiscPercentage { get; set; }
        public int DiscAmount { get; set; }
        [DisplayName("Sales Tax Amount")]
        public int SalesTaxAmount { get; set; }
        [DisplayName("Tax Percentage")]
        public int TaxPercentage { get; set; }
        [DisplayName("Total Order Cost")]
        public int TotalOrderCost { get; set; }

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
