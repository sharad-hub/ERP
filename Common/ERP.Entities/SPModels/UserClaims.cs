using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.SPModels
{
    public class UserClaims
    {
        public int UserID { get; set; }
        public string UserType { get; set; }
        public string ThemeSkin { get; set; }
        public string AreaName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public int UrlContextID { get; set; }

    }
}
