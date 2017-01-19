using ERP.Entities;
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
using System.Configuration;
namespace ERP.Areas.Sales.Controllers
{
    public class ManagementController : BaseController
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
        public ManagementController(IMembershipService membershipService, IUserService userService,
            IMenuService menuService, IModuleService moduleService, IUnitOfWorkAsync unitOfWorkAsync,
            IStoredProcedureService storedProcedureService, IModuleGroupAccessService moduleGroupAccessService,
            IModuleGroupService moduleGroupService, IUserSettingsService userSettingsService,
            IAccessTypeService accessTypeService, IUserModulesService userModulesService)
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
        }
        // GET: Buyers/Management
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
            @ViewBag.Modules = GetAllowedModules(useremail);
            var accessTypes = _accessTypeService.Queryable().OrderBy(x => x.Name).Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name, Selected = false }).ToList();
            // @ViewBag.AccessTypes = accessTypes.ToList();
            return View(new CreateUser
            {
                AssignedModules = GetAllowedModules(useremail),
                AccessTypes = accessTypes
            });
        }
        [HttpPost]
        public ActionResult CreateUser(CreateUser model)
        {

            if (model != null && model.AssignedModules != null && model.AssignedModules.Count > 0)
            {
                var useremail = User.Identity.GetUserNameIdentifier();
                string passwordKEy = Keys.Password.ToString();
                int compId = 0;
                string companyId = ConfigurationManager.AppSettings["COMP_ID"];
                Int32.TryParse(companyId, out compId);
                if (model.UseDefaultPassword)
                {
                    var usersSetting = _userSettingsService.GetUserSettingsByEmail(useremail).Where(x => x.Key == passwordKEy).FirstOrDefault();
                    if (usersSetting != null)
                        model.Password = usersSetting.Value;
                }
                var user = _membershipService.CreateUserByManager(new User { Username = model.NameIdentifier, CompId = compId, IsLocked = false, DateCreated = DateTime.Now, Email = model.Email }, model.Password, useremail);
                var modulesToAdd = model.AssignedModules.Where(x => x.Selected).Select(x => new UserModules
                {
                    AccessTypeID = x.AccessTypeID,
                    ModuleID = x.ModuleID,
                    UserID = user.UserID
                }).ToList();
                _userModulesService.InsertRange(modulesToAdd);
                _unitOfWorkAsync.SaveChangesAsync();
                Success(string.Format("<b>User({0})</b> was successfully added.", model.Email), true);
            }
            return View("Users");
        }

        #endregion
        private List<AssignedModuleVm> GetAllowedModules(string UserEmail)
        {
            IEnumerable<int> moduleGroupIds = _moduleGroupAccessService.GetAccessableModuleGroups(UserEmail).Select(x => x.ModuleGroupID);
            return _moduleGroupService.Queryable().Where(x => moduleGroupIds.Contains(x.ModuleGroupID))
                   .SelectMany(y => y.Modules).Select(x => new AssignedModuleVm
                   {
                       Selected = false,
                       ModuleName = x.ModuleName,
                       ModuleID = x.Id,
                       AccessTypeID = 0,
                       AccessTypeName = ""
                   }).ToList();
        }
    }
}