using ERP.APIWrappers;
using ERP.Entities;
using ERP.Entities.SParams;
using ERP.Entities.SPModels;
using ERP.Services;
using ERP.Servicess;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Extensions;
using ERP.Models;
using ERP.Entities.Models;
namespace ERP.Areas.Administration.Controllers
{
    public class DefaultController : Controller
    {

        IMembershipService _membershipService;
        IUserService _userService;
        IMenuService _menuService;
        IModuleService _moduleService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        IStoredProcedureService _storedProcedureService;
        IModuleGroupAccessService _moduleGroupAccessService;
        IModuleGroupService _moduleGroupService;
        IUserSettingsService _userSettingsService;
        IAccessTypeService _accessTypeService;
        IUserModulesService _userModulesService;
        IUrlContextService _urlContextService;
        public DefaultController(IMembershipService membershipService, IUserService userService,
            IMenuService menuService, IModuleService moduleService, IUnitOfWorkAsync unitOfWorkAsync,
            IStoredProcedureService storedProcedureService, IModuleGroupAccessService moduleGroupAccessService,
            IModuleGroupService moduleGroupService, IUserSettingsService userSettingsService,
            IAccessTypeService accessTypeService, IUserModulesService userModulesService, IUrlContextService urlContextService)
        {
            _membershipService = membershipService;
            _userService = userService;
            _menuService = menuService;
            _moduleService = moduleService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _storedProcedureService = storedProcedureService;
            _moduleGroupAccessService = moduleGroupAccessService;
            _moduleGroupService = moduleGroupService;
            _userSettingsService = userSettingsService;
            _accessTypeService = accessTypeService;
            _userModulesService = userModulesService;
            _urlContextService = urlContextService;
        }

        // GET: Administration/Default
        public ActionResult Index()
        {
            return View();
        }
        #region Modules
        public PartialViewResult Module()
        {

            return PartialView("_Module", GetAllUsersModules(User.Identity.GetUserNameIdentifier()));
        }
        private List<ModuleForGui> GetAllUsersModules(string userEmail)
        {
            var data = _storedProcedureService.GetModulesByUserName(userEmail);
            if (data != null)
                return  MainHelper.FormatModule(data).ToList();
            else
                return null;
        }
        public ActionResult Modules()
        {
            var Modules = _moduleService.SelectQuery("SELECT *  FROM  [dbo].[Modules]");//.Queryable().Where(x=>x.Active==true).ToList();
            return View(Modules.ToList());
        }
        public ActionResult EditModule(int ID)
        {
            var moduleGroups = _moduleGroupService.SelectQuery("SELECT *  FROM  [dbo].[ModuleGroups]");
            var mouleToEdit = _moduleService.SelectQuery("SELECT *  FROM  [dbo].[Modules] where id='" + ID + "'").FirstOrDefault();
            IEnumerable<SelectListItem> ModuleGroups = moduleGroups.OrderBy(o => o.Orderby).Select(x => new SelectListItem { Text = x.Name, Value = x.ModuleGroupID.ToString() });
            ViewBag.ModuleGroups = ModuleGroups;
            return View(mouleToEdit);
        }
        [HttpPost]
        public ActionResult EditModule(Module model)
        {
            _moduleService.Update(model);
            _unitOfWorkAsync.SaveChangesAsync();
            return View("Modules");
        }
        public ActionResult CreateModule()
        {
            var moduleGroups = _moduleGroupService.SelectQuery("SELECT *  FROM  [dbo].[ModuleGroups]");
            IEnumerable<SelectListItem> ModuleGroups = moduleGroups.OrderBy(o => o.Orderby).Select(x => new SelectListItem { Text = x.Name, Value = x.ModuleGroupID.ToString() });
            ViewBag.ModuleGroups = ModuleGroups;
            return View(new Module());
        }

        [HttpPost]
        public ActionResult CreateModule(Module model)
        {
            _moduleService.Insert(model);
            _unitOfWorkAsync.SaveChangesAsync();
            return View("Modules");
        }
       
        #endregion 

        #region Pages URL

        public ActionResult AllUrls()
        {
            var URLS = _urlContextService.SelectQuery("SELECT *  FROM  [dbo].[UrlContexts]");
            return View(URLS.ToList());
        }
       
        public ActionResult AddURL()
        {
            var Urls = new URLExtension().GetURLData().Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });
            ViewBag.Areas = Urls;
            return View(new UrlContext());
        }
         [HttpPost]
         public ActionResult AddURL(UrlContext model)
         {
             _urlContextService.Insert(model);
              _unitOfWorkAsync.SaveChangesAsync();
              var Urls = new URLExtension().GetURLData().Select(x => new SelectListItem
              {
                  Value = x.Name,
                  Text = x.Name
              });
              ViewBag.Areas = Urls;
              return View(new UrlContext());
         }

        [HttpPost]
        public ActionResult GetControllers(string areaName)
        {           
            List<SelectListItem> controllers = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(areaName))
            {
                var area = new URLExtension().GetURLData().Where(x => x.Name.ToLower() == areaName.ToLower()).FirstOrDefault();
              controllers = area.ERPControllers.Select(x => new SelectListItem
              {
                  Value = x.Name,
                  Text = x.Name
              }).ToList();              
            }
            return Json(controllers, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetActions(string controllerName, string areaName)
        {
            List<SelectListItem> actionmethods = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(controllerName))
            {
                var area = new URLExtension().GetURLData().Where(x => x.Name.ToLower() == areaName.ToLower()).FirstOrDefault();
                var controller = area.ERPControllers.Where(x => x.Name.ToLower() == controllerName.ToLower()).FirstOrDefault();

                actionmethods = controller.ERPActions.Select(x => new SelectListItem
                {
                    Value = x.Name,
                    Text = x.Name
                }).ToList();
            }
            return Json(actionmethods, JsonRequestBehavior.AllowGet);
        }  

        [HttpPost]
        public ActionResult EditURL(UrlContext model)
        {
            _urlContextService.Update(model);
            _unitOfWorkAsync.SaveChangesAsync();
            return View("AllUrls");
        }
        public ActionResult EditURL()
        {
            var moduleGroups = _moduleGroupService.SelectQuery("SELECT *  FROM  [dbo].[ModuleGroups]");
            IEnumerable<SelectListItem> ModuleGroups = moduleGroups.OrderBy(o => o.Orderby).Select(x => new SelectListItem { Text = x.Name, Value = x.ModuleGroupID.ToString() });
            ViewBag.ModuleGroups = ModuleGroups;
            return View(new Module());
        }
        #endregion
    }
}