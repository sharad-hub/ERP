using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    /// <summary>
    /// To Provide User/ Role to create new users with a Role 
    ///  User or Group can create users with CanProvideRole
    /// </summary>
    public class RolesProvider : Entity
    {
        public int ID { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        public Nullable<int> UserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("UserRole")]
        public Nullable<int> UserRoleID { get; set; }
        public virtual Role UserRole { get; set; }

        [ForeignKey("CanProvideRole")]
        public Nullable<int> CanProvideRoleID { get; set; }
        public virtual Role CanProvideRole { get; set; }
    }
}
