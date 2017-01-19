using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class Zone : Entity
    {
        public int ZoneId { get; set; }
        [ForeignKey("Country")]
        public Nullable<int> CountryId { get; set; }
        public Country Country { get; set; }
        public string ZoneName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
