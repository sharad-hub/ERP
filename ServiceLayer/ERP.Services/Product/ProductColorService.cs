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
    public class ProductColorService : Service<ProductColor>, IProductColorService
    {
        public readonly IRepositoryAsync<ProductColor> _repository;
        public ProductColorService(IRepositoryAsync<ProductColor> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductColorService : IService<ProductColor>
    {
    }
}
