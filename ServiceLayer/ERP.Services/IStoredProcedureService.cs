#region

using ERP.Data.Models;
using ERP.Entities.SParams;
using ERP.Entities.SPModels;
using System.Collections.Generic;
using System.Threading.Tasks;
 

#endregion

namespace ERP.Servicess
{
    public interface IStoredProcedureService
    {
        //IEnumerable<ProductUIDetail> GetProductsForUI();
        int AssignMenueToUser(AddUserMenu addUserMenu);
        IEnumerable<UserMenuMap> GetMenuByUserID(GetUserMenu getUserMenu);
        IEnumerable<UserMenuDetails> GetMenuByUserName(GetUserMenu getUserMenu);

        IEnumerable<UserSetting> GetDefaultSettingsForUser(GetUserMenu getUserMenu);
        IEnumerable<UserModuleDetails> GetModulesByUserName(string  email);
        Task<OrderDetails> GetOrderDetails(OrderDetailsParam orderParams);
        Task<FreeQuantityOnOrder> GetFreeQuantityOnOrder(GetFreeQuantityOnOrderParams param);
    }
    public class StoredProcedureService:IStoredProcedureService
    {
        private readonly IERPStoredProcedure _storedProcedures;

        public StoredProcedureService(IERPStoredProcedure storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }
        //IEnumerable<UserSetting> GetDefaultSettingsForUser(GetUserMenu getUserMenu)
        //{
        //  return  _storedProcedures.GetDefaultSettingsForUser(getUserMenu);
        //}
        public int AssignMenueToUser(AddUserMenu addUserMenu)
        {
            return _storedProcedures.AssignMenueToUser(addUserMenu);
        }
        public IEnumerable<UserMenuMap> GetMenuByUserID(GetUserMenu getUserMenu)
        {
            return _storedProcedures.GetMenuByUserID(getUserMenu);
        }
        IEnumerable<UserMenuDetails> GetMenuByUserName(GetUserMenu getUserMenu)
        {
            return _storedProcedures.GetUserMenus(getUserMenu);
        }


        IEnumerable<UserMenuDetails> IStoredProcedureService.GetMenuByUserName(GetUserMenu getUserMenu)
        {
              return _storedProcedures.GetUserMenus(getUserMenu);
        }

        IEnumerable<UserModuleDetails> GetModulesByUserName(string email)
        {
            return _storedProcedures.GetModulesByUserName(email);
        }


        IEnumerable<UserModuleDetails> IStoredProcedureService.GetModulesByUserName(string email)
        {
            return _storedProcedures.GetModulesByUserName(email);
        }


        IEnumerable<UserSetting> IStoredProcedureService.GetDefaultSettingsForUser(GetUserMenu getUserMenu)
        {
            return _storedProcedures.GetDefaultSettingsForUser(getUserMenu);
        }
        public Task<OrderDetails> GetOrderDetails(OrderDetailsParam orderParams)
        {
            return _storedProcedures.GetOrderDetails(orderParams);
        }
        public Task<FreeQuantityOnOrder> GetFreeQuantityOnOrder(GetFreeQuantityOnOrderParams param)
        {
            return _storedProcedures.GetFreeQuantityOnOrder(param);
        }
    }
}