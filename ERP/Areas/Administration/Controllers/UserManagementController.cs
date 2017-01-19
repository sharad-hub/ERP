using ERP.APIWrappers;
using ERP.Entities;
using ERP.Entities.SParams;
using ERP.Entities.SPModels;
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
using ERP.Entities.Models;
using ERP.Attribute;

namespace ERP.Areas.Administration.Controllers
{
    [ClaimsAuthorize(CustomClaimTypes.UserType, "SADM")]
    public class UserManagementController : BaseController
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
        public UserManagementController(IMembershipService membershipService, IUserService userService,
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
        }
        // GET: Admin
        public ActionResult Index()
        {
            var users = _userService.Queryable().Where(x => x.CompId == 0).OrderBy(x => x.Email).ToList();
            return View(users);
        }

        public ActionResult ManageUserMenu(int userId)
        {
            ///MenuVM
            ///
            //GetMenuByUserID
            var usersMenus = _storedProcedureService.GetMenuByUserID(new GetUserMenu { UserID = userId }).ToList();
            var menuIds = new HashSet<int>(usersMenus.Select(c => c.MenuID));
            var allMenus = _menuService.Queryable().OrderBy(x => x.Orderby).AsEnumerable().Select(x => new MenuVM
            {
                IsSelectd = menuIds.Contains(x.Id),
                MenuCode = x.MenuCode,
                ModuleID = x.ModuleId.GetValueOrDefault(),
                ModuleName = "",
                MenueName = x.MenuName,
                MenuID = x.Id
            }).ToList();
            var model = new UserMenuVM
            {
                Menu = allMenus,
                UserEmail = "",
                UserID = userId
            };
            return View(model);
        }

        public List<MenuForGui> GetAllMenu(string UserEmail)
        {
            var data = _storedProcedureService.GetMenuByUserName(new GetUserMenu { EmailAddress = UserEmail });
            if (data != null)
                return MainHelper.FormatMenu(data).ToList();
            else
                return null;
        }

        #region User Creation
        public ActionResult CreateBuyer()
        {
            var usertype = _userTypeService.Queryable().Where(x => x.TypeCode == "SLEX").FirstOrDefault();
            var SelesExecutives = _userService.Queryable().Where(x => x.UserTypeID == usertype.ID).Select(x => new SelectListItem
            {
                Text = x.Username,
                Value = x.UserID.ToString()
            }).ToList();
            ViewBag.SelesExecutives = SelesExecutives;
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
            string useremail = string.Empty;
            UserType usertype = null;
            if (ModelState.IsValid)
            {
                try
                {
                    useremail = User.Identity.GetUserNameIdentifier();
                    usertype = _userTypeService.Queryable().Where(x => x.TypeCode == "BUYR").FirstOrDefault();
                    var user = new User
                    {
                        UserTypeID = usertype.ID,
                        Username = model.Email,
                        Email = model.Email,
                        CompId = 1,
                    };
                    user = _membershipService.CreateUser(user, model.Password, useremail, usertype);
                    //buyer.Buyer.SalesExecId = 1;
                    model.Buyer.SuperUserId = user.UserID;
                    _buyerService.Insert(model.Buyer);
                    _unitOfWorkAsync.SaveChanges();
                    // Associate Module Group 
                    var moduleGroup = _moduleGroupService.Queryable().Where(x => x.TypeCode == "BUYR").FirstOrDefault();
                    _moduleGroupAccessService.Insert(new ModuleGroupAccess { Active = true, ModuleGroupID = moduleGroup.ModuleGroupID, UserID = user.UserID });
                    _unitOfWorkAsync.SaveChanges();
                    /// ADD MODULES ///            ///             
                    var modulesToAdd = _moduleService.Queryable().Where(x => x.ModuleGroupID == moduleGroup.ModuleGroupID).AsEnumerable().Select(x => new UserModules
                    {
                        AccessTypeID = 6,
                        ModuleID = x.Id,
                        UserID = user.UserID
                    }).ToList();

                    _userModulesService.InsertRange(modulesToAdd);
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b>Buyer({0})</b> was successfully added.", model.Email), true);
                }
                catch (Exception)
                {
                    Danger("Looks like something went wrong. Please check your form.");
                }
            }
            usertype = _userTypeService.Queryable().Where(x => x.TypeCode == "SLEX").FirstOrDefault();
            var SelesExecutives = _userService.Queryable().Where(x => x.UserTypeID == usertype.ID).Select(x => new SelectListItem
            {
                Text = x.Username,
                Value = x.UserID.ToString()
            }).ToList();
            ViewBag.SelesExecutives = SelesExecutives;
            var Cities = _cityService.Queryable().OrderBy(x => x.CityName).Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.Cities = Cities;
            model = new CreateBuyerVM();
            model.Buyer = new Buyer();
            return View(model);
        }

