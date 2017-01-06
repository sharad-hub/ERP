using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class City:Entity
    {
        public int Id { get; set; }
        public string City1 { get; set; }
    }
}
