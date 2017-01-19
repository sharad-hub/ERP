using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities.Models
{
   public class Notification:Entity
    {
        public int NotificationID { get; set; }
        public string Text { get; set; }
        public virtual NotificationType NotificationType { get; set; }
        public int NotificationTypeID { get; set; }
        public virtual User CreatedBy { get; set; }
        public DateTime TriggerTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public int ObjectID { get; set; }
        public virtual ERPObjectType ERPObjectType { get; set; }
        public virtual User ForUser { get; set; }
    }

   public class ERPObjectType : Entity
   {
       public int ERPObjectTypeID { get; set; }
       public string Code { get; set; }
       public string Name { get; set; }
   }
}
