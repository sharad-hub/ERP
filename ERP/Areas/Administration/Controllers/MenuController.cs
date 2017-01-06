using ERP.Entities;
using ERP.Models;
using ERP.Services;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Administration.Controllers
{
    public class MenuController : Controller
    {
        IMembershipService _membershipService;
        IUserService _userService;
        IMenuService _menuService;
        IModuleService _moduleService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        public MenuController(IMembershipService membershipService, IUserService userService, IMenuService menuService, IModuleService moduleService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _membershipService = membershipService;
            _userService = userService;
            _menuService = menuService;
            _moduleService = moduleService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        #region MENU CRUD
     
        // GET: Admin
        public ActionResult Index()
        {
            var menus = _menuService.Queryable().OrderBy(x => x.MenuName).ToList();
            return View(menus);
        }
        // GET: Admin
        public ActionResult AddMenu()
        {
            var menus = _moduleService.Queryable().OrderBy(x => x.ModuleName).AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.ModuleName,
                Value = x.Id.ToString()
            }).ToList();
            //SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId)
            return View(new AddMenuVM { AvailableModule = menus, Module = new Module() });
        }
        // GET: Admin
        [HttpPost]
        public ActionResult AddMenu(Menu menu)
        {
            Menu m = new Menu();
            _menuService.Insert(menu);
            _unitOfWorkAsync.SaveChanges();
            var menus = _moduleService.Queryable().OrderBy(x => x.ModuleName).AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.ModuleName,
                Value = x.Id.ToString()
            }).ToList();

            return RedirectToAction("Index", new AddMenuVM { AvailableModule = menus, Module = new Module() });
        }

        // GET: Admin
        public ActionResult EditMenu(int id)
        {
            var menu = _menuService.Queryable().Where(x => x.Id == id).FirstOrDefault();
            var modules = _moduleService.Queryable().OrderBy(x => x.ModuleName).AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.ModuleName,
                Value = x.Id.ToString()
            }).ToList();
            var editMenu = new AddMenuVM { AvailableModule = modules, Module = new Module() };
            if (menu != null)
            {
                editMenu.ModuleId = menu.ModuleId;
                editMenu.Orderby = menu.Orderby;
                editMenu.ActionName = menu.ActionName;
                editMenu.ControllerName = menu.ControllerName;
                editMenu.MenuName = menu.MenuName;
                editMenu.MenuCode = menu.MenuCode;
            }
            //SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId)
            return View(editMenu);
        }
        // GET: Admin
        [HttpPost]
        public ActionResult EditMenu(Menu menu)
        {
            Menu m = new Menu();
            _menuService.Update(menu);
            _unitOfWorkAsync.SaveChanges();
            var menus = _moduleService.Queryable().OrderBy(x => x.ModuleName).AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.ModuleName,
                Value = x.Id.ToString()
            }).ToList();

         return  RedirectToAction("Index",new AddMenuVM { AvailableModule = menus, Module = new Module() });
        }
        #endregion
    }
}