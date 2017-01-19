using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class Buyer : Entity
    {
        public long BuyerId { get; set; }
         [DisplayName("Sales Executive")]
        [ForeignKey("SalesExec")]
        public Nullable<int> SalesExecId { get; set; }
        public virtual User SalesExec { get; set; }
        [DisplayName("Buyer Code")]
        public string BuyerCode { get; set; }
        [DisplayName("Buyer Name")]
        public string BuyerName { get; set; }
        [DisplayName("Billing Address")]
        public string BuyerAddress { get; set; }
        [DisplayName("Billing City")]
        public Nullable<int> BuyerBillingCityId { get; set; }
        [DisplayName("Delivery Address")]
        public string BuyerDeliveryAddress { get; set; }
        [DisplayName("Delivery City")]
        public Nullable<int> BuyerDeliveryCityId { get; set; }
        [DisplayName("Billing Pincode")]
        public string BuyerBillingPinCode { get; set; }
        [DisplayName("Delivery Pincode")]
        public string BuyerDeliveryPinCode { get; set; }
        [DisplayName("Mobile Number")]
        public string BuyerMobileNo { get; set; }
        public string BuyerPhoneNo { get; set; }
        [DisplayName("Fax Number")]
        public string BuyerFaxNo { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [DisplayName("Email Address")]
        public string EmailId { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [DisplayName("Buyer Email Address")]
        public string BuyerEmailId { get; set; }
        [DisplayName("WebSite")]
        public string BuyerWebSite { get; set; }
        [DisplayName("TIN Number")]
        public string BuyerTINNo { get; set; }
        [DisplayName("PAN Number")]
        public string BuyerPANNo { get; set; }
        [DisplayName("CST Number")]
        public string BuyerCSTNo { get; set; }
        [DisplayName("LST Number")]
        public string BuyerLSTNo { get; set; }
        [DisplayName("GST Number")]
        public string BuyerGSTNo { get; set; }
        [DisplayName("Service Tax Number")]
        public string BuyerServiceTaxNo { get; set; }
        [DisplayName("ECC Code")]
        public string ECCCode { get; set; }
        public string Range { get; set; }
        public string Division { get; set; }
        [DisplayName("Commission Rate")]
        public string Commissionarate { get; set; }
        [DisplayName("Contact Person")]
        public string ContactPersonName { get; set; }
        [DisplayName("Contact Person Mobile")]
        public string ContactPersonMobileNo { get; set; }
        [DisplayName("Contact Person Email")]
        public string ContactPersonEmailId { get; set; }

        [ForeignKey("SuperUser")]
        public int SuperUserId { get; set; }
        public virtual User SuperUser { get; set; }
        //public string SuperUserLoginId { get; set; }
        //public string SuperUserLoginPassword { get; set; }
        public Nullable<int> SalesTaxFormId { get; set; }
        public Nullable<bool> RoadPermitNoReq { get; set; }

        [DisplayName("Tax Type")]
        public Nullable<int> TaxType { get; set; }
        [DisplayName("Tax Percentage(%)")]
        public Nullable<double> TaxPerc { get; set; }
        public Nullable<bool> Status { get; set; }
        //public Nullable<int> CreatedBy { get; set; }
        [ForeignKey("CreatedByUser")]
        public Nullable<int> CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        //[ForeignKey("UserType")]
        //public int UserTypeID { get; set; }
        //public virtual UserType UserType { get; set; }
    }
}
