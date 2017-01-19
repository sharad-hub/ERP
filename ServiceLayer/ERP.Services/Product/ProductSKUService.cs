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
    public class ProductSKUService : Service<ProductSKU>, IProductSKUService
    {
        public readonly IRepositoryAsync<ProductSKU> _repository;
        public ProductSKUService(IRepositoryAsync<ProductSKU> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductSKUService : IService<ProductSKU>
    {
    }
}
