using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class City : Entity
    {
        public int Id { get; set; }
        public Nullable<int> StateId { get; set; }
        public string CityName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
