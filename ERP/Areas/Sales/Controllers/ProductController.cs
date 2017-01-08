using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Sales.Controllers
{
    public class ProductController : Controller
    {
        // GET: Sales/Product
        public ActionResult Index()
        {
            return View();
        }
    }
}