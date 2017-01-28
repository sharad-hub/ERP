using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models.ProductEntities
{
    public class ProductImage : Entity
    {
        public long ID { get; set; }
        public int OrderNumber { get; set; }

        #region ForeignKeys
        [ForeignKey("ImageType")]
        public int ImageTypeId { get; set; }
        public virtual ImageType ImageType { get; set; }
        [ForeignKey("Product")]
        public Nullable<long> ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("ProductSKU")]
        public long ProductSKUsId { get; set; }
        public virtual ProductSKU ProductSKU { get; set; }
        #endregion

        public string ProductImagePath { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImageDescription { get; set; }
    }

}
