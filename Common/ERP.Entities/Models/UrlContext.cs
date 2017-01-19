using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Area Name")]
        public string AreaName { get; set; }

        [Display(Name = "Controller Name")]
        public string ControllerName { get; set; }

        [Display(Name = "Action Name")]
        public string ActionName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
        [Display(Name = "Short Name")]
        public string SortName { get; set; }
    }
}
