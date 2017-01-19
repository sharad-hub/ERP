using System;
using System.Collections.Generic;

namespace ERP.DTO.Models
{
    public partial class ZoneMaster
    {
        public int ZoneId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string ZoneName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
