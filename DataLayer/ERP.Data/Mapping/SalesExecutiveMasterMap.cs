using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class SalesExecutiveMasterMap : EntityTypeConfiguration<SalesExecutive>
    {
        public SalesExecutiveMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.SalesExecId);

            // Properties
            this.Property(t => t.SalesExecName)
                .HasMaxLength(100);

            this.Property(t => t.MobileNo)
                .HasMaxLength(50);

            this.Property(t => t.EmailId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SalesExecutiveMaster");
            this.Property(t => t.SalesExecId).HasColumnName("SalesExecId");
            this.Property(t => t.SalesExecName).HasColumnName("SalesExecName");
            this.Property(t => t.SalesExecDesignationId).HasColumnName("SalesExecDesignationId");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.MobileNo).HasColumnName("MobileNo");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.ZoneId).HasColumnName("ZoneId");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.CityId).HasColumnName("CityId");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
