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
    public class DesignationService : Service<Designation>, IDesignationService
    {
        public readonly IRepositoryAsync<Designation> _repository;
        public DesignationService(IRepositoryAsync<Designation> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IDesignationService : IService<Designation>
    {
    }
}
