using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class ProductFactoryAllocation : Entity
    {
        public long ID { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Factory")]
        public int FactoryId { get; set; }
        public virtual Factory Factory { get; set; }
        public int CapacityInDays { get; set; }
    }
}
