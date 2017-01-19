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
    public class BuyerOrderItemService : Service<BuyerOrderItem>, IBuyerOrderItemService
    {
        public readonly IRepositoryAsync<BuyerOrderItem> _repository;
        public BuyerOrderItemService(IRepositoryAsync<BuyerOrderItem> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IBuyerOrderItemService : IService<BuyerOrderItem>
    {
    }
}
