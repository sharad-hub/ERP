using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class Buyer:Entity
    {
        public long BuyerId { get; set; }
        public Nullable<int> SalesExecId { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string BuyerAddress { get; set; }
        public Nullable<int> BuyerBillingCityId { get; set; }
        public string BuyerDeliveryAddress { get; set; }
        public Nullable<int> BuyerDeliveryCityId { get; set; }
        public string BuyerBillingPinCode { get; set; }
        public string BuyerDeliveryPinCode { get; set; }
        public string BuyerMobileNo { get; set; }
        public string BuyerPhoneNo { get; set; }
        public string BuyerFaxNo { get; set; }
        public string BuyerEmailId { get; set; }
        public string BuyerWebSite { get; set; }
        public string BuyerTINNo { get; set; }
        public string BuyerPANNo { get; set; }
        public string BuyerCSTNo { get; set; }
        public string BuyerLSTNo { get; set; }
        public string BuyerGSTNo { get; set; }
        public string BuyerServiceTaxNo { get; set; }
        public string ECCCode { get; set; }
        public string Range { get; set; }
        public string Division { get; set; }
        public string Commissionarate { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonMobileNo { get; set; }
        public string ContactPersonEmailId { get; set; }

        [ForeignKey("SuperUser")]
        public int SuperUserId { get; set; }
        public virtual User SuperUser { get; set; }
        //public string SuperUserLoginId { get; set; }
        //public string SuperUserLoginPassword { get; set; }
        public Nullable<int> SalesTaxFormId { get; set; }
        public Nullable<bool> RoadPermitNoReq { get; set; }
        public Nullable<int> TaxType { get; set; }
        public Nullable<double> TaxPerc { get; set; }
        public Nullable<bool> Status { get; set; }
        //public Nullable<int> CreatedBy { get; set; }
        [ForeignKey("CreatedByUser")]
        public Nullable<int> CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
    }
}
