using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Repository.Pattern.DataContext;
using ERP.Data.Models;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Repositories;
using System.Web.UI.WebControls;
using Repository.Pattern.Ef6;
using ERP.Services;
using ERP.Entities;
using ERP.Servicess;
using ERP.Entities.Models;
//using Elmah;

namespace ERP.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container
         .RegisterType<IDataContextAsync, GERPContext>(new PerThreadLifetimeManager())
         .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerThreadLifetimeManager())
         .RegisterType<IRepositoryAsync<Entities.Menu>, Repository<Entities.Menu>>()
         .RegisterType<IRepositoryAsync<Error>, Repository<Error>>()
         .RegisterType<IMembershipService, MembershipService>()
         .RegisterType<IMenuService, MenuService>()
         .RegisterType<IModuleService, ModuleService>()
         .RegisterType<IUserService, UserService>()
         .RegisterType<IErrorService, ErrorService>()
         .RegisterType<IModuleGroupService, ModuleGroupService>()
         .RegisterType<IModuleGroupAccessService, ModuleGroupAccessService>()
         .RegisterType<IUserSettingsService, UserSettingsService>()
         .RegisterType<IAccessTypeService, AccessTypeService>()
         .RegisterType<IUserModulesService, UserModulesService>()
         .RegisterType<IUrlContextService, UrlContextService>()
         .RegisterType<ISalesExecutiveService, SalesExecutiveService>()
         .RegisterType<IDesignationService, DesignationService>()
         .RegisterType<IBuyerService, BuyerService>()
         .RegisterType<IFactoryService, FactoryService>()
         .RegisterType<IUserTypeService, UserTypeService>()
         .RegisterType<ICityService, CityService>()
         .RegisterType<IStateService, StateService>()
         .RegisterType<IZoneService, ZoneService>()
         .RegisterType<ICountryService, CountryService>()

         .RegisterType<IProductColorService, ProductColorService>()
         .RegisterType<IProductFactoryAllocationService, ProductFactoryAllocationService>()
         .RegisterType<IProductGroupService, ProductGroupService>()
         .RegisterType<IProductImageService, ProductImageService>()
         .RegisterType<IProductOpeningBalanceService, ProductOpeningBalanceService>()
         .RegisterType<IProductService, ProductService>()
         .RegisterType<IProductTypeService, ProductTypeService>()
         .RegisterType<IProductSKUService, ProductSKUService>()
         .RegisterType<IProductSubGroupService, ProductSubGroupService>()
         .RegisterType<IProductTypeService, ProductTypeService>()
         .RegisterType<IUnitOfMaterialService, UnitOfMaterialService>()
          .RegisterType<IRepositoryAsync<UnitOfMaterial>, Repository<UnitOfMaterial>>()
         .RegisterType<IRepositoryAsync<ProductFactoryAllocation>, Repository<ProductFactoryAllocation>>()
         .RegisterType<IRepositoryAsync<ProductImage>, Repository<ProductImage>>()
         .RegisterType<IRepositoryAsync<ProductColor>, Repository<ProductColor>>()
         .RegisterType<IRepositoryAsync<Product>, Repository<Product>>()
         .RegisterType<IRepositoryAsync<ProductType>, Repository<ProductType>>()
         .RegisterType<IRepositoryAsync<SalesExecutive>, Repository<SalesExecutive>>()
         .RegisterType<IRepositoryAsync<ProductSKU>, Repository<ProductSKU>>()
         .RegisterType<IRepositoryAsync<ProductGroup>, Repository<ProductGroup>>()
         .RegisterType<IRepositoryAsync<ProductSubGroup>, Repository<ProductSubGroup>>()
         .RegisterType<IRepositoryAsync<Factory>, Repository<Factory>>()
         .RegisterType<IRepositoryAsync<Designation>, Repository<Designation>>()
         .RegisterType<IRepositoryAsync<City>, Repository<City>>()
         .RegisterType<IRepositoryAsync<State>, Repository<State>>()
         .RegisterType<IRepositoryAsync<Zone>, Repository<Zone>>()
         .RegisterType<IRepositoryAsync<Country>, Repository<Country>>()
         .RegisterType<IRepositoryAsync<UserType>, Repository<UserType>>()
         .RegisterType<IRepositoryAsync<User>, Repository<User>>()
         .RegisterType<IRepositoryAsync<AccessType>, Repository<AccessType>>()
         .RegisterType<IRepositoryAsync<ModuleGroup>, Repository<ModuleGroup>>()
         .RegisterType<IRepositoryAsync<ModuleGroupAccess>, Repository<ModuleGroupAccess>>()
         .RegisterType<IRepositoryAsync<SystemSetting>, Repository<SystemSetting>>()
         .RegisterType<IRepositoryAsync<Module>, Repository<Module>>()
         .RegisterType<IRepositoryAsync<UserRole>, Repository<UserRole>>()
         .RegisterType<IRepositoryAsync<Role>, Repository<Role>>()
         .RegisterType<IRepositoryAsync<Buyer>, Repository<Buyer>>()
         .RegisterType<IRepositoryAsync<UserModules>, Repository<UserModules>>()
         .RegisterType<IRepositoryAsync<UrlContext>, Repository<UrlContext>>()
         .RegisterType<IEncryptionService, EncryptionService>()
         .RegisterType<IStoredProcedureService, StoredProcedureService>()
        .RegisterType<IERPStoredProcedure, GERPContext>(new PerRequestLifetimeManager())
         ;
        }
    }
}
