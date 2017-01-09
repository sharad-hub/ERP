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
    public class CityService : Service<City>, ICityService
    {
        public readonly IRepositoryAsync<City> _repository;
        public CityService(IRepositoryAsync<City> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface ICityService : IService<City>
    {
    }
}
