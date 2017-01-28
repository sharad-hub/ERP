using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class ProductColor : Entity
    {
        public long ID { get; set; }
        [ForeignKey("Product")]
        public Nullable<long> ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
        public bool Status { get; set; }
    }

    public class ProductOpeningBalance : Entity
    {
        public long ID { get; set; }

        public bool BatchNoFlag { get; set; }
        public bool PartNoFlag { get; set; }
        public bool ExpiryDateFlag { get; set; }
        public float OpeningQty { get; set; }
        public float OpeningValue { get; set; }
        #region ForeignKeys

        [ForeignKey("Godown")]
        public int GodownId { get; set; }
        public virtual Godown Godown { get; set; }
        [ForeignKey("Product")]
        public Nullable<long> ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("ProductSKU")]
        public long ProductSKUsId { get; set; }
        public virtual ProductSKU ProductSKU { get; set; }
        [ForeignKey("Factory")]
        public int FactoryId { get; set; }
        public virtual Factory Factory { get; set; }
        //[ForeignKey("ProductColor")]
        //public int ProductColorId { get; set; }
        //public virtual ProductColor ProductColor { get; set; } /// PRODUCT COLUR /COLOR
        #endregion


    }
   
   

    //Factory Master			
    //    Id	int
    //    Factory Name	50
    //    FactoryCode	10
    //    FactoryAddressId	int
    //    Status	bit


}
