using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ERP.Entities.Models
{
   public class ProductGroup:Entity
    {
       public ProductGroup()
       {
           ProductSubGroups = new HashSet<ProductSubGroup>();
       }
       public int ID { get; set; }
        [DisplayName("Product Group Name")]
       public string ProductGroupName { get; set; }
       public bool Status { get; set; }
       public virtual ICollection<ProductSubGroup> ProductSubGroups { get; set; }
    }
}
