
using ERP.Entities;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository
{
    public static class ErrorRepository
    {
        public static Error GetErrorId(this IRepository<Error> repository, int Id)
        {
            return repository.Queryable().Where(x => x.ID == Id).FirstOrDefault();
        }
        static void SaveErorr(this Repository<Error> repository, Error error)
        {
            repository.Insert(error);
        }
        public static IEnumerable<Error> GetErrorByDate(this IRepository<Error> repository, DateTime date)
        {
            return repository.Queryable().Where(x => x.DateCreated.Date == date.Date);
        }

        //public static IEnumerable<Error> GetErrorFilter(this IRepository<Error> repository, Func<T> fn)
        //{
        //    return repository.Queryable().Where(fn);

        //}
    }
}
