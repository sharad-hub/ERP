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
    public class TariffService : Service<Tariff>, ITariffService
    {
        public readonly IRepositoryAsync<Tariff> _repository;
        public TariffService(IRepositoryAsync<Tariff> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface ITariffService : IService<Tariff>
    {
    }
}
