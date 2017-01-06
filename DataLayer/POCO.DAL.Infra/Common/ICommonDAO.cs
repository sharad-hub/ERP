using ERP.DTO;
using POCO.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DCLife.DAO
{
    public interface ICommonDAO
    {        
        ErrorLog AddErrorLog(ErrorLog log, IUnitOfWork uow = null);       
    }
}
