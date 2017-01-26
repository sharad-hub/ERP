using ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class OrderPostingVM
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public float TotalOrderAmount { get; set; }
        public int TotalSalesQuantity { get; set; }
        public int TotalFreeQuantity { get; set; }
        public float TotalUnitValue { get; set; }
        public float TotalSchemeQuantityValue { get; set; }
        public float TotalDiscountAmount { get; set; }
        public float TotalTaxAmount { get; set; }
        public string Remarks { get; set; }
        public List<OrderProductVM> Products { get; set; }
    }
}