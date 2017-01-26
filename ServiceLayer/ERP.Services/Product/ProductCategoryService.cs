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
    public class ProductCategoryService : Service<ProductCategory>, IProductCategoryService
    {
        public readonly IRepositoryAsync<ProductCategory> _repository;
        public ProductCategoryService(IRepositoryAsync<ProductCategory> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductCategoryService : IService<ProductCategory>
    {
    }
}
