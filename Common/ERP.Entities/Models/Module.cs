using ERP.Entities.Models;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Entities
{
    public partial class Module : Entity
    {
        public Module()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string ModuleKeyCode { get; set; }
        public string ModuleName { get; set; }
        public Nullable<int> Orderby { get; set; }
        public bool Active { get; set; }
       
        public int Level { get; set; }

        [ForeignKey("ParentModule")]
        public Nullable<int> ParentModuleID { get; set; }
        public virtual Module ParentModule { get; set; }

        [ForeignKey("ModuleGroup")]
        public Nullable<int> ModuleGroupID { get; set; }
        public virtual ModuleGroup ModuleGroup { get; set; }

        [ForeignKey("UrlContext")]
        public Nullable<int> UrlContextID { get; set; }
        public virtual UrlContext UrlContext { get; set; }

        [ForeignKey("UIStyle")]
        public Nullable<int> UIStyleID { get; set; }
        public virtual UIStyle UIStyle { get; set; }

        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }


}
