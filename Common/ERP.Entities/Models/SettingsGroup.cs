using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
  public class SettingsGroup:Entity
    {
      public SettingsGroup()
      {
          SystemSettings = new HashSet<SystemSetting>();
      }
        public int ID { get; set; }
        public string Name { get; set; }
        public string SortDscription { get; set; }
        public virtual ICollection<SystemSetting> SystemSettings { get; set; }
    }
}
