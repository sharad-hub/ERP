
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
        IGodownService _godownService;
        IColorService _colorService;
        ITariffService _tariffService;
        ILoggerService _logservice;
        public ProductController(IProductGroupService productGroupService, IProductService productService,
             IProductSubGroupService productSubGroupService, IProductColorService productColorService,
             IProductTypeService productTypeService, IProductSKUService productSKUService, IUnitOfWorkAsync unitOfWorkAsync
            , IUnitOfMaterialService unitOfMaterialService, ILoggerService logservice
            , IGodownService godownService, IColorService colorService, ITariffService tariffService)
        {
            _unitOfMaterialService = unitOfMaterialService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _productGroupService = productGroupService;
            _productService = productService;
            _productSubGroupService = productSubGroupService;
            _productTypeService = productTypeService;
            _productSKUService = productSKUService;
            _logservice = logservice;

            _colorService = colorService;
            _tariffService = tariffService;
            _godownService = godownService;
        }
        // GET: Administration/Product
       

        #region Product 

        public ActionResult Index()
        {
            var products = _productService.Queryable().Where(x => x.Status).ToList();
            return View(products);
        }
        public ActionResult AddProduct()
        {
            #region Filling DropDowns
            var productSubGroups = _productSubGroupService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productSubGroups = productSubGroups.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.ProductSubGroupName,
                    Value = x.ID.ToString()
                }).ToList();
            var productTypes = _productTypeService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productTypes = productTypes.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.TypeName,
                    Value = x.ID.ToString()
                }).ToList();

            var productTariffs = _tariffService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productTariffs = productTariffs.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.TariffName + "-(" + x.TariffCode + ")",
                    Value = x.ID.ToString()
                }).ToList();
            var godowns = _godownService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.godowns = godowns.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.GodownName,
                    Value = x.ID.ToString()
                }).ToList();
            var colors = _colorService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.colors = colors.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }).ToList();
            var uoms = _unitOfMaterialService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.uoms = uoms.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.UOM,
                    Value = x.ID.ToString()
                }).ToList();
            #endregion
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    product.CreatedOn = DateTime.Now;
                    _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProduct", JsonConvert.SerializeObject(product)));
                    _productService.Insert(product);
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Product {0} </b> was successfully added.", product.ProductName), true);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                Danger(string.Format("<b>Errored occured while saving the product details"), true);
                ModelState.AddModelError("Error", "Errored occured while saving the product details");
                _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProduct", JsonConvert.SerializeObject(product)));
            }
            #region Filling DropDowns
            var productSubGroups = _productSubGroupService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productSubGroups = productSubGroups.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.ProductSubGroupName,
                    Value = x.ID.ToString()
                }).ToList();
            var productTypes = _productTypeService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productTypes = productTypes.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.TypeName,
                    Value = x.ID.ToString()
                }).ToList();

            var productTariffs = _tariffService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productTariffs = productTariffs.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.TariffName + "-(" + x.TariffCode + ")",
                    Value = x.ID.ToString()
                }).ToList();
            var godowns = _godownService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.godowns = godowns.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.GodownName,
                    Value = x.ID.ToString()
                }).ToList();
            var colors = _colorService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.colors = colors.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }).ToList();
            var uoms = _unitOfMaterialService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.uoms = uoms.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.UOM,
                    Value = x.ID.ToString()
                }).ToList();
            #endregion
            return View(product);
        }
        #endregion

        #region MyRegion
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
        #endregion

        #region Product supgroup
        public ActionResult AddProductSubGroup()
        {
            var productGroups = _productGroupService.Queryable().Where(x => x.Status == true).ToList();
            ViewBag.productGroups = productGroups.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.ProductGroupName,
                    Value = x.ID.ToString()
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
                    Success(string.Format("<b>Product Sub group({0})</b> was successfully added.", productsubGroup.ProductSubGroupName), true);
                    return RedirectToAction("ProductSubGroups");
                }
            }
            catch (DataException ex)
            {
                Danger(string.Format("<b>Errored occured while saving the product group"), true);
                ModelState.AddModelError("Error", "Errored occured while saving the product group");
                _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProduct", JsonConvert.SerializeObject(productsubGroup)));
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
        #endregion
       

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
                    _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProductColor", JsonConvert.SerializeObject(productColor)));
                    _productColorService.Insert(productColor);
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Product color </b> was successfully added."), true);
                    return RedirectToAction("ProductTypes");
                }
            }
            catch (DataException ex)
            {
                Danger(string.Format("<b>Errored occured while saving the product color"), true);
                ModelState.AddModelError("Error", "Errored occured while saving the product color group");
                _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProduct", JsonConvert.SerializeObject(productColor)));
            }

            return View(productColor);
        }
        public ActionResult ProductColors()
        {
            var productColors = _productColorService.Queryable().Where(x => x.Status == true);
            return View(productColors);
        }

        #region Product type
        public ActionResult AddProductType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProductType(ProductType productType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProductType", JsonConvert.SerializeObject(productType)));
                    _productTypeService.Insert(productType);
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Product type({0})</b> was successfully added.", productType.TypeName), true);
                    return RedirectToAction("ProductTypes");
                }
            }
            catch (DataException ex)
            {
                Danger(string.Format("<b>Errored occured while saving the product type"), true);
                ModelState.AddModelError("Error", "Errored occured while saving the product type");
                _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddProductType", JsonConvert.SerializeObject(productType)));
            }

            return View(productType);
        }
        public ActionResult ProductTypes()
        {
            var productType = _productTypeService.Queryable().Where(x => x.Status == true);
            return View(productType);
        }
        #endregion

        #region UOM
        public ActionResult AddUnitOfMaterial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUnitOfMaterial(UnitOfMeasurement uomat)
        {
            if (ModelState.IsValid)
            {
                _unitOfMaterialService.Insert(uomat);
                _unitOfWorkAsync.SaveChanges();
                Success(string.Format("<b>UOM ({0})</b> was successfully added.", uomat.UOM), true);
                return RedirectToAction("UnitOfMaterials");
            }
            return View(uomat);
        }
        public ActionResult UnitOfMaterials()
        {
            var uoms = _unitOfMaterialService.Queryable().Where(x => x.Status).ToList();
            return View(uoms);
        }
        #endregion

        #region Godown
        public ActionResult AddGodown()
        {
            return View(new Godown());
        }
        [HttpPost]
        public ActionResult AddGodown(Godown godown)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _godownService.Insert(godown);
                    _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddGodown", JsonConvert.SerializeObject(godown)));
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Godown  ({0})</b> was successfully added.", godown.GodownName), true);
                    return RedirectToAction("Godowns");
                }
            }
            catch (DataException ex)
            {
                Danger(string.Format("<b>Errored occured while saving the  godown details"), true);
                ModelState.AddModelError("Error", "Errored occured while saving the godown details");
                _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddGodown", JsonConvert.SerializeObject(godown)));
            }

            return View(godown);
        }
        public ActionResult Godowns()
        {
            var godowns = _godownService.Queryable().Where(x => x.Status == true).ToList();
            return View(godowns);
        }
        #endregion


        #region Tariff
        public ActionResult AddTariff()
        {
            return View(new Tariff());
        }
        [HttpPost]
        public ActionResult AddTariff(Tariff model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tariffService.Insert(model);
                    _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddGodown", JsonConvert.SerializeObject(model)));
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Tariff  ({0})</b> was successfully added.", model.TariffName), true);
                    return RedirectToAction("Tariffs");
                }
            }
            catch (DataException ex)
            {
                Danger(string.Format("<b>Errored occured while saving the  godown details"), true);
                ModelState.AddModelError("Error", "Errored occured while saving the godown details");
                _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddGodown", JsonConvert.SerializeObject(model)));
            }

            return View(model);
        }
        public ActionResult Tariffs()
        {
            var tariffs = _tariffService.Queryable().Where(x => x.Status == true).ToList();
            return View(tariffs);
        }
        #endregion

      

        #region Schemes

         
        #endregion
    }
}