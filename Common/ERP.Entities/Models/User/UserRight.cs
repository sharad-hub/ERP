using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class UserRight : Entity
    {
        public long AutoId { get; set; }
        public int User { get; set; }
        public int MenuId { get; set; }
        public int AccessTypeID { get; set; }
        public AccessType AccessType { get; set; }
    } 

}
