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
    public class ModuleGroupAccessService : Service<ModuleGroupAccess>, IModuleGroupAccessService
    {
        public readonly IRepositoryAsync<ModuleGroupAccess> _repository;
        public ModuleGroupAccessService(IRepositoryAsync<ModuleGroupAccess> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<ModuleGroupAccess> GetAccessableModuleGroups(string UserEmail)
        {
            return _repository.Queryable().Where(x => (x.User.Email == UserEmail || x.User.Username == UserEmail) && x.Active == true);
        }

        public IEnumerable<ModuleGroupAccess> GetAccessableModuleGroups(int UserID)
        {
            return _repository.Queryable().Where(x => x.UserID == UserID && x.Active == true);
        }

        public void AddModuleGroupAccess(int UserID, int ModuleGroupID)
        {
            _repository.Insert(new ModuleGroupAccess { UserID = UserID, ModuleGroupID = ModuleGroupID });
        }

        public void AddModuleGroupAccess(int UserID, ModuleGroup ModuleGroup)
        {
            throw new NotImplementedException();
        }

        public void RemoveModuleGroupAccess(int UserID, int ModuleGroupID)
        {
            throw new NotImplementedException();
        }

        public void RemoveModuleGroupAccess(int UserID, ModuleGroup ModuleGroup)
        {
            throw new NotImplementedException();
        }
       
    }
    public interface IModuleGroupAccessService : IService<ModuleGroupAccess>
    {
        IEnumerable<ModuleGroupAccess> GetAccessableModuleGroups(string UserEmail);
        IEnumerable<ModuleGroupAccess> GetAccessableModuleGroups(int UserID);

        void AddModuleGroupAccess(int UserID, int ModuleGroupID);
        void AddModuleGroupAccess(int UserID, ModuleGroup ModuleGroup);

        void RemoveModuleGroupAccess(int UserID, int ModuleGroupID);
        void RemoveModuleGroupAccess(int UserID, ModuleGroup ModuleGroup);

    }
}
