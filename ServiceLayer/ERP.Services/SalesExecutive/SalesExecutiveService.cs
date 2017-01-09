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
    public class SalesExecutiveService : Service<SalesExecutive>, ISalesExecutiveService
    {
        public readonly IRepositoryAsync<SalesExecutive> _repository;
        public SalesExecutiveService(IRepositoryAsync<SalesExecutive> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface ISalesExecutiveService : IService<SalesExecutive>
    {
    }
}
