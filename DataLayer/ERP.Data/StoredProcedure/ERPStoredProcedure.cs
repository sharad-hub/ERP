using ERP.Entities.SParams;
using ERP.Entities.SPModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ERP.Data.Models
{

    public partial class GERPContext : IERPStoredProcedure
    {

        // int AssignMenueToUser(AddUserMenu addUserMenu)
        //{
        //    var menuId = new SqlParameter("@MenuId", addUserMenu.MenueID);
        //    var userID = new SqlParameter("@UserID", addUserMenu.UserID);
        //    var accessTypeID = new SqlParameter("@AccessTypeID", addUserMenu.AccessTypeID);        
        //    return Database.ExecuteSqlCommand("ADD_USER_MENUE @MenuId,@UserID,@AccessTypeID", menuId, userID, accessTypeID);
        //}
        public IEnumerable<UserMenuMap> GetMenuByUserID(GetUserMenu getUserMenu)
        {
            var UserID = new SqlParameter("@UserID", getUserMenu.UserID.ToString());
            return Database.SqlQuery<UserMenuMap>("GET_MENU_BY_USERID @UserID", UserID);
        }
        public IEnumerable<UserMenuDetails> GetUserMenus(GetUserMenu getUserMenu)
        {
            var emailAddress = new SqlParameter("@UserEmail", getUserMenu.EmailAddress);
            return Database.SqlQuery<UserMenuDetails>("[GET_USER_MENUS] @UserEmail", emailAddress);
        }
        int IERPStoredProcedure.AssignMenueToUser(AddUserMenu addUserMenu)
        {
            var menuId = new SqlParameter("@MenuId", addUserMenu.MenueID);
            var userID = new SqlParameter("@UserID", addUserMenu.UserID);
            var accessTypeID = new SqlParameter("@AccessTypeID", addUserMenu.AccessTypeID);
            return Database.ExecuteSqlCommand("ADD_USER_MENUE @MenuId,@UserID,@AccessTypeID", menuId, userID, accessTypeID);
        }
    }
    public interface IERPStoredProcedure
    {
        int AssignMenueToUser(AddUserMenu addUserMenu);
        IEnumerable<UserMenuDetails> GetUserMenus(GetUserMenu getUserMenu);
        IEnumerable<UserMenuMap> GetMenuByUserID(GetUserMenu getUserMenu);
    }
}
