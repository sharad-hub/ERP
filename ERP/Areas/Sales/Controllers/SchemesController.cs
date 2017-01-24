using ERP.Entities.Models;
using ERP.Extensions;
using ERP.Services;
using Newtonsoft.Json;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 

namespace ERP.Areas.Sales.Controllers
{
    public class SchemesController : BaseController
    {
        ILoggerService _logservice;
        IUnitOfWorkAsync _unitOfWorkAsync;
        ISchemeService _schemeService;
        ISchemeTypeService _schemeTypeService;
        IProductService _productService;
        public SchemesController(ISchemeService schemeService,ISchemeTypeService schemeTypeService,IProductService productService,
            ILoggerService logservice,IUnitOfWorkAsync unitOfWorkAsync)
        {
            _schemeService = schemeService;
            _schemeTypeService = schemeTypeService;
            _productService = productService;
            _logservice = logservice;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
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

        public ActionResult TradeProduct()
        {
            var products = _productService.Queryable().Where(x => x.Status);
            ViewBag.products = products.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.ProductName + "(" +x.ProductCode +" ) ",
                    Value = x.ProductID.ToString()
                }).ToList();
            var schemeTypes = _schemeTypeService.Queryable().Where(x => x.Status);
            ViewBag.schemeTypes = schemeTypes.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Text = x.SchemeTypeName,
                    Value = x.ID.ToString()
                }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult TradeProduct(Scheme model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _schemeService.Insert(model);
                    _logservice.LogInfo(LogHelper.GetLogString(User.Identity.GetUserNameIdentifier(), "AddGodown", JsonConvert.SerializeObject(model)));
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Trade Scheme</b> was successfully added."), true);
                    return RedirectToAction("TradeSchemes");
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
        public ActionResult TradeSchemes()
        {
            var schemes = _schemeService.Queryable().Where(x => x.Status);
            return View(schemes);
        }
    }
}