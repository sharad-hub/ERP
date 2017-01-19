
using ERP.Entities;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
  public  class UserService:Service<User>,IUserService
    {

        private const string CUSTOMERROLES_ALL_KEY = "SmartStore.customerrole.all-{0}";
        private const string CUSTOMERROLES_BY_SYSTEMNAME_KEY = "SmartStore.customerrole.systemname-{0}";
        private const string CUSTOMERROLES_PATTERN_KEY = "SmartStore.customerrole.";
      IRepositoryAsync<User> _userRepository;
      //private readonly IRepositoryAsync<GenericAttribute> _gaRepository;
      
      
      //private readonly IGenericAttributeService _genericAttributeService;
     
      public UserService( IRepositoryAsync<User> userRepository):base(userRepository)
      {
          _userRepository = userRepository;
      }
      //public Localizer T { get; set; }




      public IEnumerable<User> GetUsersByTypeCode(string typeCode)
      {
          throw new NotImplementedException();
      }
    }

  public interface IUserService : IService<User>
  {
      IEnumerable<User> GetUsersByTypeCode(string typeCode);      
  }
}
