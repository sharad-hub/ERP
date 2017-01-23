using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class UnitOfMeasurement : Entity
    {
        public int ID { get; set; }
        [Required]
        //[MaxLength(50)]
        public string UOM { get; set; }
        public string UOMCode { get; set; }
        public bool Status { get; set; }
    }
}
