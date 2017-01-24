using ERP.Entities.Models;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class Product : Entity
    {   [Key]
        public int ProductID { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        [Required]
        public string ProductCode { get; set; }
        #region ForeignKeys
        [ForeignKey("ProductSubGroup")]
        public int ProductSubGroupId { get; set; }
        public virtual ProductSubGroup ProductSubGroup { get; set; }
        [ForeignKey("ProductType")]
        public Nullable<int> ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        [ForeignKey("UOMMain")]
        public Nullable<int> UOMMainId { get; set; }
        public virtual UnitOfMeasurement UOMMain { get; set; }
        //[ForeignKey("UOMSecond")]
        //public int UOMSecondId { get; set; }
        //public virtual UnitOfMeasurement UOMSecond { get; set; }  ///Move to different table 

        [ForeignKey("Color")]
        public Nullable<int> ColorId { get; set; }
        public virtual Color Color { get; set; }
        [ForeignKey("TariffCode")]
        public Nullable<int> TariffCodeId { get; set; }
        public virtual Tariff TariffCode { get; set; }
        [ForeignKey("Godown")]
        public int GodownId { get; set; }
        public virtual Godown Godown { get; set; }
        #endregion

        public string ProductDescription { get; set; }
        public int Packing { get; set; }
        public float MRP { get; set; }
        public float AbatmentPercentage { get; set; }
        public float UnitPrice { get; set; }
        public float BasicPrice { get; set; }
        public string BrandName { get; set; }
        public string Size { get; set; }
        public float ProductGrossWeight { get; set; }
        public float ProductNetWeight { get; set; }
        public float MinimumStockLevel { get; set; }
        public float MaximumStockLevel { get; set; }
        public bool TaxableFlag { get; set; }
        public float TaxPercentage { get; set; }
        public bool ExciseableFlag { get; set; }
        public float ExcisePerc { get; set; }
        public bool PartNoFlag { get; set; }
        public bool BatchNoFlag { get; set; }
        public bool ExpiryDateFlag { get; set; }
        public bool FactoryFlag { get; set; }
        public float ReOrderLevel { get; set; }
        public int OpeningQty { get; set; }
        public int OpeningValue { get; set; }
        public bool Status { get; set; }
        public bool IsMultipleSKUs { get; set; }
        public bool IsMultipleColors { get; set; }
    }
}