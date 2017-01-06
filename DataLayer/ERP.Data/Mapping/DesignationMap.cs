using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class DesignationMap : EntityTypeConfiguration<Designation>
    {
        public DesignationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Designation1)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Designations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.compId).HasColumnName("compId");
            this.Property(t => t.Designation1).HasColumnName("Designation");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
