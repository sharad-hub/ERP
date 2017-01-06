using ERP.Data.Models;
using ERP.Entities;
using ERP.Services;
using ERP.Servicess;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System.Web.Http;
using Unity.WebApi;

namespace ERP.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();            
            // register all your components with the container here
            // it is NOT necessary to register your controllers            
            // e.g. container.RegisterType<ITestService, TestService>();
            UnityConfig.RegesterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
        public static void RegesterTypes(UnityContainer container){
       container
    .RegisterType<IDataContextAsync, GERPContext>(new PerThreadLifetimeManager())
    .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerThreadLifetimeManager())   
    .RegisterType<IRepositoryAsync<Menu>, Repository<Menu>>()
    .RegisterType<IRepositoryAsync<Error>, Repository<Error>>()   
    .RegisterType<IMembershipService, MembershipService>()
    .RegisterType<IMenuService, MenuService>()
    .RegisterType<IErrorService, ErrorService>()    
    .RegisterType<IRepositoryAsync<User>, Repository<User>>()
    .RegisterType<IRepositoryAsync<UserRole>, Repository<UserRole>>()
    .RegisterType<IRepositoryAsync<Role>, Repository<Role>>()   
    .RegisterType<IEncryptionService, EncryptionService>()     
    //.RegisterType<IStoredProcedureService,  StoredProcedureService>() 
    //.RegisterType<IShopStoredProcedures, ShopDBContext>(new PerRequestLifetimeManager())
    ;
        }
    }
}