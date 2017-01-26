using ERP.Entities;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services.Masters
{
    public class FinancialYearService : Service<FinYear>, IFinancialYearService
    {
        public readonly IRepositoryAsync<FinYear> _repository;
        public FinancialYearService(IRepositoryAsync<FinYear> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IFinancialYearService : IService<FinYear>
    {

    }
}
