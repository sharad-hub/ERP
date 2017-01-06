using ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Models
{
    public class AddMenuVM
    {
        public int Id { get; set; }
        public Nullable<int> ModuleId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }        
        public Nullable<int> Orderby { get; set; }        
        public Nullable<bool> Status { get; set; }
        public Nullable<int> IconID { get; set; }
        public string backgroundColor { get; set; }
        public string FontColor { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public Module Module { get; set; }
        public List<SelectListItem> AvailableModule { get; set; }
    }
}