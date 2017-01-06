using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ERP.Data.Models.Mapping;
using ERP.Entities;
using Repository.Pattern.Ef6;
using ERP.Entities.Models;
namespace ERP.Data.Models
{
    public partial class GERPContext : DataContext
    {
        static GERPContext()
        {
            Database.SetInitializer<GERPContext>(null);
        }

        public GERPContext()
            : base("Name=ERP_main")
        {
        } 



        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CompanyWiseModule> CompanyWiseModules { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<FYear> FYears { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserTypes { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        //public DbSet<UserRole> UserTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccessTypeMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new CompanyWiseModuleMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new DesignationMap());
            modelBuilder.Configurations.Add(new FYearMap());
            modelBuilder.Configurations.Add(new GenderMap());
            modelBuilder.Configurations.Add(new IconMap());
            modelBuilder.Configurations.Add(new MaritalStatusMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new TitleMap());
            modelBuilder.Configurations.Add(new UserRightMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserTypeMap());
        }
    }
}
