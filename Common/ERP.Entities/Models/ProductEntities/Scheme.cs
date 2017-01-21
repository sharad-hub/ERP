using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
  public  class Scheme:Entity
    {
        public int ID { get; set; }
        [ForeignKey("Product")]
        public Nullable<int> ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        [ForeignKey("SchemeType")]
        public Nullable<int> SchemeTypeId { get; set; }
        public virtual SchemeType SchemeType { get; set; }
        public int SOQtyLimit { get; set; }
        public int EveryPeriodforQty { get; set; }
        public int FreeQty { get; set; }
        public bool Status { get; set; }   
    }
}
