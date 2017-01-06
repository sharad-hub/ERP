using ERP.Data.Models;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{

    public class User : Entity
    {
        public User()
        {
            UserRoles = new List<UserRole>();
            Menus = new HashSet<Menu>();
        }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }       
        public virtual ICollection<UserRole> UserRoles { get; set; }
        //public virtual ICollection<Module> Modules { get; set; }
        public bool IsActive { get; set; }
        public int CompId { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
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
