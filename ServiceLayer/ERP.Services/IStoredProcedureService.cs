#region

using ERP.Data.Models;
using ERP.Entities.SParams;
using ERP.Entities.SPModels;
using System.Collections.Generic;
 

#endregion

namespace ERP.Servicess
{
    public interface IStoredProcedureService
    {
        //IEnumerable<ProductUIDetail> GetProductsForUI();
        int AssignMenueToUser(AddUserMenu addUserMenu);
        IEnumerable<UserMenuMap> GetMenuByUserID(GetUserMenu getUserMenu);
        IEnumerable<UserMenuDetails> GetMenuByUserName(GetUserMenu getUserMenu);
    }
    public class StoredProcedureService:IStoredProcedureService
    {
        private readonly IERPStoredProcedure _storedProcedures;

        public StoredProcedureService(IERPStoredProcedure storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }

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
    }
}