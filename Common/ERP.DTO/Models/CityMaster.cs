using System;
using System.Collections.Generic;

namespace ERP.DTO.Models
{
    public partial class CityMaster
    {
        public int ID { get; set; }
        public Nullable<int> StateId { get; set; }
        public string CityName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
