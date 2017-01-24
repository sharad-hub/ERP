using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models.Order
{
   public class OrderStatus:Entity
    {
        public int ID { get; set; }
        public string TypeCode { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int Level { get; set; }
    }
}
