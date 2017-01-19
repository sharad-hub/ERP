using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class ModuleGroupAccess : Entity
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("ModuleGroup")]
        public int ModuleGroupID { get; set; }
        public virtual ModuleGroup ModuleGroup { get; set; }
        public bool Active { get; set; }
    }
}
