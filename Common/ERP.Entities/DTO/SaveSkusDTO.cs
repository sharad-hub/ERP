using ERP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.DTO
{
    public class SaveSkusDTO
    {
        public int ProductID { get; set; }
        public List<ProductSKU> ProductSKUs { get; set; }
    }
}
