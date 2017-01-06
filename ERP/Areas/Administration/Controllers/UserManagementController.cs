using ERP.APIWrappers;
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

namespace ERP.Areas.Administration.Controllers
{
    public class UserManagementController : Controller
    {
        IMembershipService _membershipService;
        IUserService _userService;
        IMenuService _menuService;
        IModuleService _moduleService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        IStoredProcedureService _storedProcedureService;
        public UserManagementController(IMembershipService membershipService, IUserService userService, IMenuService menuService, IModuleService moduleService, IUnitOfWorkAsync unitOfWorkAsync, IStoredProcedureService storedProcedureService)
        {
            _membershipService = membershipService;
            _userService = userService;
            _menuService = menuService;
            _moduleService = moduleService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _storedProcedureService = storedProcedureService;
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
                MenueName=x.MenuName,
                MenuID=x.Id
            }).ToList();
            var model = new UserMenuVM
            {
                Menu = allMenus,
                UserEmail = "",
                UserID = userId
            };
            return View(model);
        }

        public   List<MenuForGui> GetAllMenu(string UserEmail)
        {
            var data = _storedProcedureService.GetMenuByUserName(new GetUserMenu { EmailAddress = UserEmail });
            if (data != null)
                return MainHelper.FormatMenu(data).ToList();
            else
                return null;
        }
    }
}