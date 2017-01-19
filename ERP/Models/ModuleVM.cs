using ERP.Entities;
using ERP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Models
{
    public class ModuleVM : Module
    {

        public IEnumerable<SelectListItem> ModuleGroups { get; set; }
    }
}