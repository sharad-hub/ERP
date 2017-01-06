using ERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class UserManagementController : Controller
    {
        IMembershipService _membershipService;
        IUserService _userService;
        IMenuService _menuService;
        public UserManagementController(IMembershipService membershipService, IUserService userService,IMenuService menuService)
        {
            _membershipService=membershipService;
            _userService = userService;
            _menuService = menuService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            _userService.Queryable().Where(x => x.CompId == 0).OrderBy(x => x.Email);
            return View();
        }
    }
}