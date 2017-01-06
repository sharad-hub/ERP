using POCO.DAL.Infra;
using POCO.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO.DAL
{
    public abstract class DALBase
    {
        public DALBase()
        {
            ConnectionStringName = "ERPMain";           
        }
        public DALBase(string connectionStringName)
        {
            ConnectionStringName = connectionStringName;
          
        }
        public string ConnectionStringName { get; set; }
        public string ConnectionStringNameMsg { get; set; }

        protected Database GetDB(IUnitOfWork uow)
        {
            if (uow != null)
                return uow.Db;
            else
            {
                var db = new Database(ConnectionStringName);
                return db;
            }
        }       
    }
}
