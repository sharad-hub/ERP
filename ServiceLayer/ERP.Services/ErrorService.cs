

using ERP.Entities;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
   public interface IErrorService :IService<Error>
    {
       void AddError(Error error);
    }

   public class ErrorService : Service<Error>, IErrorService
   {

       private readonly IRepositoryAsync<Error> _repository;

       public ErrorService(IRepositoryAsync<Error> repository)
            : base(repository)
        {
            _repository = repository;
        }

       public void AddError(Error error)
       {
           _repository.Insert(error);
       }
   }
    
}
