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
    public class ProductFactoryAllocationService : Service<ProductFactoryAllocation>, IProductFactoryAllocationService
    {
        public readonly IRepositoryAsync<ProductFactoryAllocation> _repository;
        public ProductFactoryAllocationService(IRepositoryAsync<ProductFactoryAllocation> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductFactoryAllocationService : IService<ProductFactoryAllocation>
    {
    }
}
