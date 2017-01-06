

using POCO.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO.DAL.Infra
{
    public abstract class DAOBase
    {
        public DAOBase()
        {
            ConnectionStringName = "DCLifeMain";
            ConnectionStringNameMsg = "DCLifeMSG";
            ConnectionStringPafDB = "dcPafEntities";
        }
        public DAOBase(string connectionStringName, string connectionStringNameMsg)
        {
            ConnectionStringName = connectionStringName;
            ConnectionStringNameMsg = connectionStringNameMsg;
        }

        public DAOBase(string connectionStringName, string connectionStringNameMsg, string connectionStringPafDB)
        {
            ConnectionStringName = connectionStringName;
            ConnectionStringNameMsg = connectionStringNameMsg;
            ConnectionStringPafDB = connectionStringPafDB;
        }
        public string ConnectionStringName { get; set; }
        public string ConnectionStringNameMsg { get; set; }
        public string ConnectionStringPafDB { get; set; }

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
