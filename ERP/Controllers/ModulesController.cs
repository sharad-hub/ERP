using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class ModulesController : Controller
    {
        // GET: Modules
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageUser()
        {
            return View();
        }

        public ActionResult ManageModules()
        {
            return View();
        }

        public ActionResult ManageFactory()
        {
            return View();
        }

        public ActionResult ManageProducts()
        {
            return View();
        }


        public ActionResult ManageInvoice()
        {
            return View();
        }
        //public ActionResult ManageInvoice()
        //{
        //    return View();
        //}
        public ActionResult ManageCustomers()
        {
            return View();
        }
        public ActionResult ManageMeetings()
        {
            return View();
        }
        public ActionResult ManageTasks()
        {
            return View();
        }
         
    }
}