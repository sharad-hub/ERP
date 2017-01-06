using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.SParams
{
   public class AddUserMenu
    {
        public int UserID { get; set; }
        public int MenueID { get; set; }
        public int AccessTypeID { get; set; }
    }
   public class GetUserMenu
   {
       public int UserID { get; set; }
       public string EmailAddress { get; set; }
   }
}
