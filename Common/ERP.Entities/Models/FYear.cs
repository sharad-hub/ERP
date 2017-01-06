using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class FYear
    {
        public int Id { get; set; }
        public int CompId { get; set; }
        public string FinYear { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}
