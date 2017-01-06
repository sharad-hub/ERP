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
    public class ModuleService : Service<Module>, IModuleService
    {
        public readonly IRepositoryAsync<Module> _repository;
        public ModuleService(IRepositoryAsync<Module> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IModuleService : IService<Module>
    {
    }
}
