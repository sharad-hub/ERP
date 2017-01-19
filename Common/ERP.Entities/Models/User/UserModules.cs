using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public partial class UserModules : Entity
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Module")]
        public int ModuleID { get; set; }
        public virtual Module Module { get; set; }
        [ForeignKey("AccessType")]
        public int AccessTypeID { get; set; }
        public virtual AccessType AccessType { get; set; }
    }
}
