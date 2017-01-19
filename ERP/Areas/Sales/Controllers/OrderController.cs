using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Sales.Controllers
{
    public class OrderController : Controller
    {
        // GET: Sales/Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderShortlisting()
        {
            return View();
        }
        public ActionResult OrderAcceptance()
        {
            return View();
        }
        public ActionResult OrderPayment()
        {
            return View();
        }
        public ActionResult OrderForwording()
        {
            return View();
        }
    }
}