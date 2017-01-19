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
    public class UserTypeService : Service<UserType>, IUserTypeService
    {
        public readonly IRepositoryAsync<UserType> _repository;
        public UserTypeService(IRepositoryAsync<UserType> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IUserTypeService : IService<UserType>
    {
    }
}
