using Shop.Data;
using Shop.Entities.Procedures;
using System.Collections.Generic;
  

namespace Shop.Services
{
    public class StoredProcedureService : IStoredProcedureService
    {
        private readonly IShopStoredProcedures _storedProcedures;

        public StoredProcedureService(IShopStoredProcedures storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }

        public IEnumerable<ProductUIDetail> GetProductsForUI()
        {
            return _storedProcedures.ProductUIDetail( );
        }

       
     
    }
}