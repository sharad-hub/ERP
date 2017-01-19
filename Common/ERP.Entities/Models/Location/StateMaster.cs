using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class State : Entity
    {
        public int ID { get; set; }
        [ForeignKey("Zone")]
        public Nullable<int> ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
        public string StateName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
