
using ERP.Entities;
using ERP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace ERP.Entities.DTO
{
	public class  ProductDTO
    {
		public  Int64 ProductID { get; set; }
		 
		public  Decimal? Price { get; set; }
		public  DateTime? CreatedOn { get; set; }
		public  String ProductCode { get; set; }
		public  Int32 ProductSubGroupId { get; set; }
		public  Int32? ProductTypeId { get; set; }
		public  Int32? UOMMainId { get; set; }
		public  Int32? ColorId { get; set; }
		public  Int32? TariffCodeId { get; set; }
		public  Int32 GodownId { get; set; }
		public  String ProductDescription { get; set; }
		public  Int32 Packing { get; set; }
		public  Single MRP { get; set; }
		public  Single AbatmentPercentage { get; set; }
		public  Single UnitPrice { get; set; }
		public  Single BasicPrice { get; set; }
		public  String BrandName { get; set; }
		public  String Size { get; set; }
		public  Single ProductGrossWeight { get; set; }
		public  Single ProductNetWeight { get; set; }
		public  Single MinimumStockLevel { get; set; }
		public  Single MaximumStockLevel { get; set; }
		public  Boolean TaxableFlag { get; set; }
		public  Single TaxPercentage { get; set; }
		public  Boolean ExciseableFlag { get; set; }
		public  Single ExcisePerc { get; set; }
		public  Boolean PartNoFlag { get; set; }
		public  Boolean BatchNoFlag { get; set; }
		public  Boolean ExpiryDateFlag { get; set; }
		public  Boolean FactoryFlag { get; set; }
		public  Single ReOrderLevel { get; set; }
		public  Int32 OpeningQty { get; set; }
		public  Int32 OpeningValue { get; set; }
		public  Boolean Status { get; set; }
		public  Boolean IsMultipleSKUs { get; set; }
		public  Boolean IsMultipleColors { get; set; }
		public  Int32? ProductCategoryID { get; set; }
		public int BuyerOrderItems_Count { get; set; }
		public string Color_Name { get; set; }
		public string Godown_GodownName { get; set; }
		public string ProductCategory_ProductCategoryName { get; set; }
		public int ProductColors_Count { get; set; }
		public int ProductFactoryAllocations_Count { get; set; }
		public int ProductImages_Count { get; set; }
		public int ProductOpeningBalances_Count { get; set; }
		public int ProductSKUs_Count { get; set; }
		public string ProductSubGroup_ProductSubGroupName { get; set; }
		public string ProductType_TypeName { get; set; }
		public int Schemes_Count { get; set; }
		public string Tariff_TariffCode { get; set; }
		public string UnitOfMeasurement_UOM { get; set; }

        public List<ProductSKU> ProductSkus { get; set; }
        public static System.Linq.Expressions.Expression<Func<  Product, ProductDTO>> SELECT =
            x => new   ProductDTO
            {
                ProductID = x.ProductID,
                ProductDescription = x.ProductDescription,
                Price = x.Price,
                CreatedOn = x.CreatedOn,
                ProductCode = x.ProductCode,
                ProductSubGroupId = x.ProductSubGroupId,
                ProductTypeId = x.ProductTypeId,
                UOMMainId = x.UOMMainId,
                ColorId = x.ColorId,
                TariffCodeId = x.TariffCodeId,
                GodownId = x.GodownId,               
                Packing = x.Packing,
                MRP = x.MRP,
                AbatmentPercentage = x.AbatmentPercentage,
                UnitPrice = x.UnitPrice,
                BasicPrice = x.BasicPrice,
                BrandName = x.BrandName,
                Size = x.Size,
                ProductGrossWeight = x.ProductGrossWeight,
                ProductNetWeight = x.ProductNetWeight,
                MinimumStockLevel = x.MinimumStockLevel,
                MaximumStockLevel = x.MaximumStockLevel,
                TaxableFlag = x.TaxableFlag,
                TaxPercentage = x.TaxPercentage,
                ExciseableFlag = x.ExciseableFlag,
                ExcisePerc = x.ExcisePerc,
                PartNoFlag = x.PartNoFlag,
                BatchNoFlag = x.BatchNoFlag,
                ExpiryDateFlag = x.ExpiryDateFlag,
                FactoryFlag = x.FactoryFlag,
                ReOrderLevel = x.ReOrderLevel,
                OpeningQty = x.OpeningQty,
                OpeningValue = x.OpeningValue,
                Status = x.Status,
                IsMultipleSKUs = x.IsMultipleSKUs,
                IsMultipleColors = x.IsMultipleColors,
                ProductCategoryID = x.ProductCategoryID,
                //BuyerOrderItems_Count = x.BuyerOrderItems.Count(),
                ProductSkus = x.ProductSkus.ToList(),
                Color_Name = x.Color.Name,
                Godown_GodownName = x.Godown.GodownName,
                ProductCategory_ProductCategoryName = x.ProductCategory.ProductCategoryName,
                ProductColors_Count = x.ProductColors.Count(),
                ProductFactoryAllocations_Count = x.ProductFactoryAllocations.Count(),
                ProductImages_Count = x.ProductImages.Count(),
                ProductOpeningBalances_Count = x.ProductOpeningBalances.Count(),
                ProductSKUs_Count = x.ProductSkus.Count(),
                ProductSubGroup_ProductSubGroupName = x.ProductSubGroup.ProductSubGroupName,
                ProductType_TypeName = x.ProductType.TypeName,
                Schemes_Count = x.Schemes.Count(),
                Tariff_TariffCode = x.TariffCode.TariffCode,
                UnitOfMeasurement_UOM = x.UOMMain.UOM,
            };

	}
}