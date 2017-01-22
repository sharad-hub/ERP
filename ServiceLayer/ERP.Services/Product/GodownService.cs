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
    public class GodownService : Service<Godown>, IGodownService
    {
        public readonly IRepositoryAsync<Godown> _repository;
        public GodownService(IRepositoryAsync<Godown> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface IGodownService : IService<Godown>
    {
    }
}
