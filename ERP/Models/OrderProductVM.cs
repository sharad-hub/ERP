using ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class OrderProductVM
    {
        public int TotalQuantity { get; set; }
        public int TotalUnitValue { get; set; }
        public int FreeQuantity { get; set; }
        public int SchemeQuantityValue { get; set; }
        public float DiscountPercent { get; set; }
        public float DiscountAmount { get; set; }
        public float TaxAmount { get; set; }
        public float TotalAmount { get; set; }
        public int SelectedProductId { get; set; }
        public int? SelectedProductSkuId { get; set; }
        public Product Product { get; set; }
    }
}