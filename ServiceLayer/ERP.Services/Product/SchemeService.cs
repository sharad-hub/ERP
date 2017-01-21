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
    public class SchemeService : Service<Scheme>, ISchemeService
    {
        public readonly IRepositoryAsync<Scheme> _repository;
        public SchemeService(IRepositoryAsync<Scheme> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface ISchemeService : IService<Scheme>
    {
    }
}
