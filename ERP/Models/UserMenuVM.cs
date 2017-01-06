using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class UserMenuVM
    {
        public int UserID { get; set; }
        public String UserEmail { get; set; }
        public string UserName { get; set; }

        public List<MenuVM> Menu { get; set; }
    }
}