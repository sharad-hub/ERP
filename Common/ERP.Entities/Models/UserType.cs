using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities
{
   public class UserType:Entity
    {
       public int ID { get; set; }
        public string TypeCode { get; set; }
        public string UserTypeName { get; set; }
    }
}
