using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    //public partial class UserRole:Entity
    //{
    //    public int RoleId { get; set; }
    //    public int UserId { get; set; }         
    //    public Nullable<bool> Status { get; set; }
    //}

    public class UserRole : Entity
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
