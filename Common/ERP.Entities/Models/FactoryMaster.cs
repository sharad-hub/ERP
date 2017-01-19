using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    //[MetadataType(TypeOfFactoryMetaData)]
    public partial class Factory : Entity
    {
        [ScaffoldColumn(false)]
        public int FactoryId { get; set; }
        [DisplayName("Factory Code")]
        public string FactoryCode { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required]
        [DisplayName("Factory Name")]
        public string FactoryName { get; set; }
        [DisplayName("Factory Address")]
        public string FactoryAddress { get; set; }
        [Required]
        [DisplayName("Factory City")]
        public Nullable<int> FactoryCityId { get; set; }
        [DisplayName("Factory Pincode")]
        public string FactoryPinCode { get; set; }
        [DisplayName("Factory Mobile Number")]
        public string FactoryMobileNo { get; set; }
        [DisplayName("Factory Phone Number")]
        public string FactoryPhoneNo { get; set; }
        [DisplayName("Factory Fax Number")]
        public string FactoryFaxNo { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [DisplayName("Factory Email Address")]
        public string FactoryEmailId { get; set; }
        [DisplayName("Factory Website")]
        public string FactoryWebSite { get; set; }
        [DisplayName("Factory Tin No.")]
        public string FactoryTINNo { get; set; }
        [DisplayName("Factory Pan No.")]
        public string FactoryPANNo { get; set; }
        [DisplayName("Factory CST No.")]
        public string FactoryCSTNo { get; set; }
        [DisplayName("Factory LST No.")]
        public string FactoryLSTNo { get; set; }
        [DisplayName("Factory LST No.")]
        public string FactoryGSTNo { get; set; }
        [DisplayName("Factory LST No.")]
        public string FactoryServiceTaxNo { get; set; }
        [DisplayName("ECC Code")]
        public string ECCCode { get; set; }
        [DisplayName("Range")]
        public string Range { get; set; }
        [DisplayName("Division")]
        public string Division { get; set; }


        [Range(0.01, 100.00, ErrorMessage = "Commission rate must be between 0.01 and 100.00")]
        [DisplayName("Commission rate")]
        public string Commissionarate { get; set; }
        //public string SuperUserLoginId { get; set; }
        //public string SuperUserLoginPassword { get; set; }
        [ScaffoldColumn(false)]
        [ForeignKey("SuperUser")]
        public int SuperUserId { get; set; }
        public virtual User SuperUser { get; set; }

        public Nullable<bool> Status { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<int> CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<DateTime> CreatedDate { get; set; }
    }
}
