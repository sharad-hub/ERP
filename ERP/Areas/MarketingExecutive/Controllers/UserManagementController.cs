using ERP.Attribute;
using ERP.Entities;
using ERP.Entities.Models;
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
namespace ERP.Areas.MarketingExecutive.Controllers
{
    [ClaimsAuthorize(CustomClaimTypes.UserType, "SLEX")]
    public class UserManagementController : BaseController
    {
        // GET: MarketingExecutive/UserManagement 

        IMembershipService _membershipService;
        IUserService _userService;
        IMenuService _menuService;
        IModuleService _moduleService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        IStoredProcedureService _storedProcedureService;
        IBuyerService _buyerService;
        IUserTypeService _userTypeService;
        ICityService _cityService;
        ISalesExecutiveService _salesExecutiveService;
        IModuleGroupAccessService _moduleGroupAccessService;
        IModuleGroupService _moduleGroupService;
        IUserModulesService _userModuleService;
        IUserSettingsService _userSettingsService;
        IDesignationService _designationService;
        IFactoryService _factoryService;
        public UserManagementController(IMembershipService membershipService, IUserService userService,
            IMenuService menuService, IModuleService moduleService, IModuleGroupAccessService moduleGroupAccessService,
            IModuleGroupService moduleGroupService, IUserSettingsService userSettingsService,
            IUnitOfWorkAsync unitOfWorkAsync, IStoredProcedureService storedProcedureService, IFactoryService factoryService,
            IBuyerService buyerService, IUserTypeService userTypeService, ICityService cityService,
            ISalesExecutiveService salesExecutiveService, IDesignationService designationService, IUserModulesService userModuleService)
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
            _moduleGroupService = moduleGroupService;
            _moduleGroupAccessService = moduleGroupAccessService;
            _salesExecutiveService = salesExecutiveService;
            _designationService = designationService;
            _factoryService = factoryService;
            _userModuleService = userModuleService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buyers()
        {
            int salexExecID = 0;
            Int32.TryParse(User.Identity.GetUserID(), out salexExecID);
            var buyers = _buyerService.Queryable().Where(x => x.SalesExecId == salexExecID);
            return View(buyers);
        }


        public ActionResult Factories()
        {
            int salexExecID = 0;
            Int32.TryParse(User.Identity.GetUserID(), out salexExecID);
            var factories = _factoryService.Queryable().Where(x => x.CreatedByUserId == salexExecID);
            return View(factories);
        }


