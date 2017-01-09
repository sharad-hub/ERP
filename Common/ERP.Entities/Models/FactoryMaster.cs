using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Factory : Entity
    {
        public long FactoryId { get; set; }
        public string FactoryCode { get; set; }
        public string FactoryName { get; set; }
        public string FactoryAddress { get; set; }
        public Nullable<int> FactoryCityId { get; set; }
        public string FactoryPinCode { get; set; }
        public string FactoryMobileNo { get; set; }
        public string FactoryPhoneNo { get; set; }
        public string FactoryFaxNo { get; set; }
        public string FactoryEmailId { get; set; }
        public string FactoryWebSite { get; set; }
        public string FactoryTINNo { get; set; }
        public string FactoryPANNo { get; set; }
        public string FactoryCSTNo { get; set; }
        public string FactoryLSTNo { get; set; }
        public string FactoryGSTNo { get; set; }
        public string FactoryServiceTaxNo { get; set; }
        public string ECCCode { get; set; }
        public string Range { get; set; }
        public string Division { get; set; }
        public string Commissionarate { get; set; }
        public string SuperUserLoginId { get; set; }
        public string SuperUserLoginPassword { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> CreatedDate { get; set; }
    }
}
