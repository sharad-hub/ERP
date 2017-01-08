using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Sales.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Sales/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}