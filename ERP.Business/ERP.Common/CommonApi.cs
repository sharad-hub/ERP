
using DCLife.DAO;
using ERP.Common;
using ERP.DTO;
using POCO.DAL;
using POCO.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common
{
    public class CommonApi : ICommonApi
    {
        private ICommonDAO _objCommonDao;
        PetaPocoUnitOfWorkProvider unitOfWorkProvider;
        private long _responseCode;
        public CommonApi()
        {
            _objCommonDao = new CommonDAO();
            unitOfWorkProvider = new PetaPocoUnitOfWorkProvider();
        }

        public ErrorLog WriteLog(ErrorLog log)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                ErrorLog objError = _objCommonDao.AddErrorLog(log, uow);
                uow.Commit();
                return objError;
            }
        }

    }
}
