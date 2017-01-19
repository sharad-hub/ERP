using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class Color : Entity
    {
        public int ID { get; set; }
        [DisplayName("Color Name")]
        public string Name { get; set; }
        [Required]
        public string ColorCode { get; set; }
        [DisplayName("Hexadecimal Code")]
        public string HexadecimalCode { get; set; }
        public bool Status { get; set; }
    }
}
