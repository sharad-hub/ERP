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
    public class ProductService : Service<Product>, IProductService
    {
        public readonly IRepositoryAsync<Product> _repository;
        public ProductService(IRepositoryAsync<Product> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductService : IService<Product>
    {
    }
}
