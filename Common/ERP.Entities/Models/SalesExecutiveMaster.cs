using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class SalesExecutive : Entity
    {
        public int SalesExecId { get; set; }
        public string SalesExecName { get; set; }
        public Nullable<int> SalesExecDesignationId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
