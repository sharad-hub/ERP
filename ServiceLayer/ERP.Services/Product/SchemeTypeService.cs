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
    public class SchemeTypeService : Service<SchemeType>, ISchemeTypeService
    {
        public readonly IRepositoryAsync<SchemeType> _repository;
        public SchemeTypeService(IRepositoryAsync<SchemeType> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
    public interface ISchemeTypeService : IService<SchemeType>
    {
    }
}
