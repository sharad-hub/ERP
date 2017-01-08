using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class Zone : Entity
    {
        public int ZoneID { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }

    }
}
