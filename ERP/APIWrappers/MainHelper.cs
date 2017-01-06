using ERP.Entities;
using ERP.Entities.SParams;
using ERP.Entities.SPModels;
using ERP.Models;
using ERP.Services;
using ERP.Servicess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.APIWrappers
{
    public static class MainHelper
    {
        static IUserService _userService;
        static IMenuService _menuService;
        static IModuleService _moduleService;
        static IStoredProcedureService _storedProcedureService;

         static MainHelper()
        {
            //
            //_userService = new UserService();// userService;
            //_menuService = menuService;
            //_moduleService = moduleService;
            //_storedProcedureService = storedProcedureService;
        }
        //public static List<MenuForGui> GetAllMenu(string UserEmail)
        //{
        //    var data = _storedProcedureService.GetMenuByUserName(new GetUserMenu { EmailAddress = UserEmail });
        //    if (data != null)
        //        return  MainHelper.FormatMenu(data).ToList();
        //    else
        //    return null;
        //}

        public static IEnumerable<MenuForGui> FormatMenu(IEnumerable<UserMenuDetails> menus)
        {
            return (from log in menus
                    group log by log.ModuleId into g
                    orderby g.Key
                    select new MenuForGui
                    {
                        ModuleID = g.Key,
                        Count = g.Count(),
                        Menu = g.Select(dto =>
                          new MenuDetails
                          {
                              Id = dto.Id,
                              MenuName = dto.MenuName,
                              MenuCode = dto.MenuCode,
                              Orderby = dto.Orderby,
                              IconID = dto.IconID,
                              ControllerName = dto.ControllerName,
                              ActionName = dto.ActionName,
                              ModuleId = dto.ModuleId,
                              ModuleName = dto.ModuleName
                          }).ToList()
                    });
        }
    }
}