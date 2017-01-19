using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Sales.Controllers
{
    public class SchemesController : Controller
    {
        // GET: Sales/Schemes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FestivalScheme()
        {
            return View();
        }
        public ActionResult BuyersDiscount()
        {
            return View();
        }
        public ActionResult GlobalDiscount()
        {
            return View();
        }
    }
}