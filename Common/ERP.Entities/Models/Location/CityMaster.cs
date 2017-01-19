using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class City : Entity
    {
        public int Id { get; set; }
        [Display(Name = "State")]
        [ForeignKey("State")]
        public Nullable<int> StateId { get; set; }
        public virtual State State { get; set; }
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
