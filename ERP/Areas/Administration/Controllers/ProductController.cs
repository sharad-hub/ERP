using ERP.Entities;
using ERP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Administration.Controllers
{
    public class ProductController : Controller
    {
        // GET: Administration/Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            return View();
        }

        public ActionResult AddProductGroup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductGroup(ProductGroup productGroup)
        {
            return View();
        }
        public ActionResult AddProductSubGroup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductSubGroup(ProductSubGroup productsubGroup)
        {
            return View();
        }
        public ActionResult AddProductSKU()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductSKU(ProductSKU productSku)
        {
            return View();
        }
        public ActionResult AddProductColor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductColor(ProductColor productColor)
        {
            return View();
        }
        public ActionResult AddProductType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductType(ProductType productType)
        {
            return View();
        }
        public ActionResult AddUnitOfMaterial()
        {
            return View();
        }
        public ActionResult AddUnitOfMaterial(UnitOfMaterial uom)
        {
            return View();
        }

    }
}