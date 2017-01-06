using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class CompanyWiseModuleMap : EntityTypeConfiguration<CompanyWiseModule>
    {
        public CompanyWiseModuleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ModuleName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CompanyWiseModule");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompId).HasColumnName("CompId");
            this.Property(t => t.ModuleId).HasColumnName("ModuleId");
            this.Property(t => t.ModuleName).HasColumnName("ModuleName");
            this.Property(t => t.Orderby).HasColumnName("Orderby");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
