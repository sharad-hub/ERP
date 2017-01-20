using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ERP.Entities.Models
{
    public class ImageType : Entity
    {
        public int ID { get; set; }
        [Required]
        public string TypeCode { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
