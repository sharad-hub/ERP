using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities
{
   //public class Role:Entity
   // {
   //     public int ID { get; set; }
   //     public string RoleName { get; set; }
   //     public string Description { get; set; }
   //     public bool Status { get; set; }
   // }

   public class Role : Entity
   {
       public int ID { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
   }
}
