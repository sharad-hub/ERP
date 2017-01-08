using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
  public class UIStyle:Entity
    {
        public int UIStyleID { get; set; }
        public string CSSClass { get; set; }
        public string FontIconClass { get; set; }
        public string FontColor { get; set; }
        public string BackgroundColor { get; set; }

        public string SortName { get; set; }
    }
}
