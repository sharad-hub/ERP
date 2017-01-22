
using ERP.Entities;
using ERP.Entities.Models;
using ERP.Extensions;
using ERP.Services;
using Newtonsoft.Json;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Administration.Controllers
{
    public class ProductController : BaseController
    {
        IUnitOfMaterialService _unitOfMaterialService;
        IProductGroupService _productGroupService;
        IProductService _productService;
        IProductSubGroupService _productSubGroupService;
        IProductColorService _productColorService;
        IProductTypeService _productTypeService;
        IProductSKUService _productSKUService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        ILoggerService _logservice;
        public ProductController(IProductGroupService productGroupService, IProductService productService,
             IProductSubGroupService productSubGroupService, IProductColorService productColorService,
             IProductTypeService productTypeService, IProductSKUService productSKUService, IUnitOfWorkAsync unitOfWorkAsync
            , IUnitOfMaterialService unitOfMaterialService, ILoggerService logservice)
        {
            _unitOfMaterialService = unitOfMaterialService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _productGroupService = productGroupService;
            _productService = productService;
            _productSubGroupService = productSubGroupService;
            _productTypeService = productTypeService;
            _productSKUService = productSKUService;
            _logservice = logservice;
        }
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
            return View(new Product());
        }

        public ActionResult AddProductGroup()
        {
            return View(new ProductGroup());
        }
        [HttpPost]
        public ActionResult AddProductGroup(ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                productGroup.ObjectState = ObjectState.Added;
                _productGroupService.Insert(productGroup);
                _logservice.LogInfo(JsonConvert.SerializeObject(productGroup));
                _unitOfWorkAsync.SaveChanges();
                Success(string.Format("<b>Product Group({0})</b> was successfully added.", productGroup.ProductGroupName), true);
                return RedirectToAction("ProductGroups");
            }
            return View(productGroup);
        }
        public ActionResult ProductGroups()
        {
            var productGroups = _productGroupService.Queryable().Where(x => x.Status == true).ToList();
            return View(productGroups);
        }
        public ActionResult AddProductSubGroup()
        {
          var  productGroups = _productGroupService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productGroups = productGroups.AsEnumerable()
                .Select(x=>new SelectListItem {
                     Text=x.ProductGroupName, Value=x.ID.ToString()
                }).ToList();
            return View(new ProductSubGroup());
        }
        [HttpPost]
        public ActionResult AddProductSubGroup(ProductSubGroup productsubGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productsubGroup.ObjectState = ObjectState.Added;
                    _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProductSubGroup", JsonConvert.SerializeObject(productsubGroup)));
                    _productSubGroupService.Insert(productsubGroup);
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Product type({0})</b> was successfully added.", productsubGroup.ProductSubGroupName), true);
                    return RedirectToAction("ProductSubGroups");
                }
            }
            catch (Exception ex)
            {
                _logservice.LogError(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProductSubGroup", ex.Message));
            }

            var productGroups = _productGroupService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productGroups = productGroups.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.ProductGroupName,
                    Value = x.ID.ToString()
                }).ToList();
            return View(productsubGroup);
        }

        public ActionResult ProductSubGroups()
        {
            var productSubGroup = _productSubGroupService.Queryable().Where(x => x.Status == true);
            return View(productSubGroup);
        }
        public ActionResult AddProductSKU()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductSKU(ProductSKU productSku)
        {
            if (ModelState.IsValid)
            {
                productSku.ObjectState = ObjectState.Added;
                _productSKUService.Insert(productSku);
                _unitOfWorkAsync.SaveChanges();
                Success(string.Format("<b>Product Sku({0})</b> was successfully added.", productSku.SKUSize), true);
                return RedirectToAction("ProductSKUs");
            }
            return View(productSku);
        }

        public ActionResult ProductSKUs()
        {
            var productSkus = _productSKUService.Queryable().Where(x => x.Status == true).ToList();
            return View(productSkus);
        }
        public ActionResult AddProductColor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductColor(ProductColor productColor)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _productColorService.Insert(productColor);
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Product color </b> was successfully added."), true);
                    return RedirectToAction("ProductTypes");
                }
            }
            catch (DataException ex)
            {

                throw;
            }
           
            return View(productColor);
        }
        public ActionResult ProductColors()
        {
            var productColors = _productColorService.Queryable().Where(x => x.Status == true);
            return View(productColors);
        }
        public ActionResult AddProductType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductType(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _productTypeService.Insert(productType);
                _unitOfWorkAsync.SaveChanges();
                Success(string.Format("<b>Product type({0})</b> was successfully added.", productType.TypeName), true);
                return RedirectToAction("ProductTypes");
            }
            return View(productType);
        }
        public ActionResult ProductTypes()
        {
            var productType = _productTypeService.Queryable().Where(x => x.Status == true);
            return View(productType);
        }
        public ActionResult AddUnitOfMaterial()
        {
            return View();
        }
        public ActionResult AddUnitOfMaterial(UnitOfMaterial uom)
        {
            if (ModelState.IsValid)
            {
                _unitOfMaterialService.Insert(uom);
                _unitOfWorkAsync.SaveChanges();
                Success(string.Format("<b>UOM ({0})</b> was successfully added.", uom.UOM), true);
                return RedirectToAction("UnitOfMaterials");
            }
            return View(uom);
        }
        public ActionResult UnitOfMaterials()
        {
            var uoms = _unitOfMaterialService.Queryable().Where(x => x.Status).ToList();
            return View(uoms);
        }
    }
}