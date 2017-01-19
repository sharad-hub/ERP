using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Sales.Controllers
{
    public class SalesOrderController : Controller
    {
        // GET: Sales/SalesOrder
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SOTracker()
        {
            return View();
        }
    }
}