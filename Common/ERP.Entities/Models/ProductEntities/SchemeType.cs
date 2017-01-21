using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
  public  class SchemeType :Entity
    {
        public int ID { get; set; }
        public string SchemeTypeName { get; set; }
        public bool Status { get; set; }
    }
}
