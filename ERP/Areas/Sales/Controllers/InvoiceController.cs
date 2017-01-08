using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Sales.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Sales/Invoice
        public ActionResult Index()
        {
            return View();
        }
    }
}