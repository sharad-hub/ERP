using System;
using System.Collections.Generic;

namespace ERP.DTO.Models
{
    public partial class CountryMaster
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
