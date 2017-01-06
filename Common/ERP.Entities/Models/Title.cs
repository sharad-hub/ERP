using System;
using System.Collections.Generic;

namespace ERP.Data.Models
{
    public partial class Title
    {
        public int Id { get; set; }
        public Nullable<int> CompId { get; set; }
        public string Title1 { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
