using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ERP.DTO.Models.Mapping;

namespace ERP.DTO.Models
{
    public partial class dbUIGridContext : DbContext
    {
        static dbUIGridContext()
        {
            Database.SetInitializer<dbUIGridContext>(null);
        }

        public dbUIGridContext()
            : base("Name=dbUIGridContext")
        {
        }

        public DbSet<BuyerMaster> BuyerMasters { get; set; }
        public DbSet<CityMaster> CityMasters { get; set; }
        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<DepartmentMaster> DepartmentMasters { get; set; }
        public DbSet<DesignationMaster> DesignationMasters { get; set; }
        public DbSet<FactoryMaster> FactoryMasters { get; set; }
        public DbSet<SalesExecutiveMaster> SalesExecutiveMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<tblProduct> tblProducts { get; set; }
        public DbSet<ZoneMaster> ZoneMasters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BuyerMasterMap());
            modelBuilder.Configurations.Add(new CityMasterMap());
            modelBuilder.Configurations.Add(new CountryMasterMap());
            modelBuilder.Configurations.Add(new DepartmentMasterMap());
            modelBuilder.Configurations.Add(new DesignationMasterMap());
            modelBuilder.Configurations.Add(new FactoryMasterMap());
            modelBuilder.Configurations.Add(new SalesExecutiveMasterMap());
            modelBuilder.Configurations.Add(new StateMasterMap());
            modelBuilder.Configurations.Add(new tblProductMap());
            modelBuilder.Configurations.Add(new ZoneMasterMap());
        }
    }
}
