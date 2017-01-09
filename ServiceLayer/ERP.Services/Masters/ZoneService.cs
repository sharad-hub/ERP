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
    public class ZoneService : Service<Zone>, IZoneService
    {
        public readonly IRepositoryAsync<Zone> _repository;
        public ZoneService(IRepositoryAsync<Zone> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IZoneService : IService<Zone>
    {
    }
}