        #region Buyer Creation
        public ActionResult CreateBuyer()
        {
            var Cities = _cityService.Queryable().OrderBy(x => x.CityName).Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.Cities = Cities;
            CreateBuyerVM model = new CreateBuyerVM();
            model.Buyer = new Buyer();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateBuyer(CreateBuyerVM model)
        {
            CreateBuyerVM buyerModel = null;
            if (ModelState.IsValid)
            {

                var useremail = User.Identity.GetUserNameIdentifier();
                var usertype = _userTypeService.Queryable().Where(x => x.TypeCode == "BUYR").FirstOrDefault();
                var user = new User
                {
                    UserTypeID = usertype.ID,
                    Username = model.Email,
                    Email = model.Email,
                    CompId = 1,
                };
                try
                {
                    user = _membershipService.CreateUser(user, model.Password, useremail, usertype);
                    model.Buyer.SuperUserId = user.UserID;
                    int salexExecID = 0;
                    Int32.TryParse(User.Identity.GetUserID(), out salexExecID);
                    model.Buyer.SalesExecId = salexExecID;
                    _buyerService.Insert(model.Buyer);
                    _unitOfWorkAsync.SaveChanges();
                    // Associate Module Group 
                    var moduleGroup = _moduleGroupService.Queryable().Where(x => x.TypeCode == "BUYR").FirstOrDefault();
                    _moduleGroupAccessService.Insert(new ModuleGroupAccess { ModuleGroupID = moduleGroup.ModuleGroupID, UserID = user.UserID, Active = true });
                    _unitOfWorkAsync.SaveChanges();
                    var assignedModules = GetAllowedModules(useremail).ToList();
                    var modulesToAdd = assignedModules.Select(x => new UserModules
                    {
                        AccessTypeID = 6,
                        ModuleID = x.ModuleID,
                        UserID = user.UserID
                    }).ToList();
                    _userModuleService.InsertRange(modulesToAdd);
                    Success(string.Format("<b>{0}</b> was successfully added to the database.", "Buyer Details"), true);
                    return RedirectToAction("Buyers");
                }
                catch (Exception)
                {
                    
                 
                    Danger("Looks like something went wrong. Please check your form.");
                    var Cities = _cityService.Queryable().OrderBy(x => x.CityName).Select(x => new SelectListItem
                    {
                        Text = x.CityName,
                        Value = x.Id.ToString()
                    }).ToList();
                    ViewBag.Cities = Cities;
                    buyerModel = new CreateBuyerVM();
                    buyerModel.Buyer = new Entities.Buyer();
                    return View(buyerModel);
                 
                } 
            
            }
            return View(model);
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
        #region Factory
        public ActionResult CreateFactory()
        {
            var Cities = _cityService.Queryable().OrderBy(x => x.CityName).Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.Cities = Cities;
            CreateFactoryVM model = new CreateFactoryVM();
            model.Factory = new Entities.Factory();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateFactory(CreateFactoryVM factoryModel)
        {
            if (ModelState.IsValid)
            {
                var useremail = User.Identity.GetUserNameIdentifier();
                var usertype = _userTypeService.Queryable().Where(x => x.TypeCode == "FCT").FirstOrDefault();
                var user = new User
                {
                    UserTypeID = usertype.ID,
                    Username = factoryModel.Email,
                    Email = factoryModel.Email,
                    CompId = 1,
                };
                try
                {
                    user = _membershipService.CreateUser(user, factoryModel.Password, useremail, usertype);
                    factoryModel.Factory.SuperUserId = user.UserID;
                    int salexExecID = 0;
                    Int32.TryParse(User.Identity.GetUserID(), out salexExecID);
                    factoryModel.Factory.CreatedByUserId = salexExecID;
                    _factoryService.Insert(factoryModel.Factory);
                    _unitOfWorkAsync.SaveChanges();
                    // Associate Module Group 
                    var moduleGroup = _moduleGroupService.Queryable().Where(x => x.TypeCode == "FCTR").FirstOrDefault();
                    _moduleGroupAccessService.Insert(new ModuleGroupAccess { ModuleGroupID = moduleGroup.ModuleGroupID, UserID = user.UserID });
                    _unitOfWorkAsync.SaveChanges();
                    // Add Modules Access
                    var modulesToAdd = _moduleService.Queryable().Where(x => x.ModuleGroupID == moduleGroup.ModuleGroupID).AsEnumerable().Select(x => new UserModules
                    {
                        AccessTypeID = 6,
                        ModuleID = x.Id,
                        UserID = user.UserID
                    }).ToList();
                    /// Save Data
                    _userModuleService.InsertRange(modulesToAdd);
                    _unitOfWorkAsync.SaveChanges();

                    Success(string.Format("<b>{0}</b> was successfully added to the database.", "Factory Details"), true);
                    return RedirectToAction("Factories");
                }
                catch (Exception)
                {
                    Danger("Looks like something went wrong. Please check your form.");
                    var Cities = _cityService.Queryable().OrderBy(x => x.CityName).Select(x => new SelectListItem
                    {
                        Text = x.CityName,
                        Value = x.Id.ToString()
                    }).ToList();
                    ViewBag.Cities = Cities;
                    factoryModel = new CreateFactoryVM();
                    factoryModel.Factory = new Entities.Factory();
                    return View(factoryModel);
                }
            }
            return View(factoryModel);
        }
        #endregion

        public JsonResult IsUserExists(string Email)
        {
            bool isUserExist = _userService.Queryable().Any(x => x.Email.ToLower() == Email.ToLower()
                || x.Username.ToLower() == Email.ToLower());
            return Json(!isUserExist, JsonRequestBehavior.AllowGet);
        }

    }
}