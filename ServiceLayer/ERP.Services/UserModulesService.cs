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
    public class UserModulesService : Service<UserModules>, IUserModulesService
    {
        public readonly IRepositoryAsync<UserModules> _repository;
        public UserModulesService(IRepositoryAsync<UserModules> repository)
            : base(repository)
        {
            _repository = repository;
        }

        //public void AddUserModule(UserModules userModule)
        //{
        //    _repository.Insert(userModule);
        //}

        //public void AddUserModules(List<UserModules> userModules)
        //{
        //    _repository.InsertRange(userModules);
        //}
    }
    public interface IUserModulesService : IService<UserModules>
    {
    }
}
