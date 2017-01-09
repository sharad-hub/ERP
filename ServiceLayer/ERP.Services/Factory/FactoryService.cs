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
    public class FactoryService : Service<Factory>, IFactoryService
    {
        public readonly IRepositoryAsync<Factory> _repository;
        public FactoryService(IRepositoryAsync<Factory> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IFactoryService : IService<Factory>
    {
    }
}
