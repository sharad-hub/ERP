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
    public class ProductTypeService : Service<ProductType>, IProductTypeService
    {
        public readonly IRepositoryAsync<ProductType> _repository;
        public ProductTypeService(IRepositoryAsync<ProductType> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductTypeService : IService<ProductType>
    {
    }
}