        public ActionResult CreateFactory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFactory(CreateFactoryVM factoryModel)
        {
            string useremail = string.Empty;
            UserType usertype = null;
            if (ModelState.IsValid)
            {
            }
            return View();
        }

        public ActionResult CreateSalesExec()
        {
            var designisations = _designationService.Queryable().Where(x => x.Status == true).Select(s => new SelectListItem
            {
                Text = s.DesignationName,
                Value = s.DesignationId.ToString()
            }).ToList();
            var conutries = _countryService.Queryable().Where(x => x.Status == true).Select(s => new SelectListItem
            {
                Text = s.CountryName,
                Value = s.ID.ToString()
            }).ToList();

            ViewBag.Designisations = designisations;
            ViewBag.countries = conutries;

            return View();
        }
        [HttpPost]
        public ActionResult CreateSalesExec(CreateSalesExecVM salexExecutiveModel)
        {
            string userEmail = string.Empty;
            UserType userType = null;
            if (ModelState.IsValid)
            {  
                try
                {
                    userEmail = User.Identity.GetUserNameIdentifier();
                    var CreatorUser = _userService.Queryable().Where(x => x.Email == userEmail).FirstOrDefault();
                    userType = _userTypeService.Queryable().Where(x => x.TypeCode == "SLEX").FirstOrDefault();
                    var user = new User { Email = salexExecutiveModel.Email, CompId = 1, DateCreated = DateTime.Now, IsLocked = false, CreatedByUserID = CreatorUser.UserID };
                    user = _membershipService.CreateUser(user, salexExecutiveModel.Password, userEmail, userType);
                    salexExecutiveModel.SalesExecutive.SalesExecUserID = user.UserID;
                    var moduleGroup = _moduleGroupService.Queryable().Where(x => x.TypeCode == "SLES").FirstOrDefault();
                    _moduleGroupAccessService.Insert(new ModuleGroupAccess { ModuleGroupID = moduleGroup.ModuleGroupID, UserID = user.UserID, Active = true });
                    _salesExecutiveService.Insert(salexExecutiveModel.SalesExecutive);
                    _unitOfWorkAsync.SaveChanges();
                    /// ADD MODULES ///      
                    var extraModuleGroup = _moduleGroupService.Queryable().Where(x => x.TypeCode == "SLUR").FirstOrDefault();
                    List<int> modulesgroups = new List<int>();
                    modulesgroups.Add(extraModuleGroup.ModuleGroupID);
                    modulesgroups.Add(moduleGroup.ModuleGroupID);
                    //== extraModuleGroup.ModuleGroupID || x.ModuleGroupID == moduleGroup.ModuleGroupID
                    var modulesToAdd = _moduleService.Queryable().Where(x => x.ModuleGroupID == moduleGroup.ModuleGroupID).AsEnumerable().Select(x => new UserModules
                    {
                        AccessTypeID = 6,
                        ModuleID = x.Id,
                        UserID = user.UserID
                    }).ToList();

                    var modulesToAddExt = _moduleService.Queryable().Where(x => x.ModuleGroupID == extraModuleGroup.ModuleGroupID).AsEnumerable().Select(x => new UserModules
                    {
                        AccessTypeID = 6,
                        ModuleID = x.Id,
                        UserID = user.UserID
                    }).ToList();
                    modulesToAdd.AddRange(modulesToAddExt);
                    _userModulesService.InsertRange(modulesToAdd);
                    _unitOfWorkAsync.SaveChanges();
                    Success(string.Format("<b> Sales Executive({0})</b> was successfully added.", salexExecutiveModel.Email), true);       
                }
                catch (Exception)
                {
                    Danger("Looks like something went wrong. Please check your form.");
                }
                
            }
            var designisations = _designationService.Queryable().Where(x => x.Status == true).Select(s => new SelectListItem
            {
                Text = s.DesignationName,
                Value = s.DesignationId.ToString()
            }).ToList();
            var conutries = _countryService.Queryable().Where(x => x.Status == true).Select(s => new SelectListItem
            {
                Text = s.CountryName,
                Value = s.ID.ToString()
            }).ToList();

            ViewBag.Designisations = designisations;
            ViewBag.countries = conutries;
            return View();
        }


        public ActionResult SalesExecutives()
        {
            var countries = _countryService.Queryable().Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.ID.ToString()
            }).ToList();
            var salexExecutives = _salesExecutiveService.Queryable().Where(x => x.Status == true).ToList();
            return View(salexExecutives);
        }

        public ActionResult Buyers()
        {
            var buyers = _buyerService.Queryable().Where(x => x.Status == true).ToList();
            return View(buyers);
        }
        public ActionResult Factories()
        {
            var buyers = _factoryService.Queryable().Where(x => x.Status == true).ToList();
            return View(buyers);
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