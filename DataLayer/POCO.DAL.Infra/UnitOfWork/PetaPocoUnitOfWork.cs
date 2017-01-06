


using POCO.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO.DAL.Infra
{
    public class PetaPocoUnitOfWork : IUnitOfWork
    {
        private readonly Transaction _petaTransaction;
        private readonly Database _db;        
        public PetaPocoUnitOfWork()
        {
            _db = new Database("ErpMain");          
            _petaTransaction = new Transaction(_db);
        }

        public void Dispose()
        {
            _petaTransaction.Dispose();
        }

        public Database Db
        {
            get { return _db; }
        }
       
        public void Commit()
        {
            _petaTransaction.Complete();
        }


       
    }      
}
