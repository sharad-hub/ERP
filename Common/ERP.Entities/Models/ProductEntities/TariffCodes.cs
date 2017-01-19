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
    public class Tariff : Entity
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("Tariff Code")]
        public string TariffCode { get; set; }
        [MaxLength(50)]
        [DisplayName("Tariff Name")]
        public string TariffName { get; set; }
        public bool Status { get; set; }
    }
}
