using ERP.Entities;
using ERP.Entities.Models;
using ERP.Entities.Models.Order;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
    public class OrderStatusService : Service<OrderStatus>, IOrderStatusService
    {
        public readonly IRepositoryAsync<OrderStatus> _repository;
        public OrderStatusService(IRepositoryAsync<OrderStatus> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IOrderStatusService : IService<OrderStatus>
    {
    }
}
