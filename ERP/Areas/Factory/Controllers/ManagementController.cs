using ERP.Models;
using ERP.Services;
using ERP.Servicess;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Extensions;
using ERP.Entities;
using System.Configuration;
using ERP.Entities.Models;
namespace ERP.Areas.Factory.Controllers
{
    public class ManagementController : BaseController
    {

        IMembershipService _membershipService;
        IUserService _userService;
        IMenuService _menuService;
        IModuleService _moduleService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        IStoredProcedureService _storedProcedureService;
        IBuyerService _buyerService;
        IUserTypeService _userTypeService;
        ICityService _cityService;
        IZoneService _zoneService;
        ICountryService _countryService;
        IStateService _stateService;
        ISalesExecutiveService _salesExecutiveService;
        IModuleGroupAccessService _moduleGroupAccessService;
        IModuleGroupService _moduleGroupService;
        IUserSettingsService _userSettingsService;
        IFactoryService _factoryService;
        IDesignationService _designationService;
        IUserModulesService _userModulesService;
        IAccessTypeService _accessTypeService;
        public ManagementController(IMembershipService membershipService, IUserService userService,IAccessTypeService accessTypeService,
            IMenuService menuService, IModuleService moduleService, IModuleGroupAccessService moduleGroupAccessService,
            IModuleGroupService moduleGroupService, IUserSettingsService userSettingsService,
            IUnitOfWorkAsync unitOfWorkAsync, IStoredProcedureService storedProcedureService, IFactoryService factoryService,
            IBuyerService buyerService, IUserTypeService userTypeService, ICityService cityService,
             IZoneService zoneService, ICountryService countryService, IStateService stateService, IUserModulesService userModulesService,
            ISalesExecutiveService salesExecutiveService, IDesignationService designationService)
        {
            _membershipService = membershipService;
            _userService = userService;
            _menuService = menuService;
            _moduleService = moduleService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _storedProcedureService = storedProcedureService;
            _buyerService = buyerService;
            _userTypeService = userTypeService;
            _cityService = cityService;
            _stateService = stateService;
            _zoneService = zoneService;
            _countryService = countryService;
            _moduleGroupService = moduleGroupService;
            _moduleGroupAccessService = moduleGroupAccessService;
            _salesExecutiveService = salesExecutiveService;
            _designationService = designationService;
            _factoryService = factoryService;
            _userModulesService = userModulesService;
            _accessTypeService = accessTypeService;
            _userSettingsService = userSettingsService;
        }
        // GET: Factory/Management
        public ActionResult Index()
        {
            return View();
        }
        #region Manage users
        public ActionResult Users()
        {
            var useremail = User.Identity.GetUserNameIdentifier();
            return View(_membershipService.GetUsersByManageEmail(useremail));
        }
        public ActionResult CreateUser()
        {
            var useremail = User.Identity.GetUserNameIdentifier();
            var modulesAvilable = GetAllowedModules(useremail).ToList();
            ViewBag.Modules = modulesAvilable;
            var accessTypes = _accessTypeService.Queryable().OrderBy(x => x.Name).Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name, Selected = false }).ToList();
            // @ViewBag.AccessTypes = accessTypes.ToList();
            return View(new CreateUser
            {
                AssignedModules = modulesAvilable,
                AccessTypes = accessTypes
            });
        }
        [HttpPost]
        public ActionResult CreateUser(CreateUser model)
        {
            string useremail = string.Empty;
            if (ModelState.IsValid)
            {
                  useremail = User.Identity.GetUserNameIdentifier();
                if (model != null && model.AssignedModules != null && model.AssignedModules.Count > 0)
                {
                    var buyerSuperUser = _membershipService.GetUsersByEmail(useremail);
                    var buyer = _buyerService.Queryable().Where(x => x.SuperUserId == buyerSuperUser.UserID).FirstOrDefault();
                    var buyerInfo = _buyerService.Queryable().Where(x => x.SuperUserId == buyerSuperUser.UserID).FirstOrDefault();
                    string passwordKEy = Keys.Password.ToString();
                    int compId = 0;
                    string companyId = ConfigurationManager.AppSettings["COMP_ID"];
                    Int32.TryParse(companyId, out compId);
                    var usertype = _userTypeService.Queryable().Where(x => x.TypeCode == "FCT").FirstOrDefault();
                    if (model.UseDefaultPassword)
                    {
                        var usersSetting = _userSettingsService.GetUserSettingsByEmail(useremail).Where(x => x.Key == passwordKEy).FirstOrDefault();
                        if (usersSetting != null)
                            model.Password = usersSetting.Value;
                    }
                    int buyerId = (Int32)buyer.BuyerId;
                    var user = _membershipService.CreateUser(new User { Username = model.NameIdentifier, CompId = compId, IsLocked = false, DateCreated = DateTime.Now, Email = model.Email, UserReferenceID = buyerId }, model.Password, useremail, usertype);
                    var modulesToAdd = model.AssignedModules.Where(x => x.Selected).Select(x => new UserModules
                    {
                        AccessTypeID = x.AccessTypeID,
                        ModuleID = x.ModuleID,
                        UserID = user.UserID
                    }).ToList();

                    _userModulesService.InsertRange(modulesToAdd);
                    _unitOfWorkAsync.SaveChanges();
                }                
                Success(string.Format("<b>Factory({0})</b> was successfully added.", model.Email), true);               
            }
            var modulesAvilable = GetAllowedModules(useremail).ToList();
            ViewBag.Modules = modulesAvilable;
            var accessTypes = _accessTypeService.Queryable().OrderBy(x => x.Name).Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name, Selected = false }).ToList();
            return View(new CreateUser
            {
                AssignedModules = modulesAvilable,
                AccessTypes = accessTypes
            });
        }

        #endregion
        private List<AssignedModuleVm> GetAllowedModules(string UserEmail)
        {
            IEnumerable<int> moduleGroupIds = _moduleGroupAccessService.GetAccessableModuleGroups(UserEmail).Select(x => x.ModuleGroupID).ToList();

            var modules = _moduleService.SelectQuery("SELECT *  FROM  [dbo].[Modules]");

            return modules.Where(x => moduleGroupIds.Contains(x.ModuleGroupID))
               .Select(x => new AssignedModuleVm
               {
                   Selected = false,
                   ModuleName = x.ModuleName,
                   ModuleID = x.Id,
                   AccessTypeID = 0,
                   AccessTypeName = ""
               }).ToList();
        }
        public JsonResult IsUserExists(string Email)
        {
            bool isUserExist = _userService.Queryable().Any(x => x.Email.ToLower() == Email.ToLower()
                || x.Username.ToLower() == Email.ToLower());
            return Json(!isUserExist, JsonRequestBehavior.AllowGet);
        }
    }
}