using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Menu:Entity
    {
        public int Id { get; set; }
        public Nullable<int> ModuleId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public string ImageIndexNo { get; set; }
        public string NavigationPath { get; set; }
        public Nullable<int> Orderby { get; set; }
        public string ItemImageURL { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> IconID { get; set; }
        public string backgroundColor { get; set; }
        public string FontColor { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
