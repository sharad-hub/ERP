using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Country:Entity
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
}
