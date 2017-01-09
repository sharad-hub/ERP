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
    public class BuyerService : Service<Buyer>, IBuyerService
    {
        public readonly IRepositoryAsync<Buyer> _repository;
        public BuyerService(IRepositoryAsync<Buyer> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IBuyerService : IService<Buyer>
    {
    }
}
