
using ERP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
 

namespace ERP.Entities.DTO
{
	public class ProductSKUDTO
    {
		public Int32 ID { get; set; }
		public Int64? ProductId { get; set; }
		public String SKUSize { get; set; }
		public Single MRP { get; set; }
		public Single UnitPrice { get; set; }
		public Single BasicPrice { get; set; }
		public Single ProductGrossWeight { get; set; }
		public Single ProductNetWeight { get; set; }
		public Single ReOrderLevel { get; set; }
		public Single MinimumStockLevel { get; set; }
		public Single MaximumStockLevel { get; set; }
		public Boolean Status { get; set; }
        //public int ProductImages_Count { get; set; }
        //public int ProductOpeningBalances_Count { get; set; }
        //public string tblProduct_ProductTitle { get; set; }

        public static System.Linq.Expressions.Expression<Func<ProductSKU,  ProductSKUDTO>> SELECT =
            x => new  ProductSKUDTO
            {
                ID = x.ID,
                ProductId = x.ProductId,
                SKUSize = x.SKUSize,
                MRP = x.MRP,
                UnitPrice = x.UnitPrice,
                BasicPrice = x.BasicPrice,
                ProductGrossWeight = x.ProductGrossWeight,
                ProductNetWeight = x.ProductNetWeight,
                ReOrderLevel = x.ReOrderLevel,
                MinimumStockLevel = x.MinimumStockLevel,
                MaximumStockLevel = x.MaximumStockLevel,
                Status = x.Status,
                //ProductImages_Count = x.ProductImages.Count(),
                //ProductOpeningBalances_Count = x.ProductOpeningBalances.Count(),
                //tblProduct_ProductTitle = x.tblProduct.ProductTitle,
            };

	}
}