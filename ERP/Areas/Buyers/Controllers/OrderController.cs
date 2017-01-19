using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Buyers.Controllers
{
    public class OrderController : Controller
    {
        // GET: Buyers/Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderPosting()
        {
            return View();
        }
        public ActionResult OrderScheduling()
        {
            return View();
        }
        public ActionResult OrderTracker()
        {
            return View();
        }
        public ActionResult OrderDetails()
        {
            return View();
        }
    }
}