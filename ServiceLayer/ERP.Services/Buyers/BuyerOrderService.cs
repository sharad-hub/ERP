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
    public class BuyerOrderService : Service<BuyerOrder>, IBuyerOrderService
    {
        public readonly IRepositoryAsync<BuyerOrder> _repository;
        public BuyerOrderService(IRepositoryAsync<BuyerOrder> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IBuyerOrderService : IService<BuyerOrder>
    {
    }
}
