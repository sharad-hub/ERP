﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Process.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Process/Orders
        public ActionResult Index()
        {
            return View();
        }
    }
}