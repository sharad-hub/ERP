using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ERP.Entities
{
    public partial class Module:Entity
    {
        public int Id { get; set; }
        public string ModuleKeyCode { get; set; }
        public string ModuleName { get; set; }
        public string ImageIndexNo { get; set; }
        public Nullable<int> Orderby { get; set; }
        public Nullable<bool> Status { get; set; }
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }           
    }
}
