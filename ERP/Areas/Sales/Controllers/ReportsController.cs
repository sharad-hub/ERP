using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Sales.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Sales/Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MIS()
        {
            return View();
        }
    }
}