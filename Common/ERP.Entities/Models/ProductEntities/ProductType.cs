using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace ERP.Entities.Models
{
    public class ProductType:Entity
    {
        public int ID { get; set; }
        [DisplayName("Product Type Name")]
        public string TypeName { get; set; }
        [DisplayName("Prefix Code")]
        public string PrefixCode { get; set; }
        public bool Status { get; set; }
    }
    //Finish Goods/ Raw Material/ Packing Mat/ Consumable/ Semi Finished	
    public class ProductSubGroup:Entity
    {
        public int ID { get; set; }
        [DisplayName("Product Group")]
        [ForeignKey("ProductGroup")]
        public Nullable<int> ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup{ get; set; }
        [DisplayName("Product Sub Group Name")]
        public string ProductSubGroupName { get; set; }
        public bool Status { get; set; }
    }

}
