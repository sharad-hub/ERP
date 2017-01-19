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
    public class ProductSubGroupService : Service<ProductSubGroup>, IProductSubGroupService
    {
        public readonly IRepositoryAsync<ProductSubGroup> _repository;
        public ProductSubGroupService(IRepositoryAsync<ProductSubGroup> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductSubGroupService : IService<ProductSubGroup>
    {
    }
}
