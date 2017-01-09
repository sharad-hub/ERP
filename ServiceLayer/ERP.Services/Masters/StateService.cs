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
    public class StateService : Service<State>, IStateService
    {
        public readonly IRepositoryAsync<State> _repository;
        public StateService(IRepositoryAsync<State> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IStateService : IService<State>
    {
    }
}
