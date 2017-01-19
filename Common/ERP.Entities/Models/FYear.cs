using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Entities
{
    public class FYear : Entity
    {
        [Key]
        public int Id { get; set; }
        public int CompId { get; set; }
        public string FinYear { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }

    public class FinYear : Entity
    {
        [Key]
        public int ID { get; set; }      
        public string FinYearName { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}
