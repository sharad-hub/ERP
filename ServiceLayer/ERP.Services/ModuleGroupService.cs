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
    public class ModuleGroupService : Service<ModuleGroup>, IModuleGroupService
    {
        public readonly IRepositoryAsync<ModuleGroup> _repository;
        public ModuleGroupService(IRepositoryAsync<ModuleGroup> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IModuleGroupService : IService<ModuleGroup>
    {
    }
}
