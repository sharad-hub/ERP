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
    public class UserSettingsService : Service<SystemSetting>, IUserSettingsService
    {
        public readonly IRepositoryAsync<SystemSetting> _repository;
        public UserSettingsService(IRepositoryAsync<SystemSetting> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<SystemSetting> GetUserSettingsByEmail(string email)
        {
           return  _repository.Queryable().Where(x => x.User.Email == email);
        }
    }
    public interface IUserSettingsService : IService<SystemSetting>
    {
        IEnumerable<SystemSetting> GetUserSettingsByEmail(string email);
    }
}
