using ERP.Entities.Models.Order;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class BuyerOrder : Entity
    {
        public BuyerOrder()
        {
            BuyerOrderItems = new HashSet<BuyerOrderItem>();
        }
        public long ID { get; set; }
        //[ForeignKey("Buyer")]
        public long BuyerID { get; set; }
        public virtual Buyer Buyer { get; set; }
        [ForeignKey("FinYear")]
        public int FinYearId { get; set; }
        public virtual FinYear FinYear { get; set; }
        [MaxLength(50)]
        public string BuyerOrderNo { get; set; }//50
        public DateTime OrderDate { get; set; }
        [ForeignKey("OrderStatus")]
        public Nullable<int> OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        //public int BuyerOrderTrackerStatusId { get; set; }
        public string Remarks { get; set; }
        public  Nullable<DateTime> CreationDate { get; set; }
       // [ForeignKey("CreatedBy")]
        public int CreatedById { get; set; }
       // public virtual User CreatedBy { get; set; }
        public Nullable<DateTime> LastmodifiedDate { get; set; }
        
        public int LastModifiedById { get; set; }
        //public virtual User LastModifiedBy { get; set; }

        // buyerorder fin  buyerid- > primary key
        /// factory allocation id
        ///  
        public Nullable<DateTime> TentativeOrderDate { get; set; }

        public virtual ICollection<BuyerOrderItem> BuyerOrderItems { get; set; }

    }
}
