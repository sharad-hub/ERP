using ERP.Entities;
using ERP.Entities.Models;
using ERP.Entities.Models.ProductEntities;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
    public class ProductImageService : Service<ProductImage>, IProductImageService
    {
        public readonly IRepositoryAsync<ProductImage> _repository;
        public ProductImageService(IRepositoryAsync<ProductImage> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IProductImageService : IService<ProductImage>
    {
    }
}
