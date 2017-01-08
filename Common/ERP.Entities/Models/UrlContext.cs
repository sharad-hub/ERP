using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
    public class UrlContext : Entity
    {
        public UrlContext()
        {
            Modules = new HashSet<Module>();
        }
        public int UrlContextID { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Module>  Modules { get; set; }
        public string SortName { get; set; }
    }
}
