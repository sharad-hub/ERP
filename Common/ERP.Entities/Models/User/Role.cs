using ERP.Entities.Models;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities
{   
   public class Role : Entity
   {
       public int ID { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }

       public int UrlContextID { get; set; }
       public virtual UrlContext UrlContext { get; set; }

       [ForeignKey("RoleGroup")]
       public Nullable<int> RoleGroupID { get; set; }
       public virtual RoleGroup RoleGroup { get; set; }
   }
}
