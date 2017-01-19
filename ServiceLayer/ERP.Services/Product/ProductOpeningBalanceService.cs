using ERP.Entities;
using ERP.Entities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
    public class ProductOpeningBalanceService : Service<ProductOpeningBalance>, IProductOpeningBalanceService
    {
        public readonly IRepositoryAsync<ProductOpeningBalance> _repository;
        public ProductOpeningBalanceService(IRepositoryAsync<ProductOpeningBalance> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductOpeningBalanceService : IService<ProductOpeningBalance>
    {
    }
}
