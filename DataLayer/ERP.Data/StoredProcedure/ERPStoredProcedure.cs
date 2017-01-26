using ERP.Entities.SParams;
using ERP.Entities.SPModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;

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

        public IEnumerable<UserSetting> GetDefaultSettingsForUser(GetUserMenu getUserMenu)
        {
            var UserEmail = new SqlParameter("@UserEmail", getUserMenu.EmailAddress.ToString());
            return Database.SqlQuery<UserSetting>("GetDefaultSettingsForUser @UserEmail", UserEmail);
        }
        

        IEnumerable<UserModuleDetails> GetModulesByUserName(string email)
        {
            var emailAddress = new SqlParameter("@UserEmail", email);
            return Database.SqlQuery<UserModuleDetails>("[GET_USER_MODULES] @UserEmail", emailAddress);
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


        IEnumerable<UserModuleDetails> IERPStoredProcedure.GetModulesByUserName(string email)
        {
            var emailAddress = new SqlParameter("@UserEmail", email);
            return Database.SqlQuery<UserModuleDetails>("[GET_USER_MODULES] @UserEmail", emailAddress);
        }


        public IEnumerable<UserClaims> GetUserClaims(string userEmail)
        {
            var emailAddress = new SqlParameter("@UserEmail", userEmail);
            return Database.SqlQuery<UserClaims>("[GetUserClaims] @UserEmail", emailAddress);
        }

        public Task<OrderDetails> GetOrderDetails(OrderDetailsParam orderParams)
        {
            var param = new SqlParameter("@OrderId", orderParams.OrderId);
            return Database.SqlQuery<OrderDetails>("[GetOrderDetails] @OrderId", param).FirstAsync();
        }
        public Task<FreeQuantityOnOrder> GetFreeQuantityOnOrder(GetFreeQuantityOnOrderParams paramObj)
        {

            var productId = new SqlParameter("@ProductId", paramObj.ProductId);
            var productQuantity = new SqlParameter("@ProductQuantity", paramObj.ProductQuantity);
            return Database.SqlQuery<FreeQuantityOnOrder>("[GetFreeQuantityOnOrder] @ProductQuantity,@ProductId", productQuantity, productId).FirstAsync();
        }
    }
    public interface IERPStoredProcedure
    {
        int AssignMenueToUser(AddUserMenu addUserMenu);
        IEnumerable<UserMenuDetails> GetUserMenus(GetUserMenu getUserMenu);
        IEnumerable<UserMenuMap> GetMenuByUserID(GetUserMenu getUserMenu);

        IEnumerable<UserModuleDetails> GetModulesByUserName(string email);
        IEnumerable<UserSetting> GetDefaultSettingsForUser(GetUserMenu getUserMenu);

        IEnumerable<UserClaims> GetUserClaims(string  email);

        Task<OrderDetails> GetOrderDetails(OrderDetailsParam orderParams);
        Task<FreeQuantityOnOrder> GetFreeQuantityOnOrder(GetFreeQuantityOnOrderParams param);
    }
}
