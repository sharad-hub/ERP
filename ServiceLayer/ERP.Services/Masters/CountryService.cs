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
    public class CountryService : Service<Country>, ICountryService
    {
        public readonly IRepositoryAsync<Country> _repository;
        public CountryService(IRepositoryAsync<Country> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface ICountryService : IService<Country>
    {
    }
}
