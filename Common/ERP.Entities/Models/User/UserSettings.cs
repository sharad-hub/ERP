using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
   public class SystemSetting:Entity
    {
       /// <summary>
       /// To add system level sessting for User or a specifc Role
       /// Can be extened further for other level settings if needed
       /// </summary>
        public int ID { get; set; }

        [ForeignKey("User")]
        public Nullable<int> UserID { get; set; }
        public virtual User User { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }

        [ForeignKey("Role")]
        public Nullable<int> RoleID { get; set; }
        public virtual Role Role { get; set; }


        [ForeignKey("SettingsGroup")]
        public Nullable<int> SettingsGroupID { get; set; }
        public virtual SettingsGroup SettingsGroup { get; set; }
    }
}
