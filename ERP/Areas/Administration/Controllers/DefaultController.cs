using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Administration.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Administration/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}