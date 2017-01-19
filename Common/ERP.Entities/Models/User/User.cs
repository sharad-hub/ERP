using ERP.Data.Models;
using ERP.Entities.Models;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{

    public class User : Entity
    {
        public User()
        {
            Modules = new HashSet<Module>();
            Users = new HashSet<User>();
        }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public Nullable<DateTime> DateCreated { get; set; } 
        public int CompId { get; set; }

        [ForeignKey("Manager")]
        public Nullable<int> ManagerID { get; set; }
        public virtual User Manager { get; set; }

        [InverseProperty("Manager")]
        public virtual ICollection<User> Users { get; set; }

        public Nullable<int> CreatedByUserID { get; set; }
       
        public virtual ICollection<Module> Modules { get; set; }

        [ForeignKey("Zone")]
        public Nullable<int> ZoneID { get; set; }
        public virtual Zone Zone { get; set; }

         [ForeignKey("UserType")]
        public Nullable<int> UserTypeID { get; set; }
        public virtual UserType UserType { get; set; }

        /// <summary>
        ///  To Refer Buyer / Factory .. usertype + Userref id
        /// </summary>
        public int UserReferenceID { get; set; }
    }
    //public partial class User:Entity
    //{
    //    public int ID { get; set; }
    //    public int CompId { get; set; }
    //    public string UserLoginId { get; set; }
    //    public string UserLoginPassword { get; set; }
    //    public string UserName { get; set; }       
    //    public bool Status { get; set; }
    //    public bool IsLocked { get; set; }
    //    public DateTime DateCreated { get; set; }
    //    public string HashedPassword { get; set; }
    //    public string Salt { get; set; }
    //    public string Email { get; set; }      
       
    //}
}
