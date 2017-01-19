using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class DesignationMasterMap : EntityTypeConfiguration<Designation>
    {
        public DesignationMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.DesignationId);

            // Properties
            this.Property(t => t.DesignationName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DesignationMaster");
            this.Property(t => t.DesignationId).HasColumnName("Id");
            this.Property(t => t.DesignationName).HasColumnName("DesignationName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
