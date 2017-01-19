using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class BuyerOrder : Entity
    {
        public int ID { get; set; }
        [ForeignKey("Buyer")]
        public long BuyerID { get; set; }
        public virtual Buyer Buyer { get; set; }
        [ForeignKey("FinYear")]
        public int FinYearId { get; set; }
        public virtual FinYear FinYear { get; set; }
        public int BuyerOrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int BuyerOrderStatusId { get; set; }
        public int BuyerOrderTrackerStatusId { get; set; }
        public string Remarks { get; set; }
        public DateTime CreationDate { get; set; }
       // [ForeignKey("CreatedBy")]
        public int CreatedById { get; set; }
       // public virtual User CreatedBy { get; set; }
        public DateTime LastmodifiedDate { get; set; }
        
        public int LastModifiedById { get; set; }
        //public virtual User LastModifiedBy { get; set; }

    }
}
