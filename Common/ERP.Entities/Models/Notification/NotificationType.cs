using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Entities.Models
{
    public class NotificationType : Entity
    {
        public int NotificationTypeID { get; set; }
        public string Description { get; set; }
        public string TypeCode { get; set; }
        public string DefaultText { get; set; }
    }
}
