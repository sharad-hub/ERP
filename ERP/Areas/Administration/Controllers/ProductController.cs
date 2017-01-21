
using ERP.Entities;
using ERP.Entities.Models;
using ERP.Extensions;
using ERP.Services;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
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
        public ProductController(IProductGroupService productGroupService, IProductService productService,
             IProductSubGroupService productSubGroupService, IProductColorService productColorService,
             IProductTypeService productTypeService, IProductSKUService productSKUService, IUnitOfWorkAsync unitOfWorkAsync
            , IUnitOfMaterialService unitOfMaterialService)
        {
            _unitOfMaterialService = unitOfMaterialService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _productGroupService = productGroupService;
            _productService = productService;
            _productSubGroupService = productSubGroupService;
            _productTypeService = productTypeService;
            _productSKUService = productSKUService;
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
            return View();
        }

        public ActionResult AddProductGroup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductGroup(ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                _productGroupService.Insert(productGroup);
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
            return View();
        }
        [HttpPost]
        public ActionResult AddProductSubGroup(ProductSubGroup productsubGroup)
        {
            if (ModelState.IsValid)
            {
                _productSubGroupService.Insert(productsubGroup);
                _unitOfWorkAsync.SaveChanges();
                Success(string.Format("<b>Product type({0})</b> was successfully added.", productsubGroup.ProductSubGroupName), true);
                return RedirectToAction("ProductTypes");
            }
            return View(productsubGroup);
        }

        public ActionResult ProductSubGroups()
        {
            var productGroup = _productGroupService.Queryable().Where(x => x.Status == true);
            return View(productGroup);
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
            if (ModelState.IsValid)
            {
                _productColorService.Insert(productColor);
                _unitOfWorkAsync.SaveChanges();
                Success(string.Format("<b>Product color </b> was successfully added."), true);
                return RedirectToAction("ProductTypes");
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