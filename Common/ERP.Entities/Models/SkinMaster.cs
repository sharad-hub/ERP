using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
  public class SkinMaster:Entity
    {
        public int ID { get; set; }
        public string SkinClass { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
