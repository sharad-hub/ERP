 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using POCO.DAL.Infra;
using POCO.DAL.UnitOfWork;
using ERP.DTO;
using DCLife.DAO;

namespace POCO.DAL
{

    public class CommonDAO : DAOBase, ICommonDAO
    {
      
        public ErrorLog AddErrorLog(ErrorLog log, IUnitOfWork uow = null)
        {
            var s = Sql.Builder.Append(";EXEC [ERROR].LogError @@ErrorId = @0", log.ErrorID);
            s.Append(", @@UserName= @0", log.UserName);
            s.Append(", @@Details= @0", log.Details);
            return GetDB(uow).SingleOrDefault<ErrorLog>(s);
        }        
    }
}
