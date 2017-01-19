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
    public class ProductGroupService : Service<ProductGroup>, IProductGroupService
    {
        public readonly IRepositoryAsync<ProductGroup> _repository;
        public ProductGroupService(IRepositoryAsync<ProductGroup> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductGroupService : IService<ProductGroup>
    {
    }
}
