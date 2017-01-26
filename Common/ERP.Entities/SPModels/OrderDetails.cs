using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.SPModels
{
    public class OrderDetails
    {
        public string OrderNumber { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
    }
}
