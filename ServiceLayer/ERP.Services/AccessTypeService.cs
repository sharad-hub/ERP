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
    public class AccessTypeService : Service<AccessType>, IAccessTypeService
    {
        public readonly IRepositoryAsync<AccessType> _repository;
        public AccessTypeService(IRepositoryAsync<AccessType> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IAccessTypeService : IService<AccessType>
    {
    }
}
