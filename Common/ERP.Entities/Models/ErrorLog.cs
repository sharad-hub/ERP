using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class ErrorLog
    {
        public int ID { get; set; }
        public int ErrorID { get; set; }
        public DateTime Errored { get; set; }
        public string UserName { get; set; }
        public string Details { get; set; }
    }
}
