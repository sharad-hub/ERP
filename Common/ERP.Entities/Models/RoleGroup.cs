using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
  public class RoleGroup :Entity
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
