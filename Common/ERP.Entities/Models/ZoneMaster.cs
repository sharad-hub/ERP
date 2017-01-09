using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Zone : Entity
    {
        public int ZoneId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string ZoneName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
