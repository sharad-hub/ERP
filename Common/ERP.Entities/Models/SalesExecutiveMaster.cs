using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class SalesExecutive : Entity
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [DisplayName("Sales Executive Name")]
        public string SalesExecName { get; set; }
        [ForeignKey("Designation")]
        public Nullable<int> DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        public Nullable<int> ParentId { get; set; }
        [DisplayName("Mobile Number")]
        public string MobileNo { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [DisplayName("Email Address")]
        public string EmailId { get; set; }
        [DisplayName("Country")]
        public Nullable<int> CountryId { get; set; }
        [DisplayName("Zone")]
        public Nullable<int> ZoneId { get; set; }
        [DisplayName("State")]
        public Nullable<int> StateId { get; set; }
        [DisplayName("City")]
        public Nullable<int> CityId { get; set; }
        public Nullable<bool> Status { get; set; }
        [ForeignKey("SalesExecUser")]
        public int SalesExecUserID { get; set; }
        public User SalesExecUser { get; set; }
    }
}
