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
    public class UnitOfMaterialService : Service<UnitOfMeasurement>, IUnitOfMaterialService
    {
        public readonly IRepositoryAsync<UnitOfMeasurement> _repository;
        public UnitOfMaterialService(IRepositoryAsync<UnitOfMeasurement> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IUnitOfMaterialService : IService<UnitOfMeasurement>
    {
    }
}
